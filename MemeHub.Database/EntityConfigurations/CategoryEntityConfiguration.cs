namespace MemeHub.Database.EntityConfigurations
{
    using MemeHub.Database.Models;
    using Microsoft.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore.Metadata.Builders;

    public class CategoryEntityConfiguration : IEntityTypeConfiguration<Category>
    {
        public void Configure(EntityTypeBuilder<Category> categoryBuilder)
        {
            categoryBuilder.HasKey(category => category.Id);

            categoryBuilder.Property(category => category.Id)
                           .UseIdentityColumn<int>(1, 1);

            categoryBuilder.Property(category => category.CategoryName)
                           .IsUnicode(true)
                           .IsRequired(true);
        }
    }
}
