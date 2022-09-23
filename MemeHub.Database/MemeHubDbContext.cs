namespace MemeHub.Database
{
    using MemeHub.Database.Models;
    using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore;
    using System.Reflection;

    public class MemeHubDbContext : IdentityDbContext, IMemeHubDbContext
    {
        public MemeHubDbContext(DbContextOptions<MemeHubDbContext> options)
            : base(options)
        {
        }

        public DbSet<Category> Categories { get; set; }

        public DbSet<Comment> Comments { get; set; }

        public DbSet<Label> Labels { get; set; }

        public DbSet<Like> Likes { get; set; }

        public DbSet<Meme> Memes { get; set; }

        public DbSet<ParentChildrenComment> ParentChildrenComments { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
            base.OnModelCreating(builder);
        }
    }
}
