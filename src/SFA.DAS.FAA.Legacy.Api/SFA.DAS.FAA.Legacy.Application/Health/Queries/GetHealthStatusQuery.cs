using MediatR;

namespace SFA.DAS.FAA.Legacy.Application.Health.Queries
{
    public record GetHealthStatusQuery : IRequest<GetHealthStatusResult>;
}
