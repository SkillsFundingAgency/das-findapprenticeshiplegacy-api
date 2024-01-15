using FluentValidation;
using MediatR;
using SFA.DAS.FAA.Legacy.Application.Mediatr.Responses;
using SFA.DAS.FAA.Legacy.Domain.Interfaces.Repositories;

namespace SFA.DAS.FAA.Legacy.Application.Apprenticeship.Queries;

public class GetApprenticeshipsByEmailHandler(
    IApprenticeshipsReadRepository apprenticeshipsReadRepository,
    IValidator<GetApprenticeshipsByEmailQuery> validator)
    : IRequestHandler<GetApprenticeshipsByEmailQuery, ValidatedResponse<GetApprenticeshipsByEmailQueryResult>>
{
    public Task<ValidatedResponse<GetApprenticeshipsByEmailQueryResult>> Handle(GetApprenticeshipsByEmailQuery request,
        CancellationToken cancellationToken)
    {
        validator.ValidateAndThrow(request);

        var apprenticeships = apprenticeshipsReadRepository.Get(request.Email).ToList();

        return Task.FromResult(apprenticeships.Count == 0
            ? ValidatedResponse<GetApprenticeshipsByEmailQueryResult>.EmptySuccessResponse()
            : new ValidatedResponse<GetApprenticeshipsByEmailQueryResult>(
                new GetApprenticeshipsByEmailQueryResult
                {
                    Count = apprenticeships.Count,
                    Apprenticeships = apprenticeships.Select(app => (ApprenticeshipResult) app).ToList(),
                }));
    }
}