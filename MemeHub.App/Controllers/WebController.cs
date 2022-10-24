namespace MemeHub.App.Controllers
{
    using MemeHub.ViewModels;
    using Microsoft.AspNetCore.Mvc;
    using System.Diagnostics;

    public class WebController : Controller
    {

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }

        public static string GetControllerName<T>()
            where T : Controller
        {
            var type = typeof(T);
            if (type is null)
            {
                throw new ArgumentNullException(nameof(type));
            }

            return type.Name.Replace(nameof(Controller), string.Empty);
        }
    }
}
