namespace MemeHub.ViewModels.MemeViewModels
{
    using System.ComponentModel.DataAnnotations;

    public class MemeFormViewModel
    {
        [Required]
        [MinLength(3)]
        [MaxLength(50)]
        [Display(Name = "Meme Title: ")]
        public string Title { get; set; }

        [Required]
        [MinLength(10)]
        [Display(Name = "Meme Image url: ")]
        public string ImageUrl { get; set; }

        [Required]
        public int CategoryId { get; set; }

        public int LabelId { get; set; }

        public ICollection<CategoryViewModel>? Categories { get; set; }
    }
}
