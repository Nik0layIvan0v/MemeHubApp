namespace MemeHub.Database.Models
{
    using System.ComponentModel.DataAnnotations;
    using static MemeHub.Common.DatabaseConstants.LabelsConstant;

    public class Label
    {
        public Label()
        {
            this.Memes = new HashSet<Meme>();
        }

        public int Id { get; set; }

        [MaxLength(MaxNameLength)]
        public string Name { get; set; }

        public virtual ICollection<Meme> Memes { get; init; }
    }
}
