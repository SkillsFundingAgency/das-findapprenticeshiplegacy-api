using FluentAssertions;
using SFA.DAS.FAA.Legacy.Data.Mapper;
using SFA.DAS.FAA.Legacy.Data.User.Entities;
using SFA.DAS.Testing.AutoFixture;

namespace SFA.DAS.FAA.Legacy.Data.UnitTests.Mapper
{
    public class UserMapperTest
    {
        [Test, MoqAutoData]
        public void ConvertToUser(
            MongoUser mongoUser)
        {
            //sut
            var sut = mongoUser.ConvertToUser();

            //assert
            sut.Status.Should().Be(mongoUser.Status);
            sut.AccountUnlockCode.Should().Be(mongoUser.AccountUnlockCode);
            sut.AccountUnlockCodeExpiry.Should().Be(mongoUser.AccountUnlockCodeExpiry);
            sut.ActivateCodeExpiry.Should().Be(mongoUser.ActivateCodeExpiry);
            sut.ActivationCode.Should().Be(mongoUser.ActivationCode);
            sut.ActivationDate.Should().Be(mongoUser.ActivationDate);
            sut.DateCreated.Should().Be(mongoUser.DateCreated);
            sut.DateUpdated.Should().Be(mongoUser.DateUpdated);
            sut.EntityId.Should().Be(mongoUser.EntityId);
            sut.LastActivity.Should().Be(mongoUser.LastActivity);
            sut.LastLogin.Should().Be(mongoUser.LastLogin);
            sut.LoginIncorrectAttempts.Should().Be(mongoUser.LoginIncorrectAttempts);
            sut.PasswordResetCode.Should().Be(mongoUser.PasswordResetCode);
            sut.PasswordResetCodeExpiry.Should().Be(mongoUser.PasswordResetCodeExpiry);
            sut.PasswordResetIncorrectAttempts.Should().Be(mongoUser.PasswordResetIncorrectAttempts);
            sut.PendingUsername.Should().Be(mongoUser.PendingUsername);
            sut.PendingUsernameCode.Should().Be(mongoUser.PendingUsernameCode);
            sut.Roles.Should().Be(mongoUser.Roles);
            sut.Username.Should().Be(mongoUser.Username);
        }
    }
}
