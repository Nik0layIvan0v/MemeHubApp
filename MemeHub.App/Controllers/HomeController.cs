namespace MemeHub.App.Controllers
{
    using MemeHub.Services.CategoryService;
    using MemeHub.Services.LabelService;
    using MemeHub.ViewModels;
    using Microsoft.AspNetCore.Mvc;
    using System.Diagnostics;

    public class HomeController : Controller
    {
        private readonly ILabelService labelService;
        private readonly ICategoryService categoryService;

        public HomeController(ILabelService labelService, ICategoryService categoryService)
        {
            this.labelService = labelService;
            this.categoryService = categoryService;
        }

        public IActionResult Index()
        {
            return View();
        }

        public async Task<IActionResult> Privacy()
        {
            var categoryOne = await this.categoryService.CreateCategoryAsync("test category one");
            var categoryTwo = await this.categoryService.CreateCategoryAsync("test category two");
            var categoryThree = await this.categoryService.CreateCategoryAsync("test category three");
            var categories = await this.categoryService.GetAllCategoriesAsync();
            var categoryByName = await this.categoryService.GetCategoryByNameAsync("three");
            var categoryId = await this.categoryService.GetCategoryIdAsync("two");
            var isUpdated = await this.categoryService.UpdateCategoryAsync(1, "test category one - Edited");
            var isDeleted = await this.categoryService.DeleteCategoryAsync(2, 3);

            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
