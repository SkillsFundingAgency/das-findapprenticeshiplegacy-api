using MediatR;
using SFA.DAS.FAA.Legacy.Application.Mediatr.Responses;

namespace SFA.DAS.FAA.Legacy.Application.User.Queries
{
    public record GetUserByEmailQuery(string Email) : IRequest<ValidatedResponse<GetUserByEmailResult>>
    {

    }
}
