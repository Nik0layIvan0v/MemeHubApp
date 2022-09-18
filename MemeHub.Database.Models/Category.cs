namespace MemeHub.Database.Models
{
    using System.ComponentModel.DataAnnotations;
    using static MemeHub.Common.DatabaseConstants.CategoriesConstant;

    public class Category
    {
        public Category()
        {
            this.Memes = new HashSet<Meme>();
        }

        public int Id { get; set; }

        [MaxLength(MaxNameLength)]
        public string CategoryName { get; set; }

        public virtual ICollection<Meme> Memes { get; init; }
    }
}
