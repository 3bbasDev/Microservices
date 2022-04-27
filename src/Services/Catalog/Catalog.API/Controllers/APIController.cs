using Catalog.API.Data;
using Catalog.API.Repositories;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Catalog.API.Controllers
{
    [Route("api/v{version:apiVersion}/[controller]")]
    [ApiController]
    public class APIController : ControllerBase
    {
        private readonly IProductRepository _product;
        private readonly ICatalogContext _context;
        private readonly ILogger<APIController> _logger;
        public APIController(ICatalogContext context, ILogger<APIController> logge)
        {
            _context = context ?? throw new ArgumentNullException(nameof(context));
            _logger = logge ?? throw new ArgumentNullException(nameof(logge));
            _product = new ProductRepository(context);
        }

        public IProductRepository Product => _product ?? new ProductRepository(_context);
    }
}
