using AutoFixture.NUnit3;
using FluentAssertions;
using Moq;
using SFA.DAS.FAA.Legacy.Application.User.Queries;
using SFA.DAS.FAA.Legacy.Data.Candidate.Entities;
using SFA.DAS.FAA.Legacy.Data.User.Entities;
using SFA.DAS.FAA.Legacy.Domain.Interfaces.Repositories;
using SFA.DAS.Testing.AutoFixture;

namespace SFA.DAS.FAA.Legacy.Application.UnitTests.User.Queries.GetUserByEmail
{
    public class GetUserByEmailQueryHandlerTests
    {
        [Test, RecursiveMoqAutoData]
        public async Task Handle_ReturnsUserByEmail_IfUserIsFound(
            string email,
            [Frozen] Mock<IUserReadRepository> userReadRepositoryMock,
            [Frozen] Mock<ICandidateReadRepository> candidateReadRepositoryMock,
            GetUserByEmailHandler sut,
            MongoUser user,
            MongoCandidate candidate)
        {
            userReadRepositoryMock.Setup(a => a.Get(email)).Returns(user);
            candidateReadRepositoryMock.Setup(a => a.Get(email)).Returns(candidate);
            var result = await sut.Handle(new GetUserByEmailQuery(email), new CancellationToken());
            result.Result.Should().BeEquivalentTo(user, c => c.ExcludingMissingMembers());
            result.Result.Should().BeEquivalentTo(candidate, c => c.ExcludingMissingMembers());
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
