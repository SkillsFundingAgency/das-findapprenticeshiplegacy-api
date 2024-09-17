using MediatR;
using SFA.DAS.FAA.Legacy.Application.Mediatr.Responses;

namespace SFA.DAS.FAA.Legacy.Application.User.Queries
{
    public class ValidateUserCredentialsQuery : IRequest<ValidatedResponse<ValidateUserCredentialsQueryResult>>
    {
        public required string Email { get; set; }
        public required string Password { get; set; }
    }
}
