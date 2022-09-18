namespace MemeHub.Database.Models
{
    public class ParentChildrenComment
    {
        public ParentChildrenComment()
        {
        }

        public int ChildCommentId { get; set; }

        public Comment ChildComment { get; set; }

        public int ParentCommentId { get; set; }

        public Comment ParentComment { get; set; }
    }
}
