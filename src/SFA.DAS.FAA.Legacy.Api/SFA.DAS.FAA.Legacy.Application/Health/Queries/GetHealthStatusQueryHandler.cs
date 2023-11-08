using MediatR;
using SFA.DAS.FAA.Legacy.Domain.Interfaces.Repositories;

namespace SFA.DAS.FAA.Legacy.Application.Health.Queries
{
    public class GetHealthStatusQueryHandler : IRequestHandler<GetHealthStatusQuery, GetHealthStatusResult>
    {
        private readonly IHealthStatusRepository _healthStatusRepository;

        public GetHealthStatusQueryHandler(IHealthStatusRepository healthStatusRepository)
            => _healthStatusRepository = healthStatusRepository;

        public async Task<GetHealthStatusResult> Handle(GetHealthStatusQuery request, CancellationToken cancellationToken)
        {
            return await _healthStatusRepository.IsHealthy();
        }
    }
}
