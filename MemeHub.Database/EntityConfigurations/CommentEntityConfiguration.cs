namespace MemeHub.Database.EntityConfigurations
{
    using MemeHub.Database.Models;
    using Microsoft.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore.Metadata.Builders;

    public class CommentEntityConfiguration : IEntityTypeConfiguration<Comment>
    {
        public void Configure(EntityTypeBuilder<Comment> commentBuilder)
        {
            commentBuilder.HasKey(comment => comment.Id);

            commentBuilder.Property(comment => comment.Id)
                          .UseIdentityColumn<int>(1, 1);

            commentBuilder.Property(comment => comment.Content)
                          .IsRequired(true);

            commentBuilder.Property(comment => comment.CreatedDate)
                          .IsRequired(true);

            commentBuilder.HasOne(comment => comment.Meme)
                          .WithMany(meme => meme.Comments)
                          .HasConstraintName("FK_Comments_Memes")
                          .HasForeignKey(meme => meme.MemeId)
                          .OnDelete(DeleteBehavior.Restrict)
                          .IsRequired(true);

            commentBuilder.HasOne(comment => comment.User)
                          .WithMany(user => user.Comments)
                          .HasConstraintName("FK_Comments_Users")
                          .HasForeignKey(x => x.UserId)
                          .OnDelete(DeleteBehavior.Restrict)
                          .IsRequired(true);
        }
    }
}
