namespace MemeHub.Database.Models
{
    using Microsoft.EntityFrameworkCore;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using static MemeHub.Common.DatabaseConstants.LikesConstant;

    public class Like : BaseIdentityColumn
    {
        public Like()
        {
            this.Meme = new Meme();
            this.Comment = new Comment();
            this.User = new User();
        }

        [Required]
        [Unicode(true)]
        [MaxLength(MaxLikeTypeName)]
        public string Type { get; set; }

        [Required]
        [Column(TypeName = "DATETIME2")]
        public DateTime LikedAt { get; set; }

        public int? MemeId { get; set; }

        public virtual Meme Meme { get; set; }

        public int? CommentId { get; set; }

        public virtual Comment Comment { get; set; }

        [Required]
        public string? UserId { get; set; }

        public virtual User User { get; set; }
    }
}
