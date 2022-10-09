namespace MemeHub.App.Controllers
{
    using MemeHub.Database.Models;
    using MemeHub.Infrastructure.Extensions;
    using MemeHub.Services.CategoryService;
    using MemeHub.Services.MemeService;
    using MemeHub.ViewModels.MemeViewModels;
    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Mvc;

    [Authorize]
    public class MemeController : Controller
    {
        private readonly IMemeService memeService;
        private readonly ICategoryService categoryService;

        public MemeController(IMemeService memeService, ICategoryService categoryService)
        {
            this.memeService = memeService;
            this.categoryService = categoryService;
        }

        [HttpGet]
        public async Task<IActionResult> Create()
        {
            var test = await this.categoryService.GetAllCategoriesAsync();
            MemeFormViewModel meme = new MemeFormViewModel();
            var categoryServiceModels = await this.categoryService.GetAllCategoriesAsync();
            meme.Categories = categoryServiceModels.Select(cat => new CategoryViewModel()
            {
                Name = cat.Name,
                Id = cat.Id,
            }).ToList();

            return View(meme);
        }

        [HttpPost]
        public async Task<IActionResult> Create(MemeFormViewModel formViewModel)
        {
            if (ModelState.IsValid == false)
            {
                var categoryServiceModels = await this.categoryService.GetAllCategoriesAsync();
                formViewModel.Categories = categoryServiceModels.Select(cat => new CategoryViewModel()
                {
                    Name = cat.Name,
                    Id = cat.Id,
                }).ToList();
                return View(formViewModel);
            }

            var userId = this.User.GetLoggedInUserId();
            await this.memeService.CreateMemeAsync(userId, formViewModel);
            return this.RedirectToAction(nameof(HomeController.Index), nameof(HomeController).Replace("Controller", string.Empty));
        }
    }
}
