namespace MemeHub.Seeder.CategoriesSeeder
{
    using MemeHub.Services.CategoryService;
    using Newtonsoft.Json;

    public class CategorySeeder : ICategorySeeder
    {
        private readonly string categoriesFilePath;

        private readonly ICategoryService categoryService;

        public CategorySeeder(ICategoryService categoryService)
        {
            this.categoryService = categoryService;
            this.categoriesFilePath = this.GetJsonPath();
        }

        public async void SeedDefaultCategories()
        {
            //\MemeHubApp\MemeHub.Seeder\CategoriesSeeder
            var availableCategories = await this.categoryService.GetAllCategoriesAsync();
            if (availableCategories == null)
            {
                throw new InvalidOperationException($"No categories table in the database!");
            }

            if (availableCategories.Count > 0)
            {
                //No need to seed if there is already seeded categories!
                return;
            }

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

            foreach (string category in categories)
            {
                await this.categoryService.CreateCategoryAsync(category);
            }
        }

        private string GetJsonPath()
        {
            string basePath = Environment.CurrentDirectory;
            string relativePath = "..\\MemeHub.Seeder\\CategoriesSeeder\\categories.json";
            return Path.GetFullPath(relativePath, basePath);;
        }
    }
}
