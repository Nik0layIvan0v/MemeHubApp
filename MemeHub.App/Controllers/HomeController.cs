namespace MemeHub.App.Controllers
{
    using MemeHub.Services.LabelService;
    using MemeHub.ViewModels;
    using Microsoft.AspNetCore.Mvc;
    using System.Diagnostics;

    public class HomeController : Controller
    {
        private readonly ILabelService labelService;

        public HomeController(ILabelService labelService)
        {
            this.labelService = labelService;
        }

        public IActionResult Index()
        {
            return View();
        }

        public async Task<IActionResult> Privacy()
        {
            LabelServiceModel cratedModel = await labelService.CreateLabelAsync("my first label");
            LabelServiceModel cratedModelSecond = await labelService.CreateLabelAsync("my second label");
            bool isDeleted = await labelService.DeleteLabelAsync(1);
            bool isEdited = await labelService.EditLabelAsync(2, "My edited fist label");
            List<LabelServiceModel> labels = await labelService.GetAllLabelsAsync();
            LabelServiceModel targetLabel = await labelService.GetLabelAsync(1);
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
