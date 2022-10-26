namespace MemeHub.App.Controllers
{
    using MemeHub.Infrastructure.Extensions;
    using MemeHub.Services.CategoryService;
    using MemeHub.Services.MemeService;
    using MemeHub.ViewModels.MemeViewModels;
    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.AspNetCore.Hosting;
    using static MemeHub.Common.ServiceLayerConstants.MemeServiceConstants;

    [Authorize]
    public class MemeController : WebController
    {
        private readonly IMemeService memeService;
        private readonly ICategoryService categoryService;
        private readonly IWebHostEnvironment hostingEnvironment;

        public MemeController(IMemeService memeService, ICategoryService categoryService, IWebHostEnvironment hostingEnvironment)
        {
            this.memeService = memeService;
            this.categoryService = categoryService;
            this.hostingEnvironment = hostingEnvironment;
        }

        [HttpGet]
        public async Task<IActionResult> Create()
        {
            var categories = await this.categoryService.GetAllCategoriesAsync();
            var formView = new MemeUploadViewModel()
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
        public async Task<IActionResult> Create(MemeUploadViewModel formViewModel)
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

            if ((formViewModel.Photo == null) || 
                (formViewModel.Photo?.ContentType?.Contains("image") == false) ||
                string.IsNullOrWhiteSpace(formViewModel.Photo?.FileName) == true)
            {
                ModelState.AddModelError("Photo", "Uploaded file must be valid image type!");
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
            if (string.IsNullOrWhiteSpace(userId) == true)
            {
                throw new InvalidOperationException("Username is invalid!!!");
            }

            bool isUserDirectoryExist = false;
            string rootFolder = Path.Combine(this.hostingEnvironment.WebRootPath, "img");
            var directories = Directory.GetDirectories(rootFolder);
            foreach(var directory in directories)
            {
                if (directory.Contains(userId) == true)
                {
                    isUserDirectoryExist = true;
                    break;
                }
            }

            if (isUserDirectoryExist == false)
            {
                string userDirectory = Path.Combine(rootFolder, userId);
                Directory.CreateDirectory(userDirectory);
            }

            string uniqueFileName = Guid.NewGuid().ToString() + "_" + formViewModel.Photo?.FileName;
            string fullPath = Path.Combine(rootFolder, userId, uniqueFileName);
            using var stream = new FileStream(fullPath, FileMode.CreateNew);

            var memeServiceModel = new MemeFormViewModel()
            {
               ImageUrl = fullPath,
               Title = formViewModel.Title,
               CategoryId = formViewModel.CategoryId,
               LabelId = formViewModel.LabelId,
            };

            var createdMemeId = await this.memeService.CreateMemeAsync(userId, memeServiceModel);
            if ((createdMemeId != null) && (createdMemeId > 0))
            {
                await formViewModel?.Photo?.CopyToAsync(stream, CancellationToken.None);
            }

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
