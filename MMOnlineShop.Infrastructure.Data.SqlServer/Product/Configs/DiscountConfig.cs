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
    public class DiscountConfig : IEntityTypeConfiguration<Discount>
    {
        public void Configure(EntityTypeBuilder<Discount> builder)
        {
            builder.HasQueryFilter(c => c.IsActive.Equals(true));
            builder.HasQueryFilter(c => c.IsDeleted.Equals(false));
            builder.HasOne(c => c.Product).WithMany(c => c.Discounts).HasForeignKey(c => c.ProductId).OnDelete(DeleteBehavior.Restrict);
            builder.Property(c => c.Description).HasMaxLength(400).IsRequired();
            builder.Property(c => c.Percent).IsRequired();
            builder.Property(c => c.StartDate).IsRequired();
            builder.Property(c => c.EndDate).IsRequired();
        }
    }
}
