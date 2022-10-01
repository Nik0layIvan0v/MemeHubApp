namespace MemeHub.Database.Models
{
    using Microsoft.AspNetCore.Identity;
    using Microsoft.EntityFrameworkCore;
    using System.ComponentModel.DataAnnotations;
    using static MemeHub.Common.DatabaseConstants.UsersConstant;

    public class User : IdentityUser
    {
        public User()
        {
            this.Memes = new HashSet<Meme>();
            this.Comments = new HashSet<Comment>();
            this.Likes = new HashSet<Like>();
        }

        [Unicode(true)]
        [MaxLength(MaxNickNameLength)]
        public string? NickName { get; set; }

        public virtual ICollection<Meme> Memes { get; init; }

        public virtual ICollection<Comment> Comments { get; init; }

        public virtual ICollection<Like> Likes { get; init; }
    }
}
