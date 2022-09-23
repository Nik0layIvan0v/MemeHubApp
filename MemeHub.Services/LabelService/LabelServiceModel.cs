namespace MemeHub.Services.LabelService
{
    using System.ComponentModel.DataAnnotations;

    public class LabelServiceModel
    {
        [Required]
        public int Id { get; set; }

        [Required]
        public string Name { get; set; }
    }
}
