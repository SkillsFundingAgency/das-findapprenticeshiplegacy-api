using MediatR;
using Microsoft.AspNetCore.Mvc;
using SFA.DAS.FAA.Legacy.Api.Common;
using SFA.DAS.FAA.Legacy.Application.Apprenticeship.Queries;

namespace SFA.DAS.FAA.Legacy.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ApprenticeshipsController : ActionResponseControllerBase
    {
        private readonly ILogger<ApprenticeshipsController> _logger;
        private readonly IMediator _mediator;

        public override string ControllerName => "Apprenticeships";

        public ApprenticeshipsController(ILogger<ApprenticeshipsController> logger, IMediator mediator)
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
