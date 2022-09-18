namespace MemeHub.Database.EntityConfigurations
{
    using MemeHub.Database.Models;
    using Microsoft.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore.Metadata.Builders;

    public class LabelEntityConfiguration : IEntityTypeConfiguration<Label>
    {
        public void Configure(EntityTypeBuilder<Label> labelBuilder)
        {
            labelBuilder.HasKey(label => label.Id);

            labelBuilder.Property(label => label.Id)
                        .UseIdentityColumn<int>(0, 1);

            labelBuilder.Property(label => label.Name)
                        .IsUnicode(true)
                        .IsRequired(true);

            labelBuilder.HasMany(label => label.Memes)
                        .WithOne(meme => meme.Label)
                        .HasConstraintName("FK_Labels_Memes")
                        .HasForeignKey(meme => meme.LabelId)
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired(false);
        }
    }
}
