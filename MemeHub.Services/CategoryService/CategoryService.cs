namespace MemeHub.Services.CategoryService
{
    using MemeHub.Database;
    using MemeHub.Database.Models;
    using Microsoft.EntityFrameworkCore;
    using System.Collections.Generic;
    using System.Threading.Tasks;
    using static MemeHub.Common.ServiceLayerConstants.CategoryServiceConstants;
    public class CategoryService : ICategoryService
    {
        private readonly MemeHubDbContext memeHubDbContext;

        public CategoryService(MemeHubDbContext memeHubDbContext)
        {
            this.memeHubDbContext = memeHubDbContext;
        }

        public async Task<CategoryServiceModel> CreateCategoryAsync(string name)
        {
            if (string.IsNullOrWhiteSpace(name) == true)
            {
                throw new ArgumentNullException(string.Format(nameof(name), EmptyNameExceptionMessage));
            }

            var category = new Category() { CategoryName = name };
            await memeHubDbContext.Categories.AddAsync(category);
            await memeHubDbContext.SaveChangesAsync();
            return new CategoryServiceModel(category.Id, category.CategoryName);
        }

        public async Task<bool> DeleteCategoryAsync(int targetCategoryId, int newMemeCategoryId)
        {
            if (targetCategoryId < 0)
            {
                throw new InvalidOperationException(string.Format(IdLessThanZeroExceptionMessage, nameof(targetCategoryId)));
            }

            if (newMemeCategoryId < 0)
            {
                throw new InvalidOperationException(string.Format(IdLessThanZeroExceptionMessage, nameof(newMemeCategoryId)));
            }

            var deletedCategory = await memeHubDbContext.Categories
                                                        .Where(cat => cat.Id == targetCategoryId)
                                                        .FirstOrDefaultAsync();
            if (deletedCategory == null)
            {
                throw new InvalidDataException(string.Format(NoSuchCategoryExceptionMessage, targetCategoryId));
            }

            var newMemeCategory = await memeHubDbContext.Categories
                                                        .Where(cat => cat.Id == newMemeCategoryId)
                                                        .FirstOrDefaultAsync();
            if (newMemeCategory == null)
            {
                throw new InvalidDataException(string.Format(NoSuchCategoryExceptionMessage, newMemeCategory));
            }

            var memes = await memeHubDbContext.Memes
                                              .Where(meme => meme.CategoryId == deletedCategory.Id)
                                              .ToListAsync();

            foreach (var meme in memes)
            {
                meme.CategoryId = newMemeCategory.Id;
            }

            memeHubDbContext.Categories.Remove(deletedCategory);
            int countOfChanges = await memeHubDbContext.SaveChangesAsync();
            return countOfChanges > 0;
        }

        public async Task<List<CategoryServiceModel>> GetAllCategoriesAsync()
        {
            return await memeHubDbContext.Categories
                                         .Select(cat => new CategoryServiceModel(cat.Id, cat.CategoryName))
                                         .ToListAsync();
        }

        public async Task<CategoryServiceModel> GetCategoryByNameAsync(string name)
        {
            if (string.IsNullOrWhiteSpace(name) == true)
            {
                throw new ArgumentNullException(string.Format(EmptyNameExceptionMessage, name));
            }

            var result = await memeHubDbContext.Categories
                                               .Where(cat => cat.CategoryName.Contains(name) == true)
                                               .Select(cat => new CategoryServiceModel(cat.Id, cat.CategoryName))
                                               .FirstOrDefaultAsync();
            if (result == null)
            {
                throw new InvalidOperationException(string.Format(NoSuchCategoryExceptionMessage, name));
            }

            return result;
        }

        public async Task<int> GetCategoryIdAsync(string name)
        {
            if (string.IsNullOrWhiteSpace(name) == true)
            {
                throw new ArgumentNullException(string.Format(EmptyNameExceptionMessage, name));
            }

            return await memeHubDbContext.Categories
                                         .Where(cat => cat.CategoryName == name)
                                         .Select(cat => cat.Id)
                                         .FirstOrDefaultAsync();
        }

        public async Task<bool> UpdateCategoryAsync(int id, string name)
        {
            if (id < 0)
            {
                throw new InvalidOperationException(string.Format(IdLessThanZeroExceptionMessage, nameof(id)));
            }

            var category = await memeHubDbContext.Categories
                                                 .Where(cat => cat.Id == id)
                                                 .FirstOrDefaultAsync();
            if (category == null)
            {
                throw new ArgumentNullException(string.Format(EmptyNameExceptionMessage, name));
            }

            category.CategoryName = name;
            int countOfChanges = await memeHubDbContext.SaveChangesAsync();
            return countOfChanges > 0;
        }

        public async Task<Category?> GetCategoryByIdAsync(int id)
        {
            if (id < 0)
            {
                throw new ArgumentNullException(string.Format(IdLessThanZeroExceptionMessage, id));
            }

            return await memeHubDbContext.Categories
                                         .Where(cat => cat.Id == id)
                                         .FirstOrDefaultAsync();
        }
    }
}
