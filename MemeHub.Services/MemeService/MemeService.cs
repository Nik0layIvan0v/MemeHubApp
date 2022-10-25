namespace MemeHub.Services.MemeService
{
    using MemeHub.Database;
    using MemeHub.Database.Models;
    using MemeHub.Services.CategoryService;
    using MemeHub.Services.LabelService;
    using MemeHub.ViewModels.MemeViewModels;
    using Microsoft.AspNetCore.Identity;
    using Microsoft.EntityFrameworkCore;
    using System.Collections.Generic;
    using System.Threading.Tasks;
    using static MemeHub.Common.ServiceLayerConstants.MemeServiceConstants;

    public class MemeService : IMemeService
    {
        private readonly MemeHubDbContext memeHubDbContext;
        private readonly ICategoryService categoryService;
        private readonly ILabelService labelService;
        private readonly UserManager<User> userManager;

        public MemeService(MemeHubDbContext memeHubDbContext,
               ICategoryService categoryService,
               ILabelService labelService,
               UserManager<User> userManager)
        {
            this.memeHubDbContext = memeHubDbContext;
            this.categoryService = categoryService;
            this.labelService = labelService;
            this.userManager = userManager;
        }

        public async Task<int?> CreateMemeAsync(string userId, MemeFormViewModel memeInputFormView)
        {
            if (string.IsNullOrWhiteSpace(userId) == true)
            {
                throw new InvalidOperationException(string.Format(EmptyUserId, userId));
            }

            var user = await this.userManager.FindByIdAsync(userId);
            if (user == null)
            {
                throw new InvalidOperationException(string.Format(EmptyUserId, userId));
            }

            if (string.IsNullOrWhiteSpace(memeInputFormView.ImageUrl) == true)
            {
                //TODO: Verify if file is actual image!!!
                throw new InvalidOperationException(string.Format(EmptyImageUrl, memeInputFormView.ImageUrl));
            }

            var category = await this.categoryService.GetCategoryByIdAsync(memeInputFormView.CategoryId);
            if (category == null)
            {
                throw new InvalidOperationException(string.Format(CategoryNotFound, memeInputFormView.CategoryId));
            }

            Label? label = null;
            if (memeInputFormView.LabelId > 0)
            {
                label = await this.labelService.GetLabelByIdAsync(memeInputFormView.LabelId);
            }

            var meme = new Meme()
            {
                Title = memeInputFormView.Title,
                User = user,
                Category = new Category(category.Id, category.Name),
                imageUrl = memeInputFormView.ImageUrl,
                CreatedAt = DateTime.UtcNow,
                Label = label
            };

            await this.memeHubDbContext.Memes.AddAsync(meme);
            await this.memeHubDbContext.SaveChangesAsync();
            return meme.Id;
        }

        //TODO: Add check if user own the meme or is administrator!
        public async Task<bool> DeleteMemeAsync(int targetMemeId)
        {
            if (targetMemeId < MinDatabaseId)
            {
                throw new InvalidDataException($"{nameof(targetMemeId)} cannot be less than zero!");
            }

            var meme = await this.memeHubDbContext.Memes
                                                  .Where(meme => meme.Id == targetMemeId)
                                                  .FirstOrDefaultAsync();
            if (meme == null)
            {
                throw new InvalidDataException($"Meme with id: {targetMemeId} not found in the database!");
            }

            int countOfChanges = await this.memeHubDbContext.SaveChangesAsync();
            return countOfChanges > 0;
        }

        public async Task<MemeServiceModel> GetMemeByIdAsync(int targetMemeId)
        {
            if (targetMemeId < MinDatabaseId)
            {
                throw new InvalidDataException($"{nameof(targetMemeId)} cannot be less than zero!");
            }

            var meme = await this.memeHubDbContext.Memes
                                 .Where(meme => meme.Id == targetMemeId)
                                 .FirstOrDefaultAsync();
            if (meme == null)
            {
                throw new InvalidDataException($"Meme with id: {targetMemeId} not found in the database!");
            }

            var category = await categoryService.GetCategoryByIdAsync(meme.CategoryId);

            var memeServiceModel = new MemeServiceModel()
            {
                Id = meme.Id,
                Category = category,
                CreatedAt = meme.CreatedAt.ToString(),
                Creator = meme.User.UserName,
                ImageUrl = meme.imageUrl,
                Title = meme.Title,
                Label = meme.Label.Name,
                Likes = meme.Likes.Count
            };

            return memeServiceModel;
        }

        public async Task<List<MemeServiceModel>> GetMemesAsync(int limit, int offset)
        {
            if (limit < MinDatabaseId)
            {
                throw new InvalidDataException($"{nameof(limit)} cannot be less than zero!");
            }

            if (offset < MinDatabaseId)
            {
                throw new InvalidDataException($"{nameof(offset)} cannot be less than zero!");
            }

            var memes = await this.memeHubDbContext.Memes
                                                   .Skip(offset)
                                                   .Take(limit)
                                                   .Select(meme => new MemeServiceModel()
                                                   {
                                                       Id = meme.Id,
                                                       Category = new CategoryServiceModel()
                                                       {
                                                           Id = meme.CategoryId,
                                                           Name = meme.Category.CategoryName
                                                       },
                                                       CreatedAt = meme.CreatedAt.ToString(),
                                                       Creator = meme.User.UserName,
                                                       ImageUrl = meme.imageUrl,
                                                       Title = meme.Title,
                                                       Label = meme.Label.Name,
                                                       Likes = meme.Likes.Count
                                                   })
                                                   .ToListAsync();
            return memes;
        }

        //TODO: Add check if user own the meme or is administrator!
        public async Task<int?> UpdateMemeAsync(int targetMemeId, MemeFormViewModel memeInputFormView)
        {
            if (targetMemeId < MinDatabaseId)
            {
                throw new InvalidDataException($"{nameof(targetMemeId)} cannot be less than zero!");
            }

            if (memeInputFormView == null)
            {
                throw new ArgumentNullException($"{nameof(memeInputFormView)} cannot be null!");
            }

            var meme = await this.memeHubDbContext.Memes
                                                  .Where(meme => meme.Id == targetMemeId)
                                                  .FirstOrDefaultAsync();

            if (meme == null)
            {
                throw new InvalidDataException($"Meme with id: {targetMemeId} not found in the database!");
            }

            var category = await this.categoryService.GetCategoryByIdAsync(memeInputFormView.CategoryId);
            if (category == null)
            {
                throw new InvalidOperationException(string.Format(CategoryNotFound, memeInputFormView.CategoryId));
            }

            var label = await this.labelService.GetLabelByIdAsync(memeInputFormView.LabelId);
            meme.Title = memeInputFormView.Title;
            meme.Category = new Category(category.Id, category.Name);
            meme.imageUrl = memeInputFormView.ImageUrl;
            meme.CreatedAt = DateTime.UtcNow;
            meme.Label = label;
            await this.memeHubDbContext.SaveChangesAsync();
            return meme.Id;
        }

        private async Task<bool> IsMemeOwnedByUser(string userId, int memeId)
        {
            var result = await this.memeHubDbContext.Memes
                                                    .Where(meme => (meme.Id == memeId) && (meme.UserId == userId))
                                                    .FirstOrDefaultAsync();
            return result != null;
        }
    }
}