using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using MMOnlineShop.Core.Domain.Category.MainCategories.Entities;
using MMOnlineShop.Core.Domain.Category.SubCategories.Entities;
using MMOnlineShop.Core.Domain.Category.SubCategoryDetails.Entities;
using MMOnlineShop.Core.Domain.Category.SubCategoryDetailValues.Entities;
using MMOnlineShop.Core.Domain.Products.Entities;
using MMOnlineShop.Core.Domain.Sales.Entities;
using MMOnlineShop.Core.Domain.Support.Entities;
using MMOnlineShop.Core.Domain.Users.Entities;

namespace MMOnlineShop.Infrastructure.Data.SqlServer
{
    public class MMOnlineShopDataContext : IdentityDbContext<User, Role, int, IdentityUserClaim<int>, UserRole, IdentityUserLogin<int>, IdentityRoleClaim<int>, IdentityUserToken<int>>
    {
        protected readonly IConfiguration Configuration;
        public MMOnlineShopDataContext(DbContextOptions<MMOnlineShopDataContext> options, IConfiguration configuration) : base(options)
        {
            Configuration = configuration;
        }

        #region Category
        
        public DbSet<MainCategory> MainCategory { get; set; }
        public DbSet<SubCategory> SubCategory { get; set; }
        public DbSet<SubCategoryDetail> SubCategoryDetail { get; set; }
        public DbSet<SubCategoryDetailValue> SubCategoryDetailValue { get; set; }

        #endregion

        #region Product

        public DbSet<Product> Product { get; set; }
        public DbSet<ProductImage> ProductImage { get; set; }
        public DbSet<Stock> Stock { get; set; }
        public DbSet<Discount> Discount { get; set; }
        public DbSet<Comment> Comment { get; set; }
        public DbSet<Rate> Rate { get; set; }

        #endregion

        #region Sale

        public DbSet<Sale> Sale { get; set; }
        public DbSet<SaleDetail> SaleDetail { get; set; }
        public DbSet<Cart> Cart { get; set; }

        #endregion

        #region Support

        public DbSet<Ticket> Ticket { get; set; }
        public DbSet<TicketMessage> TicketMessage { get; set; }

        #endregion

        #region User

        public DbSet<Favorite> Favorite { get; set; }

        #endregion

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);
            optionsBuilder.UseSqlServer(Configuration.GetConnectionString("ConnStr"));
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(GetType().Assembly);
            base.OnModelCreating(modelBuilder);

            #region Identity
            modelBuilder.Entity<User>(entity => { entity.ToTable(name: "User", schema: "usr"); });
            modelBuilder.Entity<Role>(entity => { entity.ToTable(name: "Role", schema: "usr"); });
            modelBuilder.Entity<UserRole>(entity => { entity.ToTable("UserRole", schema: "usr"); });
            modelBuilder.Entity<IdentityUserClaim<int>>(entity => { entity.ToTable("UserClaim", schema: "usr"); });
            modelBuilder.Entity<IdentityUserLogin<int>>(entity => { entity.ToTable("UserLogin", schema: "usr"); });
            modelBuilder.Entity<IdentityUserToken<int>>(entity => { entity.ToTable("UserToken", schema: "usr"); });
            modelBuilder.Entity<IdentityRoleClaim<int>>(entity => { entity.ToTable("RoleClaim", schema: "usr"); });
            #endregion

            #region Seed Identity
            //seed admin role
            modelBuilder.Entity<Role>().HasData(new Role
            {
                Name = "Admin",
                NormalizedName = "Admin",
                Id = 1,
                ConcurrencyStamp = Guid.NewGuid().ToString()
            });
            modelBuilder.Entity<Role>().HasData(new Role
            {
                Name = "Customer",
                NormalizedName = "Customer",
                Id = 2,
                ConcurrencyStamp = Guid.NewGuid().ToString()
            });

            //create user
            var user = new User
            {
                Id = 1,
                Email = "mahdiabbaszadeh1376@gmail.com",
                EmailConfirmed = true,
                FirstName = "Admin",
                LastName = "Admin",
                UserName = "admin",
             NormalizedUserName = "admin"
            };

            //set user password
            PasswordHasher<User> ph = new PasswordHasher<User>();
            user.PasswordHash = ph.HashPassword(user, "ma5323102");

            //seed user
            modelBuilder.Entity<User>().HasData(user);

            //set user role to admin
            modelBuilder.Entity<UserRole>().HasData(new UserRole
            {
                RoleId = 1,
                UserId = 1
            });

            #endregion
        }
    }
}
