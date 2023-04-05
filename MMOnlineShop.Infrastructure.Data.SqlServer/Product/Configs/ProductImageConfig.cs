using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MMOnlineShop.Core.Domain.Products.Entities;

namespace MMOnlineShop.Infrastructure.Data.SqlServer.Products.Configs
{
    public class ProductImageConfig : IEntityTypeConfiguration<ProductImage>
    {
        public void Configure(EntityTypeBuilder<ProductImage> builder)
        {
            builder.HasQueryFilter(c => c.IsActive.Equals(true));
            builder.HasQueryFilter(c => c.IsDeleted.Equals(false));
            builder.HasOne(c => c.Product).WithMany(c => c.ProductImages).HasForeignKey(c => c.ProductId).OnDelete(DeleteBehavior.Restrict);
            builder.Property(c => c.Location).HasMaxLength(150).IsRequired();
            builder.Property(c => c.IsMain).IsRequired();

        }
    }
}
