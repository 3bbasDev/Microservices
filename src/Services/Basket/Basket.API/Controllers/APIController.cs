using Basket.API.Repositories;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Basket.API.Controllers
{
    [Route("api/v{version:apiVersion}/[controller]")]
    [ApiController]
    public class APIController : ControllerBase
    {
        private readonly IBasketRepository _basket;

        public APIController(IBasketRepository basket)
        {
            _basket = basket;
        }

        public IBasketRepository Basket => _basket;
    }
}
