using MMOnlineShop.Core.Domain.Category.MainCategories.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MMOnlineShop.Core.Domain.Category.Repositories
{
    public interface IMainCategoryQueryRepository
    {
        Task<Response> GetById(int id);
        Task<MainCategory> GetEntityById(int id);
        Task<Response> GetAll();

    }
}
