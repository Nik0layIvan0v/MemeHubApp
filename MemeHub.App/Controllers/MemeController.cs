namespace MemeHub.App.Controllers
{
    using MemeHub.Services.MemeService;
    using MemeHub.ViewModels.MemeViewModels;
    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Mvc;

    [Authorize]
    public class MemeController : Controller
    {
        private readonly IMemeService memeService;

        public MemeController(IMemeService memeService)
        {
            this.memeService = memeService;
        }

        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(MemeInputViewModel inputViewModel)
        {
            return View();
        }
    }
}
