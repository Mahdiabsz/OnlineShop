using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using MMOnlineShop.Core.Domain.Category.MainCategories.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MMOnlineShop.Core.Domain.Category.SubCategories.Entities;

namespace MMOnlineShop.Infrastructure.Data.SqlServer.Category.SubCategories.Configs
{
    public class SubCategoryConfig : IEntityTypeConfiguration<SubCategory>
    {
        public void Configure(EntityTypeBuilder<SubCategory> builder)
        {
            builder.Property(c => c.Title).IsRequired().HasMaxLength(30);
            builder.HasOne(c => c.MainCategory).WithMany(c => c.SubCategories).HasForeignKey(c => c.MainCategoryId).OnDelete(DeleteBehavior.Restrict);
            builder.HasQueryFilter(c => c.IsActive.Equals(true));
            builder.HasQueryFilter(c => c.IsDeleted.Equals(false));
        }
    }
}
