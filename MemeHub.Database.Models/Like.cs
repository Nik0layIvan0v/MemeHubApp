namespace MemeHub.Database.Models
{
    using System.ComponentModel.DataAnnotations;
    using static MemeHub.Common.DatabaseConstants.LikesConstant;
    public class Like
    {
        public Like()
        {
        }

        public int Id { get; set; }

        [MaxLength(MaxLikeTypeName)]
        public string Type { get; set; }

        public DateTime LikedAt { get; set; }

        public int MemeId { get; set; }

        public Meme Meme { get; set; }

        public int CommentId { get; set; }

        public Comment Comment { get; set; }

        public string UserId { get; set; }

        public User User { get; set; }
    }
}
