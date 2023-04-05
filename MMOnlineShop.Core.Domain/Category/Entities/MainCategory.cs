using MMOnlineShop.Core.Domain.Category.SubCategories.Entities;
using MMOnlineShop.Common.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MMOnlineShop.Core.Domain.Category.MainCategories.Entities
{
    public class MainCategory : BaseEntity
    {
        public string Title { get; set; }
        public List<SubCategory> SubCategories { get; set; }
    }
}
