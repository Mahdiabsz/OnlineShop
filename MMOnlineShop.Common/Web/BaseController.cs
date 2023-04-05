using MMOnlineShop.Common.Commands;
using MMOnlineShop.Common.Queries;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MMOnlineShop.Common.Web
{
    public class BaseController : ControllerBase
    {
        protected readonly CommandDispatcher _commandDispatcher;
        protected readonly QueryDispatcher _queryDispatcher;
        protected readonly IHttpContextAccessor _httpContextAccessor;

        public BaseController(
            CommandDispatcher commandDispatcher,
            QueryDispatcher queryDispatcher)
        {
            _commandDispatcher = commandDispatcher;
            _queryDispatcher = queryDispatcher;
        }
    }
}

