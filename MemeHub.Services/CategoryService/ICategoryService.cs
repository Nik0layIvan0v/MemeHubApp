﻿namespace MemeHub.Services.CategoryService
{
    public interface ICategoryService
    {
        Task<CategoryServiceModel> CreateCategoryAsync(string name);

        Task<bool> UpdateCategoryAsync(int id, string name);

        Task<bool> DeleteCategoryAsync(int targetCategoryId, int newMemeCategoryId);

        Task<List<CategoryServiceModel>> GetAllCategoriesAsync();

        Task<CategoryServiceModel> GetCategoryByNameAsync(string name);

        Task<int> GetCategoryIdAsync(string name);
    }
}