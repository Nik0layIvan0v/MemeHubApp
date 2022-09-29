namespace MemeHub.App.Controllers
{
    using MemeHub.Infrastructure.Extensions;
    using MemeHub.Services.MemeService;
    using MemeHub.ViewModels.MemeViewModels;
    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Mvc;

    [Authorize]
    public class MemeController : Controller
    {
        private readonly IMemeService memeService;
        private readonly string userId;

        public MemeController(IMemeService memeService)
        {
            this.userId  = this.User.GetLoggedInUserId();
            this.memeService = memeService;
        }

        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(MemeFormViewModel formViewModel)
        {
            if (ModelState.IsValid == false)
            {
                return View(formViewModel);
            }

            await this.memeService.CreateMemeAsync(this.userId, formViewModel);
            return View();
        }
    }
}
