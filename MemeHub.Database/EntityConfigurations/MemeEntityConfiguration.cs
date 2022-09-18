namespace MemeHub.Database.EntityConfigurations
{
    using MemeHub.Database.Models;
    using Microsoft.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore.Metadata.Builders;

    public class MemeEntityConfiguration : IEntityTypeConfiguration<Meme>
    {
        public void Configure(EntityTypeBuilder<Meme> memeBuilder)
        {
            memeBuilder.HasKey(meme => meme.Id);

            memeBuilder.Property(prop => prop.Id)
                       .UseIdentityColumn<int>(0, 1);

            memeBuilder.Property(meme => meme.Title)
                       .IsUnicode(true)
                       .IsRequired(true);

            memeBuilder.Property(meme => meme.CreatedAt)
                       .IsRequired(true);

            memeBuilder.Property(meme => meme.Content)
                       .IsRequired(true);
        }
    }
}
