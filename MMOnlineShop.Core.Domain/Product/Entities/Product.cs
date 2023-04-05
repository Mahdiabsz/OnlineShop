using MMOnlineShop.Common.Domain;
using MMOnlineShop.Core.Domain.Category.SubCategories.Entities;
using MMOnlineShop.Core.Domain.Users.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MMOnlineShop.Core.Domain.Products.Entities
{
    public class Product : BaseEntity
    {
        public string Title { get; set; }
        public string Description { get; set; }
        public decimal Price { get; set; }
        public int SubCategoryId { get; set; }
        public SubCategory SubCategory { get; set; }
        public List<Stock> Stocks { get; set; }
        public List<ProductImage> ProductImages { get; set; }
        public List<Discount> Discounts { get; set; }
        public List<Comment> Comments { get; set; }
        public List<Rate> Rates { get; set; }
        public List<Favorite> Favorites { get; set; }
    }
}
