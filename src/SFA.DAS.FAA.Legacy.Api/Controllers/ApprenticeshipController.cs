using MediatR;
using Microsoft.AspNetCore.Mvc;
using SFA.DAS.FAA.Legacy.Api.Common;
using SFA.DAS.FAA.Legacy.Application.Apprenticeship.Queries;

namespace SFA.DAS.FAA.Legacy.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ApprenticeshipController(ILogger<ApprenticeshipController> logger, IMediator mediator)
        : ActionResponseControllerBase
    {
        protected override string ControllerName => "apprenticeship";

        [HttpGet]
        [Route("{email}")]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(typeof(string), StatusCodes.Status404NotFound)]
        [ProducesResponseType(typeof(GetApprenticeshipsByEmailQueryResult), StatusCodes.Status200OK)]
        public async Task<IActionResult> Get(string email)
        {
            logger.LogInformation("FAA Legacy API: Received command to get all apprenticeships by user email: {email}",
                email);

            var response = await mediator.Send(new GetApprenticeshipsByEmailQuery(email));

            return GetResponse(response);
        }
    }
}