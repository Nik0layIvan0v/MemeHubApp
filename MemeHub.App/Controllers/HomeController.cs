namespace MemeHub.App.Controllers
{
    using MemeHub.Database.Models;
    using MemeHub.Services.CategoryService;
    using MemeHub.Services.LabelService;
    using MemeHub.ViewModels;
    using Microsoft.AspNetCore.Identity;
    using Microsoft.AspNetCore.Mvc;
    using System.Diagnostics;

    public class HomeController : Controller
    {
        private readonly ILabelService labelService;
        private readonly ICategoryService categoryService;
        private readonly SignInManager<User> signInManager;

        public HomeController
        (
            ILabelService labelService,
            ICategoryService categoryService,
            SignInManager<User> signInManager)
        {
            this.labelService = labelService;
            this.categoryService = categoryService;
            this.signInManager = signInManager;
        }

        public async Task<IActionResult> Index()
        {
            var test = this.signInManager?.Context?.User?.Identity?.Name;
            return View();
            
        }

        public async Task<IActionResult> About()
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
