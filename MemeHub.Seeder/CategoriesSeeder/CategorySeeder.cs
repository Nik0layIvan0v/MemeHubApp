namespace MemeHub.Seeder.CategoriesSeeder
{
    using MemeHub.Services.CategoryService;
    using Newtonsoft.Json;

    public class CategorySeeder : ICategorySeeder
    {
        private readonly string categoriesFilePath = Path.Combine(Directory.GetCurrentDirectory(), "categories.json");

        private readonly ICategoryService categoryService;

        public CategorySeeder(ICategoryService categoryService)
        {
            this.categoryService = categoryService;
        }

        public async void SeedDefaultCategories()
        {
            if (File.Exists(categoriesFilePath) == false)
            {
                throw new InvalidOperationException($"categories.json does not exist on file path: {categoriesFilePath}");
            }

            string categoriesJsonText = await File.ReadAllTextAsync(categoriesFilePath);
            if (string.IsNullOrWhiteSpace(categoriesJsonText) == true)
            {
                throw new InvalidOperationException($"categories.json does not contains array with default categories! (file path: {categoriesFilePath})");
            }

            string[]? categories = JsonConvert.DeserializeObject<string[]>(categoriesJsonText);
            if (categories == null)
            {
                throw new InvalidOperationException($"Invalid deserialize operation on categories.json ({nameof(categories)} is null on file path: {categoriesFilePath})");
            }

            foreach(string category in categories)
            {
                await this.categoryService.CreateCategoryAsync(category);
            }
        }
    }
}
