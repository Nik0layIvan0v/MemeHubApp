namespace MemeHub.App.Controllers
{
    using MemeHub.ViewModels.MemeViewModels;
    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Mvc;

    [Authorize]
    public class MemeController : WebController
    {
        public MemeController()
        {
        }

        [HttpGet]
        public async Task<IActionResult> Create()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] MemeFormViewModel formViewModel)
        {
            if (ModelState.IsValid == false)
            {
                return View(formViewModel);
            }

            return this.RedirectToAction(nameof(HomeController.Index), GetControllerName<HomeController>());
        }
    }
}
