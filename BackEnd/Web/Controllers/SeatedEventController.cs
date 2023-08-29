using Infrastructure.Data;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Web.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class SeatedEventController : Controller
    {
        private readonly IMediator _mediator;

        public SeatedEventController( IMediator mediator)
        {
            _mediator = mediator;
        }

    }
}
