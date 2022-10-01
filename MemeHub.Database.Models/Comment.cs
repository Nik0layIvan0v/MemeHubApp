namespace MemeHub.Database.Models
{
    using Microsoft.EntityFrameworkCore;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using static MemeHub.Common.DatabaseConstants.CommentsConstant;

    public class Comment : BaseIdentityColumn
    {
        public Comment()
        {
            this.User = new User();
            this.Meme = new Meme();
            this.Likes = new HashSet<Like>();
            this.ParentComments = new HashSet<ParentChildrenComment>();
            this.ChildrenComments = new HashSet<ParentChildrenComment>();
        }

        [Required]
        [Unicode(true)]
        [MaxLength(MaxContentLength)]
        public string? Content { get; set; }

        [Required]
        [Column(TypeName = "DATETIME2")]
        public DateTime? CreatedDate { get; set; }

        [Required]
        public string? UserId { get; set; }

        public virtual User User { get; set; }

        [Required]
        public int? MemeId { get; set; }

        public virtual Meme Meme { get; set; } 

        public virtual ICollection<Like> Likes { get; set; }

        [InverseProperty("ParentComment")]
        public virtual ICollection<ParentChildrenComment> ParentComments { get; init; }

        [InverseProperty("ChildComment")]
        public virtual ICollection<ParentChildrenComment> ChildrenComments { get; init; }
    }
}
