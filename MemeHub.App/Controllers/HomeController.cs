namespace MemeHub.App.Controllers
{
    using Microsoft.AspNetCore.Mvc;

    public class HomeController : WebController
    {
        public HomeController()
        {
        }

        public async Task<IActionResult> Index()
        {
            return View();
        }

        public async Task<IActionResult> About()
        {
            return RedirectToAction(nameof(HomeController.Index), GetControllerName<HomeController>());
        }
    }
}
