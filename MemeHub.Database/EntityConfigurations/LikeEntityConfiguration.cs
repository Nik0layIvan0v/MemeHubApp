namespace MemeHub.Database.EntityConfigurations
{
    using MemeHub.Database.Models;
    using Microsoft.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore.Metadata.Builders;

    public class LikeEntityConfiguration : IEntityTypeConfiguration<Like>
    {
        public void Configure(EntityTypeBuilder<Like> likeBuilder)
        {
            likeBuilder.HasKey(like => like.Id);

            likeBuilder.Property(like => like.Id)
                       .UseIdentityColumn<int>(1, 1);

            likeBuilder.Property(like => like.LikedAt)
                       .IsRequired(true);

            likeBuilder.Property(like => like.Type)
                       .IsUnicode(true)
                       .IsRequired(true);

            likeBuilder.HasOne(like => like.User)
                       .WithMany(user => user.Likes)
                       .HasConstraintName("FK_Likes_Users")
                       .HasForeignKey(like => like.UserId)
                       .OnDelete(DeleteBehavior.Restrict)
                       .IsRequired(false);

            likeBuilder.HasOne(like => like.Meme)
                       .WithMany(meme => meme.Likes)
                       .HasConstraintName("FK_Likes_Memes")
                       .HasForeignKey(like => like.MemeId)
                       .OnDelete(DeleteBehavior.Restrict)
                       .IsRequired(false);

            likeBuilder.HasOne(like => like.Comment)
                       .WithMany(comment => comment.Likes)
                       .HasConstraintName("FK_Likes_Comments")
                       .HasForeignKey(like => like.CommentId)
                       .OnDelete(DeleteBehavior.Restrict)
                       .IsRequired(false);
        }
    }
}
