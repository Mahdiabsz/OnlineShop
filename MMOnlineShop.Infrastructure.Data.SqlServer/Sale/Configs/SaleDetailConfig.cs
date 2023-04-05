using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MMOnlineShop.Core.Domain.Sales.Entities;

namespace MMOnlineShop.Infrastructure.Data.SqlServer.Sales.Configs
{
    public class SaleDetailConfig : IEntityTypeConfiguration<SaleDetail>
    {
        public void Configure(EntityTypeBuilder<SaleDetail> builder)
        {
            builder.HasQueryFilter(c => c.IsActive.Equals(true));
            builder.HasQueryFilter(c => c.IsDeleted.Equals(false));
            builder.HasOne(c => c.Sale).WithMany(c => c.SaleDetails).HasForeignKey(c => c.SaleId).OnDelete(DeleteBehavior.Restrict);
            builder.HasOne(c => c.Stock).WithMany(c => c.SaleDetails).HasForeignKey(c => c.StockId).OnDelete(DeleteBehavior.Restrict);
            builder.Property(c => c.Number).IsRequired();
        }
    }
}
