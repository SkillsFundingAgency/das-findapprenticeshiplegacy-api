using MediatR;
using Microsoft.AspNetCore.Mvc;
using SFA.DAS.FAA.Legacy.Api.Common;
using SFA.DAS.FAA.Legacy.Application.User.Queries;

namespace SFA.DAS.FAA.Legacy.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ActionResponseControllerBase
    {
        private readonly ILogger<UserController> _logger;
        private readonly IMediator _mediator;

        public override string ControllerName => "User";

        public UserController(ILogger<UserController> logger, IMediator mediator)
        {
            _logger = logger;
            _mediator = mediator;
        }

        [HttpGet]
        [Route("/{email}")]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(typeof(string), StatusCodes.Status404NotFound)]
        [ProducesResponseType(typeof(GetUserByEmailResult), StatusCodes.Status200OK)]
        public async Task<IActionResult> Get(string email)
        {
            _logger.LogInformation("FAA Legacy API: Received command to get user by email: {email}", email);

            var response = await _mediator.Send(new GetUserByEmailQuery(email));

            return GetResponse(response);
        }
    }
}
