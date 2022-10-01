namespace MemeHub.Database.Models
{
    using Microsoft.EntityFrameworkCore.Metadata.Internal;
    using System.ComponentModel.DataAnnotations;

    public class BaseIdentityColumn
    {
        [Key]
        public int Id { get; set; }
    }
}
