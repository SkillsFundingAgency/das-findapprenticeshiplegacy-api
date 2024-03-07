using MediatR;
using SFA.DAS.FAA.Legacy.Application.Mediatr.Responses;

namespace SFA.DAS.FAA.Legacy.Application.Apprenticeship.Queries;

public record GetApprenticeshipsByEmailQuery(string Email)
    : IRequest<ValidatedResponse<GetApprenticeshipsByEmailQueryResult>>
{
}