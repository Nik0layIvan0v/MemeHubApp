namespace MemeHub.Database.EntityConfigurations
{
    using MemeHub.Database.Models;
    using Microsoft.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore.Metadata.Builders;

    public class ParentChildCommentEntityConfiguration : IEntityTypeConfiguration<ParentChildrenComment>
    {
        public void Configure(EntityTypeBuilder<ParentChildrenComment> parentChildCommentBuilder)
        {
            parentChildCommentBuilder.HasKey(key => new { key.ParentCommentId, key.ChildCommentId });
        }
    }
}
