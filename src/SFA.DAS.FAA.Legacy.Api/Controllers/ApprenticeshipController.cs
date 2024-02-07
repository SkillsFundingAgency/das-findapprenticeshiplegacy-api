using MediatR;
using Microsoft.AspNetCore.Mvc;
using SFA.DAS.FAA.Legacy.Api.Common;
using SFA.DAS.FAA.Legacy.Application.Apprenticeship.Queries;

namespace SFA.DAS.FAA.Legacy.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ApprenticeshipController : ActionResponseControllerBase
    {
        private readonly ILogger<ApprenticeshipController> _logger;
        private readonly IMediator _mediator;

        public override string ControllerName => "apprenticeship";

        public ApprenticeshipController(ILogger<ApprenticeshipController> logger, IMediator mediator)
        {
            _logger = logger;
            _mediator = mediator;
        }

        [HttpGet]
        [Route("{email}")]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(typeof(string), StatusCodes.Status404NotFound)]
        [ProducesResponseType(typeof(GetApprenticeshipsByEmailQueryResult), StatusCodes.Status200OK)]
        public async Task<IActionResult> Get(string email)
        {
            _logger.LogInformation("FAA Legacy API: Received command to get all apprenticeships by user email: {email}", email);

            var response = await _mediator.Send(new GetApprenticeshipsByEmailQuery(email));

            return Ok(response);
        }
    }
}
