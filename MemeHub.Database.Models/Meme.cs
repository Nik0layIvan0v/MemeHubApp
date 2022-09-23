namespace MemeHub.Database.Models
{
    using System.ComponentModel.DataAnnotations;
    using static MemeHub.Common.DatabaseConstants.MemesConstant;
    public class Meme
    {
        public Meme()
        {
            this.Likes = new HashSet<Like>();
            this.Comments = new HashSet<Comment>();
        }

        public int Id { get; set; }

        public DateTime CreatedAt { get; set; }

        [MaxLength(MaxTitleLength)]
        public string Title { get; set; }

        public byte[] Content { get; set; }

        public int CategoryId { get; set; }

        public Category Category { get; set; }
        
        public string UserId { get; set; }

        public User User { get; set; }


        public int LabelId { get; set; }

        public Label Label { get; set; }

        public virtual ICollection<Like> Likes { get; init; }

        public virtual ICollection<Comment> Comments { get; init; }
    }
}
