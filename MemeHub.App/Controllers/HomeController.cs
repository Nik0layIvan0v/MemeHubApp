namespace MemeHub.App.Controllers
{
    using MemeHub.Infrastructure.Extensions;
    using MemeHub.Services.CategoryService;
    using MemeHub.Services.LabelService;
    using MemeHub.Services.MemeService;
    using MemeHub.ViewModels;
    using MemeHub.ViewModels.MemeViewModels;
    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Mvc;
    using System.Diagnostics;

    public class HomeController : Controller
    {
        private readonly ILabelService labelService;
        private readonly ICategoryService categoryService;
        private readonly IMemeService memeService;

        public HomeController
        (
            ILabelService labelService,
            ICategoryService categoryService,
            IMemeService memeService)
        {
            this.labelService = labelService;
            this.categoryService = categoryService;
            this.memeService = memeService;
        }

        public async Task<IActionResult> Index()
        {
            return View();
        }

        [Authorize]
        public async Task<IActionResult> About()
        {
            //TEST Code for add meme! !!!ATTENTION!!! Log in as administrator or user id will be null!!!
            string userId = this.User.GetLoggedInUserId();
            await this.categoryService.CreateCategoryAsync("Test category");
            var testFormViewModel = new MemeFormViewModel()
            {
                CategoryId = 1,
                imageUrl = "https://englishonline.britishcouncil.org/wp-content/uploads/2021/11/image2-drake-posting-meme.jpg",
                LabelId = 1,
                Title = "Cool meme title"
            };

            await this.memeService.CreateMemeAsync(userId, testFormViewModel);
            return Ok();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
