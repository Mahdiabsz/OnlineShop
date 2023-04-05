using MMOnlineShop.Core.Domain.Category.SubCategories.Entities;
using MMOnlineShop.Core.Domain.Category.SubCategoryDetails.Enums;
using MMOnlineShop.Core.Domain.Category.SubCategoryDetailValues.Entities;
using MMOnlineShop.Common.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MMOnlineShop.Core.Domain.Category.SubCategoryDetails.Entities
{
    public class SubCategoryDetail : BaseEntity
    {
        public string Title { get; set; }
        public int SubCategoryId { get; set; }
        public SubCategory SubCategory { get; set; }
        public SubCategoryDetailType Type { get; set; }
        public List<SubCategoryDetailValue> SubCategoryDetailValues { get; set; }
    }
}
