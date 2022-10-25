namespace MemeHub.App.Controllers
{
    using MemeHub.Infrastructure.Extensions;
    using MemeHub.Services.CategoryService;
    using MemeHub.Services.MemeService;
    using MemeHub.ViewModels.MemeViewModels;
    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Mvc;
    using static MemeHub.Common.ServiceLayerConstants.MemeServiceConstants;

    [Authorize]
    public class MemeController : WebController
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
            var categories = await this.categoryService.GetAllCategoriesAsync();
            var formView = new MemeFormViewModel()
            {
                Categories = categories
                            .Select(category => new CategoryViewModel()
                            {
                                Name = category.Name,
                                Id = category.Id,
                            }).ToList()
            };

            return View(formView);
        }

        [HttpPost]
        public async Task<IActionResult> Create(MemeFormViewModel formViewModel)
        {
            if (ModelState.IsValid == false)
            {
                var categories = await this.categoryService.GetAllCategoriesAsync();
                formViewModel.Categories = categories
                .Select(category => new CategoryViewModel()
                {
                    Name = category.Name,
                    Id = category.Id,
                }).ToList();

                return View(formViewModel);
            }

            var userId = this.User.GetLoggedInUserId();
            var createdMemeId = await this.memeService.CreateMemeAsync(userId, formViewModel);

            return this.RedirectToAction(nameof(MemeController.Details), GetControllerName<MemeController>(), new { id = createdMemeId });
        }

        [HttpGet]
        public async Task<IActionResult> Details(int id)
        {
            if (id < MinDatabaseId)
            {
                throw new InvalidOperationException($"Meme is not in our database! {id}");
            }

            var meme = await this.memeService.GetMemeByIdAsync(id);

            return View(meme);
        }

        [HttpGet]
        public async Task<IActionResult> Delete(int id)
        {
            return View();
        }

        [HttpGet]
        public async Task<IActionResult> Edit()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Edit(MemeFormViewModel formViewModel)
        {
            if (ModelState.IsValid == false)
            {
                return View(formViewModel);
            }

            return this.RedirectToAction(nameof(HomeController.Index), GetControllerName<HomeController>());
        }
    }
}
