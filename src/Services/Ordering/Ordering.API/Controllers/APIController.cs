using MediatR;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ordering.API.Controllers
{
    [Route("api/v{version:apiVersion}/[controller]")]
    [ApiController]
    public class APIController : ControllerBase
    {
        private IMediator? _mediatr;
        public IMediator Mediator => _mediatr ??= HttpContext.RequestServices.GetRequiredService<IMediator>();
    }
}
