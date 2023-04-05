using MMOnlineShop.Core.Domain.Category.SubCategoryDetails.Entities;
using MMOnlineShop.Common.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MMOnlineShop.Core.Domain.Category.SubCategoryDetailValues.Entities
{
    public class SubCategoryDetailValue : BaseEntity
    {
        public string Value { get; set; }
        public int SubCategoryDetailId { get; set; }
        public SubCategoryDetail SubCategoryDetail { get; set; }
    }
}
