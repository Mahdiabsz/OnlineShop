using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using MMOnlineShop.Core.Domain.Users.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MMOnlineShop.Infrastructure.Data.SqlServer.Users.Configs
{
    public class UserConfig : IEntityTypeConfiguration<User>
    {
        public void Configure(EntityTypeBuilder<User> builder)
        {
            builder.Property(c => c.UserName).HasMaxLength(15).IsRequired();
            builder.HasIndex(c => c.UserName).IsUnique();
            builder.Property(c => c.Email).HasMaxLength(100);
            builder.HasIndex(x => x.PhoneNumber).IsUnique();
            builder.HasIndex(c => c.Email).IsUnique();
        }
    }
}
