﻿namespace MemeHub.Database.EntityConfigurations
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
                           .UseIdentityColumn<int>(0, 1);

            categoryBuilder.Property(category => category.CategoryName)
                           .IsRequired(true);

            categoryBuilder.HasMany(category => category.Memes)
                           .WithOne(meme => meme.Category)
                           .HasConstraintName("FK_Categories_Memes")
                           .HasForeignKey(meme => meme.CategoryId)
                           .OnDelete(DeleteBehavior.Restrict)
                           .IsRequired(true);
        }
    }
}
