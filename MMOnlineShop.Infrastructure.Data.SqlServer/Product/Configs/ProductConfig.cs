using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using MMOnlineShop.Core.Domain.Products.Entities;

namespace MMOnlineShop.Infrastructure.Data.SqlServer.Products.Configs
{
    public class ProductConfig : IEntityTypeConfiguration<Product>
    {
        public void Configure(EntityTypeBuilder<Product> builder)
        {
            builder.Property(c => c.Title).IsRequired().HasMaxLength(50);
            builder.HasQueryFilter(c => c.IsActive.Equals(true));
            builder.HasQueryFilter(c => c.IsDeleted.Equals(false));
            builder.HasOne(c => c.SubCategory).WithMany(c => c.Products).HasForeignKey(c => c.SubCategoryId).OnDelete(DeleteBehavior.Restrict);
            builder.Property(c => c.Description).HasMaxLength(400).IsRequired();
            builder.Property(c => c.Price).IsRequired();

        }
    }
}
