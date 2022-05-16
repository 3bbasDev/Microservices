using Discount.API.Repositories;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Discount.API.Controllers
{
    [Route("api/v{version:apiVersion}/[controller]")]
    [ApiController]
    public class APIController : ControllerBase
    {
        private readonly IDiscountRepository _discount;

        public APIController(IDiscountRepository discount)
        {
            _discount = discount;
        }

        public IDiscountRepository Discount => _discount;
    }
}
