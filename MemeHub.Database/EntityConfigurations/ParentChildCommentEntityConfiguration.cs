namespace MemeHub.Database.EntityConfigurations
{
    using MemeHub.Database.Models;
    using Microsoft.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore.Metadata.Builders;
    using System;

    public class ParentChildCommentEntityConfiguration : IEntityTypeConfiguration<ParentChildrenComment>
    {
        public void Configure(EntityTypeBuilder<ParentChildrenComment> parentChildCommentBuilder)
        {
            parentChildCommentBuilder.HasKey(key => new { key.ParentCommentId, key.ChildCommentId });

            parentChildCommentBuilder.HasOne(parent => parent.ParentComment)
                                     .WithMany(comment => comment.ParentComments)
                                     .HasConstraintName("FK_Parent_Comments")
                                     .HasForeignKey(comment => comment.ParentCommentId)
                                     .OnDelete(DeleteBehavior.Restrict)
                                     .IsRequired(true);

            parentChildCommentBuilder.HasOne(children => children.ChildComment)
                                     .WithMany(comment => comment.ChildrenComments)
                                     .HasConstraintName("FK_Chidren_Comments")
                                     .HasForeignKey(comment => comment.ChildCommentId)
                                     .OnDelete(DeleteBehavior.Restrict)
                                     .IsRequired(true);
        }
    }
}
