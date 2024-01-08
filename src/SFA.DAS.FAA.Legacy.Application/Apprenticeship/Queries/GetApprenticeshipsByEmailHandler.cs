using MediatR;
using SFA.DAS.FAA.Legacy.Domain.Interfaces.Repositories;

namespace SFA.DAS.FAA.Legacy.Application.Apprenticeship.Queries
{
    public class GetApprenticeshipsByEmailHandler : IRequestHandler<GetApprenticeshipsByEmailQuery, GetApprenticeshipsByEmailQueryResult>
    {
        private readonly IApprenticeshipsReadRepository _apprenticeshipsReadRepository;

        public GetApprenticeshipsByEmailHandler(IApprenticeshipsReadRepository apprenticeshipsReadRepository)
        {
            _apprenticeshipsReadRepository = apprenticeshipsReadRepository;
        }

        public Task<GetApprenticeshipsByEmailQueryResult> Handle(GetApprenticeshipsByEmailQuery request, CancellationToken cancellationToken)
        {
            var apprenticeships = _apprenticeshipsReadRepository.Get(request.Email);

            return Task.FromResult(new GetApprenticeshipsByEmailQueryResult
            {
                ApprenticeshipResults = apprenticeships.Select(app => (ApprenticeshipResult)app).ToList()
            });
        }
    }
}
