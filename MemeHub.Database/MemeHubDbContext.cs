namespace MemeHub.Database
{
    using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore;

    public class MemeHubDbContext : IdentityDbContext
    {
        public MemeHubDbContext(DbContextOptions<MemeHubDbContext> options)
            : base(options)
        {
        }
    }
}