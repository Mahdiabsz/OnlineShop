using MMOnlineShop.Common.Commands;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MMOnlineShop.Core.Domain.Category.Commands.MainCategory
{
    public class MainCategoryCreateCommand : ICommand
    {
        public string Title { get; set; }
    }
}
