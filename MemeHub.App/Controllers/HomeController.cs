namespace MemeHub.App.Controllers
{
    using MemeHub.Infrastructure.Extensions;
    using MemeHub.Services.CategoryService;
    using MemeHub.Services.CommentService;
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
        private readonly ICommentService commentService;

        public HomeController
        (
            ILabelService labelService,
            ICategoryService categoryService,
            IMemeService memeService,
            ICommentService commentService)
        {
            this.labelService = labelService;
            this.categoryService = categoryService;
            this.memeService = memeService;
            this.commentService = commentService;
        }

        public async Task<IActionResult> Index()
        {
            return View();
        }

        [Authorize]
        public async Task<IActionResult> About()
        {
            var meme = await this.memeService.GetMemeByIdAsync(1);
            if (meme == null)
            {
                return View("Error");
            }

            var user = this.User.GetLoggedInUserId();
            if (user == null)
            {
                return View("Error");
            }

            string content = "This meme is sooo cool";
            
            var commentId = await this.commentService.CreateParrentCommentAsync(user, meme.Id, content);
            if (commentId <= 0)
            {
                return View("Error");
            }

            var countOfChanges = await this.commentService.DeleteParrentCommentByIdAsync(1);
            
            return Ok();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
