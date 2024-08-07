﻿using MediatR;
using Microsoft.AspNetCore.Mvc;
using SFA.DAS.FAA.Legacy.Api.Common;
using SFA.DAS.FAA.Legacy.Application.User.Queries;

namespace SFA.DAS.FAA.Legacy.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController(ILogger<UserController> logger, IMediator mediator) : ActionResponseControllerBase
    {
        protected override string ControllerName => "User";

        [HttpGet]
        [Route("{email}")]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(typeof(string), StatusCodes.Status404NotFound)]
        [ProducesResponseType(typeof(GetUserByEmailResult), StatusCodes.Status200OK)]
        public async Task<IActionResult> Get(string email)
        {
            logger.LogInformation("FAA Legacy API: Received command to get user by email: {email}", email);

            var response = await mediator.Send(new GetUserByEmailQuery(email));

            return GetResponse(response);
        }

        [HttpGet]
        [Route("validate-credentials")]
        public async Task<IActionResult> ValidateCredentials([FromQuery]string email, [FromQuery] string password)
        {
            var response = await mediator.Send(new ValidateUserCredentialsQuery
            {
                Email = email,
                Password = password
            });

            return GetResponse(response);
        }
    }
}