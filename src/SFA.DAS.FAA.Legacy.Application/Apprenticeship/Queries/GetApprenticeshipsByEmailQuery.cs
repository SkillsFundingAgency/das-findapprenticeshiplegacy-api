using MediatR;

namespace SFA.DAS.FAA.Legacy.Application.Apprenticeship.Queries
{
    public record GetApprenticeshipsByEmailQuery(string Email) : IRequest<GetApprenticeshipsByEmailQueryResult>
    {

    }
}
