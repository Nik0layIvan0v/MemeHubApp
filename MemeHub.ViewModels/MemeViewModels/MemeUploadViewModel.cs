namespace MemeHub.ViewModels.MemeViewModels
{
    using Microsoft.AspNetCore.Http;
    using System.ComponentModel.DataAnnotations;

    public class MemeUploadViewModel
    {
        [Required]
        [MinLength(3)]
        [MaxLength(50)]
        [Display(Name = "Meme Title")]
        public string Title { get; set; }

        [Required]
        [Display(Name = "Meme Image url")]
        public IFormFile Photo { get; set; }

        [Required]
        public int CategoryId { get; set; }

        public int LabelId { get; set; }

        public ICollection<CategoryViewModel>? Categories { get; set; }
    }
}
