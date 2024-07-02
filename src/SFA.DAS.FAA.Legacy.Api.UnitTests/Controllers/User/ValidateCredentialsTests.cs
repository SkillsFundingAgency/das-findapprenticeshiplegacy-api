using AutoFixture.NUnit3;
using FluentAssertions;
using FluentValidation;
using Microsoft.Extensions.Logging;
using Moq;
using SFA.DAS.FAA.Legacy.Application.Services;
using SFA.DAS.FAA.Legacy.Application.User.Queries;
using SFA.DAS.FAA.Legacy.Domain.Interfaces.Configuration;
using SFA.DAS.FAA.Legacy.Domain.Interfaces.Repositories;
using SFA.DAS.Testing.AutoFixture;

namespace SFA.DAS.FAA.Legacy.Api.UnitTests.Controllers.User
{
    [TestFixture]
    public class ValidateCredentialsTests
    {
        [Test, MoqAutoData]
        public async Task Handle_Validates_Credentials(
            [Frozen] Mock<IUserReadRepository> userReadRepository,
            [Frozen] Mock<IAuthenticationRepository> authenticationRepository,
            [Frozen] Mock<IPasswordHash> passwordHash,
            [Frozen] IUserAccountConfiguration userAccountConfiguration,
            [Frozen] Mock<IValidator<ValidateUserCredentialsQuery>> validator,
            [Frozen] Mock<ILogger<ValidateUserCredentialsQueryHandler>> logger,
            ValidateUserCredentialsQuery query,
            Domain.Models.User.User user,
            Domain.Models.User.UserCredentials credentials,
            bool validationResult,
            ValidateUserCredentialsQueryHandler handler)            
        {
            userReadRepository.Setup(x => x.Get(It.Is<string>(u => u == query.Email)))
                .Returns(user);

            authenticationRepository.Setup(x => x.Get(It.Is<Guid>(id => id == user.EntityId)))
                .Returns(credentials);

            passwordHash.Setup(x => x.Validate(credentials.PasswordHash, user.EntityId.ToString(), query.Password, userAccountConfiguration.UserDirectorySecretKey))
                .Returns(validationResult);

            var result = await handler.Handle(query, CancellationToken.None);

            result.Result.IsValid.Should().Be(validationResult);
        }
    }
}
