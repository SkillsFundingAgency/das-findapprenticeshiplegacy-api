using MediatR;
using Microsoft.AspNetCore.Mvc;
using SFA.DAS.FAA.Legacy.Api.Common;
using SFA.DAS.FAA.Legacy.Application.Health.Queries;

namespace SFA.DAS.FAA.Legacy.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SystemController : ActionResponseControllerBase
    {
        private readonly ILogger<SystemController> _logger;
        private readonly IMediator _mediator;

        public override string ControllerName => "System";

        public SystemController(ILogger<SystemController> logger, IMediator mediator)
        {
            _logger = logger;
            _mediator = mediator;
        }

        [HttpGet]
        [Route("/health")]
        [ProducesResponseType(typeof(GetHealthStatusResult), StatusCodes.Status200OK)]
        public async Task<IActionResult> GetHealth()
        {
            var response = await _mediator.Send(new GetHealthStatusQuery());
            return new OkObjectResult(response);
        }
    }
}
