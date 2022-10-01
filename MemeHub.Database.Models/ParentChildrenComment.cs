namespace MemeHub.Database.Models
{
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    public class ParentChildrenComment
    {
        public ParentChildrenComment()
        {
            this.ParentComment = new Comment();
            this.ChildComment = new Comment();
        }

        [Key]
        [Column(Order = 1)]
        public int? ParentCommentId { get; set; }

        public virtual Comment ParentComment { get; set; }

        [Key]
        [Column(Order = 2)]
        public int? ChildCommentId { get; set; }

        public virtual Comment ChildComment { get; set; }
    }
}
