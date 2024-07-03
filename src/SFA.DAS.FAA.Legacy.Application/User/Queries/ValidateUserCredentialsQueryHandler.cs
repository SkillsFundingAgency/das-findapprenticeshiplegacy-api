using FluentValidation;
using MediatR;
using Microsoft.Extensions.Logging;
using SFA.DAS.FAA.Legacy.Application.Mediatr.Responses;
using SFA.DAS.FAA.Legacy.Application.Services;
using SFA.DAS.FAA.Legacy.Domain.Interfaces.Configuration;
using SFA.DAS.FAA.Legacy.Domain.Interfaces.Repositories;

namespace SFA.DAS.FAA.Legacy.Application.User.Queries;

public class ValidateUserCredentialsQueryHandler(
    IUserReadRepository userReadRepository,
    IAuthenticationRepository authenticationRepository,
    IPasswordHash passwordHash,
    IUserAccountConfiguration userAccountConfiguration,
    IValidator<ValidateUserCredentialsQuery> validator,
    ILogger<ValidateUserCredentialsQueryHandler> logger)
    : IRequestHandler<ValidateUserCredentialsQuery, ValidatedResponse<ValidateUserCredentialsQueryResult>>
{
    public Task<ValidatedResponse<ValidateUserCredentialsQueryResult>> Handle(ValidateUserCredentialsQuery request, CancellationToken cancellationToken)
    {
        validator.ValidateAndThrow(request);

        var user = userReadRepository.Get(request.Email);

        if (user == null)
        {
            logger.LogError($"Unable to retrieve user for {request.Email}");

            return Task.FromResult(new ValidatedResponse<ValidateUserCredentialsQueryResult>(
                new ValidateUserCredentialsQueryResult
                {
                    IsValid = false
                }));
        }

        var userCredentials = authenticationRepository.Get(user.EntityId);

        if (userCredentials == null)
        {
            logger.LogError($"Unable to retrieve user credentials for {user.EntityId}");

            return Task.FromResult(new ValidatedResponse<ValidateUserCredentialsQueryResult>(
                new ValidateUserCredentialsQueryResult
                {
                    IsValid = false
                }));
        }

        var isValidated = passwordHash.Validate(userCredentials.PasswordHash, user.EntityId.ToString(), request.Password, userAccountConfiguration.UserDirectorySecretKey);

        var message = isValidated
            ? "Successfully validated credentials for Id={0}"
            : "Failed to validate credentials for Id={0}";

        logger.LogInformation(string.Format(message, request.Email));

        var result = new ValidatedResponse<ValidateUserCredentialsQueryResult>(
            new ValidateUserCredentialsQueryResult
            {
                IsValid = isValidated
            });

        return Task.FromResult(result);
    }
}