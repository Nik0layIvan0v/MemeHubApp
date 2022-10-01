namespace MemeHub.Database.Models
{
    using Microsoft.EntityFrameworkCore;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using static MemeHub.Common.DatabaseConstants.MemesConstant;
    public class Meme : BaseIdentityColumn
    {
        public Meme()
        {
            this.Category = new Category();
            this.User = new User();
            this.Label = new Label();
            this.Likes = new HashSet<Like>();
            this.Comments = new HashSet<Comment>();
        }

        [Required]
        [Column(TypeName = "DATETIME2")]
        public DateTime? CreatedAt { get; set; }

        [Required]
        [Unicode(true)]
        [MaxLength(MaxTitleLength)]
        public string? Title { get; set; }

        //There may be decoded urls with non unicode symbols
        [Required]
        [Unicode(true)]
        public string? imageUrl { get; set; }

        [Required]
        public int? CategoryId { get; set; }

        public virtual Category Category { get; set; }

        [Required]
        public string? UserId { get; set; }

        public virtual User User { get; set; }

        public int? LabelId { get; set; }

        public virtual Label Label { get; set; }

        public virtual ICollection<Like> Likes { get; init; }

        public virtual ICollection<Comment> Comments { get; init; }
    }
}
