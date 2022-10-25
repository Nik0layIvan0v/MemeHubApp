namespace MemeHub.Services.MemeService
{
    using MemeHub.Services.CategoryService;
    using MemeHub.ViewModels.MemeViewModels;

    public class MemeServiceModel
    {
        public int Id { get; set; }

        public string Title { get; set; }

        public string ImageUrl { get; set; }

        public CategoryServiceModel Category { get; set; }

        public string CreatedAt { get; set; }

        public string Creator { get; set; }

        public string Label { get; set; }

        public int Likes { get; set; }

        //public List<Comment> Comments { get; set; }
    }
}
