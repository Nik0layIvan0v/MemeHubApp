namespace MemeHub.Database.Models
{
    using Microsoft.EntityFrameworkCore;
    using System.ComponentModel.DataAnnotations;
    using static MemeHub.Common.DatabaseConstants.CategoriesConstant;

    public class Category : BaseIdentityColumn
    {
        public Category()
        {
            this.Memes = new HashSet<Meme>();
        }

        public Category(int? id, string name)
        {
            if (id == null)
            {
                this.Id = Id;
            }

            this.CategoryName = name;
        }

        [Required]
        [Unicode(true)]
        [MaxLength(MaxNameLength)]
        public string? CategoryName { get; set; }

        public virtual ICollection<Meme> Memes { get; init; }
    }
}
