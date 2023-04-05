using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using MMOnlineShop.Core.Domain.Products.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MMOnlineShop.Core.Domain.Users.Entities;

namespace MMOnlineShop.Infrastructure.Data.SqlServer.Users.Configs
{
    public class FavoriteConfig : IEntityTypeConfiguration<Favorite>
    {
        public void Configure(EntityTypeBuilder<Favorite> builder)
        {
            builder.HasQueryFilter(c => c.IsActive.Equals(true));
            builder.HasQueryFilter(c => c.IsDeleted.Equals(false));
            builder.HasOne(c => c.User).WithMany(c => c.Favorites).HasForeignKey(c => c.UserId).OnDelete(DeleteBehavior.Restrict);
            builder.HasOne(c => c.Product).WithMany(c => c.Favorites).HasForeignKey(c => c.ProductId).OnDelete(DeleteBehavior.Restrict);
        }
    }
}
