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
                       .UseIdentityColumn<int>(1, 1);

            memeBuilder.Property(meme => meme.Title)
                       .IsUnicode(true)
                       .IsRequired(true);

            memeBuilder.Property(meme => meme.CreatedAt)
                       .IsRequired(true);

            memeBuilder.Property(meme => meme.imageUrl)
                       .IsRequired(true);

            memeBuilder.HasOne(meme => meme.Label)
                       .WithMany(label => label.Memes)
                       .HasConstraintName("FK_Memes_Labels")
                       .HasForeignKey(meme => meme.LabelId)
                       .OnDelete(DeleteBehavior.Restrict)
                       .IsRequired(false);

            memeBuilder.HasOne(meme => meme.User)
                       .WithMany(user => user.Memes)
                       .HasConstraintName("FK_Memes_Users")
                       .HasForeignKey(meme => meme.UserId)
                       .IsRequired(true);

            memeBuilder.HasOne(meme => meme.Category)
                       .WithMany(category => category.Memes)
                       .HasConstraintName("FK_Memes_Categories")
                       .HasForeignKey(meme => meme.CategoryId)
                       .OnDelete(DeleteBehavior.Restrict)
                       .IsRequired(true);
        }
    }
}
