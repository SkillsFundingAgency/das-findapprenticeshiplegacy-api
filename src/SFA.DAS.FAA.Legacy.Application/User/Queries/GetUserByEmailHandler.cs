using MediatR;
using SFA.DAS.FAA.Legacy.Application.Mediatr.Responses;
using SFA.DAS.FAA.Legacy.Domain.Interfaces.Repositories;

namespace SFA.DAS.FAA.Legacy.Application.User.Queries
{
    public class GetUserByEmailHandler : IRequestHandler<GetUserByEmailQuery, ValidatedResponse<GetUserByEmailResult>>
    {
        private readonly IUserReadRepository _userReadRepository;
        private readonly ICandidateReadRepository _candidateReadRepository;

        public GetUserByEmailHandler(
            IUserReadRepository userReadRepository,
            ICandidateReadRepository candidateReadRepository)
        {
            _userReadRepository = userReadRepository;
            _candidateReadRepository = candidateReadRepository;
        }

        public Task<ValidatedResponse<GetUserByEmailResult>> Handle(GetUserByEmailQuery request, CancellationToken cancellationToken)
        {
            var user = _userReadRepository.Get(request.Email);
            if (user is null) return Task.FromResult(ValidatedResponse<GetUserByEmailResult>.EmptySuccessResponse());
            
            var candidate = _candidateReadRepository.Get(user.EntityId);
            return Task.FromResult(new ValidatedResponse<GetUserByEmailResult>(new GetUserByEmailResult
            {
                Username = user.Username,
                AccountUnlockCode = user.AccountUnlockCode,
                ActivationCode = user.ActivationCode,
                AccountUnlockCodeExpiry = user.AccountUnlockCodeExpiry,
                LastActivity = user.LastActivity,
                PendingUsername = user.PendingUsername,
                ActivateCodeExpiry = user.ActivateCodeExpiry,
                ActivationDate = user.ActivationDate,
                LastLogin = user.LastLogin,
                LoginIncorrectAttempts = user.LoginIncorrectAttempts,
                PasswordResetCode = user.PasswordResetCode,
                PasswordResetCodeExpiry = user.PasswordResetCodeExpiry,
                PasswordResetIncorrectAttempts = user.PasswordResetIncorrectAttempts,
                PendingUsernameCode = user.PendingUsernameCode,
                Roles = user.Roles,
                Status = user.Status,
                RegistrationDetails = candidate?.RegistrationDetails,
                ApplicationTemplate = candidate?.ApplicationTemplate,
                CommunicationPreferences = candidate?.CommunicationPreferences,
                HelpPreferences = candidate?.HelpPreferences,
                LegacyCandidateId = candidate?.LegacyCandidateId,
                MonitoringInformation = candidate?.MonitoringInformation,
                SubscriberId = candidate?.SubscriberId
            }));
        }
    }
}
