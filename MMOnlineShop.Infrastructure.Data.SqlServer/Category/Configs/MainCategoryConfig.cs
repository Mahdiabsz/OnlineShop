using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using MMOnlineShop.Core.Domain.Category.MainCategories.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MMOnlineShop.Infrastructure.Data.SqlServer.Category.MainCategories.Configs
{
    public class MainCategoryConfig : IEntityTypeConfiguration<MainCategory>
    {
        public void Configure(EntityTypeBuilder<MainCategory> builder)
        {
            builder.Property(c => c.Title).IsRequired().HasMaxLength(30);
            builder.HasQueryFilter(c => c.IsActive.Equals(true));
            builder.HasQueryFilter(c => c.IsDeleted.Equals(false));
        }
    }
}
