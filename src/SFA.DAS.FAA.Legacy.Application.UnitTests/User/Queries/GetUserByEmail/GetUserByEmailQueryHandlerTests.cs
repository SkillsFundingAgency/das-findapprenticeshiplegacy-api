using AutoFixture.NUnit3;
using FluentAssertions;
using FluentAssertions.Execution;
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
            [Frozen] Mock<IUserReadRepository> userReadRepositoryMock,
            [Frozen] Mock<ICandidateReadRepository> candidateReadRepositoryMock,
            GetUserByEmailHandler sut,
            MongoUser user,
            MongoCandidate candidate)
        {
            userReadRepositoryMock.Setup(a => a.Get(user.Username!)).Returns(user);
            candidateReadRepositoryMock.Setup(a => a.Get(user.EntityId!)).Returns(candidate);

            var result = await sut.Handle(new GetUserByEmailQuery(user.Username!), new CancellationToken());
            
            using var scope = new AssertionScope();
            result.Result.Should().BeEquivalentTo(user, c => c.ExcludingMissingMembers());
            result.Result.RegistrationDetails.Should().Be(candidate.RegistrationDetails);
            result.Result.ApplicationTemplate.Should().Be(candidate.ApplicationTemplate);
            result.Result.CommunicationPreferences.Should().Be(candidate.CommunicationPreferences);
            result.Result.HelpPreferences.Should().Be(candidate.HelpPreferences);
            result.Result.MonitoringInformation.Should().Be(candidate.MonitoringInformation);
            result.Result.SubscriberId.Should().Be(candidate.SubscriberId);
            result.Result.LegacyCandidateId.Should().Be(candidate.LegacyCandidateId);
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
