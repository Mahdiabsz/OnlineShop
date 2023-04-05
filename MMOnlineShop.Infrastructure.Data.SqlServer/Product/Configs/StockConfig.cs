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
    public class StockConfig : IEntityTypeConfiguration<Stock>
    {
        public void Configure(EntityTypeBuilder<Stock> builder)
        {
            builder.HasQueryFilter(c => c.IsActive.Equals(true));
            builder.HasQueryFilter(c => c.IsDeleted.Equals(false));
            builder.HasOne(c => c.Product).WithMany(c => c.Stocks).HasForeignKey(c => c.ProductId).OnDelete(DeleteBehavior.Restrict);
            builder.Property(c => c.DetailValueArray).HasMaxLength(50).IsRequired();
            builder.Property(c => c.Inventory).IsRequired();

        }
    }
}
