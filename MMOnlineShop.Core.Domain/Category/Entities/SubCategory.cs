using MMOnlineShop.Core.Domain.Category.MainCategories.Entities;
using MMOnlineShop.Core.Domain.Category.SubCategoryDetails.Entities;
using MMOnlineShop.Common.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MMOnlineShop.Core.Domain.Products.Entities;

namespace MMOnlineShop.Core.Domain.Category.SubCategories.Entities
{
    public class SubCategory : BaseEntity
    {
        public string Title { get; set; }
        public int MainCategoryId { get; set; }
        public MainCategory MainCategory { get; set; }
        public List<SubCategoryDetail> SubCategoryDetails { get; set; }
        public List<Product> Products { get; set; }
    }
}
