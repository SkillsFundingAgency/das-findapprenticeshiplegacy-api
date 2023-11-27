using AutoFixture.NUnit3;
using FluentAssertions;
using Moq;
using SFA.DAS.FAA.Legacy.Application.User.Queries;
using SFA.DAS.FAA.Legacy.Data.User.Entities;
using SFA.DAS.FAA.Legacy.Domain.Interfaces.Repositories;
using SFA.DAS.Testing.AutoFixture;

namespace SFA.DAS.FAA.Legacy.Application.UnitTests.User.Queries.GetUserByEmail
{
    public class GetUserByEmailQueryHandlerTests
    {
        [Test, RecursiveMoqAutoData]
        public async Task Handle_ReturnsUserByEmail_IfUserIsFound(
            [Frozen] Mock<IUserReadRepository> userReadRepositoryMock,
            GetUserByEmailHandler sut,
            MongoUser user)
        {
            userReadRepositoryMock.Setup(a => a.Get(user.Username)).Returns(user);
            var result = await sut.Handle(new GetUserByEmailQuery(user.Username), new CancellationToken());
            result.Result.Should().BeEquivalentTo(user, c => c.ExcludingMissingMembers());
        }

        [Test, RecursiveMoqAutoData]
        public async Task Handle_ReturnsNull_IfUserIsNotFound(
            [Frozen] Mock<IUserReadRepository> userReadRepositoryMock,
            GetUserByEmailHandler sut,
            string email)
        {
            userReadRepositoryMock.Setup(a => a.Get(email)).Returns(() => null);
            var result = await sut.Handle(new GetUserByEmailQuery(email), new CancellationToken());
            result.Result.Should().BeNull();
        }
    }
}
