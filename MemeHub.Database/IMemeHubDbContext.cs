namespace MemeHub.Database
{
    using MemeHub.Database.Models;
    using Microsoft.EntityFrameworkCore;

    public interface IMemeHubDbContext
    {
        DbSet<Category> Categories { get; set; }
        
        DbSet<Comment> Comments { get; set; }
        
        DbSet<Label> Labels { get; set; }
        
        DbSet<Like> Likes { get; set; }
        
        DbSet<Meme> Memes { get; set; }
        
        DbSet<ParentChildrenComment> ParentChildrenComments { get; set; }

        Task<int> SaveChangesAsync();
    }
}
