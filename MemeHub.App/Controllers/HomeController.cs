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

        public HomeController(ILabelService labelService, 
            ICategoryService categoryService 
            )
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
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
