using MMOnlineShop.Core.Domain.Category.MainCategories.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MMOnlineShop.Core.Domain.Category.Repositories
{
    public interface IMainCategoryCommandRepository
    {
        Task<Response> Create(MainCategory mainCategory);
        Task<Response> Update(MainCategory mainCategory);
        Task<Response> Delete(int id);
    }
}
