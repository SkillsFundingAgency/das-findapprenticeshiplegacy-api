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
            if (user is null)
            {
                return Task.FromResult(ValidatedResponse<GetUserByEmailResult>.EmptySuccessResponse());
            }

            var candidate = candidateReadRepository.Get(request.Email);

            var result = new GetUserByEmailResult
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
                CommunicationPreferences = candidate?.CommunicationPreferences,
            };

            return Task.FromResult(new ValidatedResponse<GetUserByEmailResult>(result));
        }
    }
}