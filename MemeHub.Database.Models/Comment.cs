namespace MemeHub.Database.Models
{
    using System.ComponentModel.DataAnnotations;
    using static MemeHub.Common.DatabaseConstants.CommentsConstant;

    public class Comment
    {
        public Comment()
        {
            this.ParentComments = new HashSet<ParentChildrenComment>();
            this.ChildrenComments = new HashSet<ParentChildrenComment>();
            this.Likes = new HashSet<Like>();
        }

        public int Id { get; set; }

        [MaxLength(MaxContentLength)]
        public string Content { get; set; }

        public DateTime CreatedDate { get; set; }

        public string UserId { get; set; }

        public User User { get; set; }

        public int MemeId { get; set; }

        public Meme Meme { get; set; }

        public virtual ICollection<Like> Likes { get; set; }

        public virtual ICollection<ParentChildrenComment> ParentComments { get; init; }

        public virtual ICollection<ParentChildrenComment> ChildrenComments { get; init; }
    }
}
