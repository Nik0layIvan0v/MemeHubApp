namespace MemeHub.Database.Models
{
    using Microsoft.EntityFrameworkCore;
    using System.ComponentModel.DataAnnotations;
    using static MemeHub.Common.DatabaseConstants.LabelsConstant;

    public class Label : BaseIdentityColumn
    {
        public Label()
        {
            this.Memes = new HashSet<Meme>();
        }

        [Required]
        [Unicode(true)]
        [MaxLength(MaxNameLength)]
        public string? Name { get; set; }

        public virtual ICollection<Meme> Memes { get; init; }
    }
}
