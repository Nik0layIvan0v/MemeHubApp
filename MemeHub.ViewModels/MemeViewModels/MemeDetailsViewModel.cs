namespace MemeHub.ViewModels.MemeViewModels
{
    public class MemeDetailsViewModel
    {
        public int Id { get; set; }

        public string Title { get; set; }

        public string ImageUrl { get; set; }

        public CategoryViewModel Category { get; set; }

        public string CreatedAt { get; set; }

        public string Creator { get; set; }

        public string Label { get; set; }

        public int Likes { get; set; }

        //public List<Comment> Comments { get; set; }
    }
}
