using FluentValidation;
using MediatR;
using SFA.DAS.FAA.Legacy.Application.Mediatr.Responses;
using SFA.DAS.FAA.Legacy.Domain.Interfaces.Repositories;

namespace SFA.DAS.FAA.Legacy.Application.User.Queries
{
    public class GetUserByEmailHandler(
        IUserReadRepository userReadRepository,
        ICandidateReadRepository candidateReadRepository,
        IValidator<GetUserByEmailQuery> validator)
        : IRequestHandler<GetUserByEmailQuery, ValidatedResponse<GetUserByEmailResult>>
    {
        public Task<ValidatedResponse<GetUserByEmailResult>> Handle(GetUserByEmailQuery request,
            CancellationToken cancellationToken)
        {
            validator.ValidateAndThrow(request);

            var user = userReadRepository.Get(request.Email);
            if (user is null) return Task.FromResult(ValidatedResponse<GetUserByEmailResult>.EmptySuccessResponse());

            var result = (GetUserByEmailResult)user;
            var candidate = candidateReadRepository.Get(request.Email);
            result.RegistrationDetails = candidate?.RegistrationDetails;
            result.CommunicationPreferences = candidate?.CommunicationPreferences;

            return Task.FromResult(new ValidatedResponse<GetUserByEmailResult>(result));
        }
    }
}