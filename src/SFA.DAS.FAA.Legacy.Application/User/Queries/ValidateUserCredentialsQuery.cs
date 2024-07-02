using MediatR;
using SFA.DAS.FAA.Legacy.Application.Mediatr.Responses;

namespace SFA.DAS.FAA.Legacy.Application.User.Queries
{
    public class ValidateUserCredentialsQuery : IRequest<ValidatedResponse<ValidateUserCredentialsQueryResult>>
    {
        public string Email { get; set; }
        public string Password { get; set; }
    }
}
