namespace MemeHub.Services.MemeService
{
    using MemeHub.Database;
    using MemeHub.Database.Models;
    using MemeHub.Services.CategoryService;
    using MemeHub.Services.LabelService;
    using MemeHub.ViewModels.MemeViewModels;
    using System.Collections.Generic;
    using System.Threading.Tasks;
    using static MemeHub.Common.ServiceLayerConstants.MemeServiceConstants;

    public class MemeService : IMemeService
    {
        private readonly MemeHubDbContext memeHubDbContext;
        private readonly ICategoryService categoryService;
        private readonly ILabelService labelService;

        public MemeService(MemeHubDbContext memeHubDbContext, ICategoryService categoryService, ILabelService labelService)
        {
            this.memeHubDbContext = memeHubDbContext;
            this.categoryService = categoryService;
            this.labelService = labelService;
        }

        public async Task<int?> CreateMemeAsync(string userId, MemeFormViewModel memeInputFormView)
        {
            if (string.IsNullOrWhiteSpace(userId) == true)
            {
                throw new InvalidOperationException(string.Format(EmptyUserId, userId));
            }

            if (string.IsNullOrWhiteSpace(memeInputFormView.imageUrl) == true)
            {
                //TODO: Verify if file is actual image!!!
                throw new InvalidOperationException(string.Format(EmptyImageUrl, memeInputFormView.imageUrl));
            }

            var category = await this.categoryService.GetCategoryByIdAsync(memeInputFormView.CategoryId);
            if (category == null)
            {
                throw new InvalidOperationException(string.Format(CategoryNotFound, memeInputFormView.CategoryId));
            }

            var label = await this.labelService.GetLabelByIdAsync(memeInputFormView.LabelId);
            var meme = new Meme()
            {
                Title = memeInputFormView.Title,
                UserId = userId,
                Category = category,
                imageUrl = memeInputFormView.imageUrl,
                CreatedAt = DateTime.UtcNow,
                Label = label
            };

            await this.memeHubDbContext.Memes.AddAsync(meme);
            await this.memeHubDbContext.SaveChangesAsync();
            return meme.Id;
        }

        public Task<bool> DeleteMemeAsync(int targetMemeId)
        {
            throw new NotImplementedException();
        }

        public Task<MemeServiceModel> GetMemeByIdAsync(int targetMemeId)
        {
            throw new NotImplementedException();
        }

        public Task<List<MemeServiceModel>> GetMemesAsync(int limit, int offset)
        {
            throw new NotImplementedException();
        }

        public Task<MemeServiceModel> UpdateMemeAsync(int targetMemeId, MemeFormViewModel memeInputView)
        {
            throw new NotImplementedException();
        }
    }
}
