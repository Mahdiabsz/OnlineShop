using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using MMOnlineShop.Core.Domain.Sales.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MMOnlineShop.Infrastructure.Data.SqlServer.Sales.Configs
{
    public class CartConfig : IEntityTypeConfiguration<Cart>
    {
        public void Configure(EntityTypeBuilder<Cart> builder)
        {
            builder.HasQueryFilter(c => c.IsActive.Equals(true));
            builder.HasQueryFilter(c => c.IsDeleted.Equals(false));
            builder.HasOne(c => c.User).WithMany(c => c.Carts).HasForeignKey(c => c.UserId).OnDelete(DeleteBehavior.Restrict);
            builder.HasOne(c => c.Stock).WithMany(c => c.Carts).HasForeignKey(c => c.StockId).OnDelete(DeleteBehavior.Restrict);
            builder.Property(c => c.Number).IsRequired();
        }
    }
}
