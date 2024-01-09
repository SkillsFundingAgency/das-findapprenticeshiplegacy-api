using AutoFixture.NUnit3;
using FluentAssertions;
using Moq;
using SFA.DAS.FAA.Legacy.Application.Apprenticeship.Queries;
using SFA.DAS.FAA.Legacy.Data.Apprenticeships.Entities;
using SFA.DAS.FAA.Legacy.Domain.Interfaces.Repositories;
using SFA.DAS.Testing.AutoFixture;

namespace SFA.DAS.FAA.Legacy.Application.UnitTests.Apprenticeship.Queries.GetApprenticeshipsByEmail
{
    public class GetApprenticeshipsByEmailQueryHandlerTests
    {
        [Test, RecursiveMoqAutoData]
        public async Task Handle_ReturnsApprenticeshipsByEmail_IfUserIsFound(
            [Frozen] Mock<IApprenticeshipsReadRepository> apprenticeshipsReadRepositoryMock,
            GetApprenticeshipsByEmailHandler sut,
            List<MongoApprenticeships> apprenticeships)
        {
            apprenticeshipsReadRepositoryMock.Setup(a => a.Get(It.IsAny<string>())).Returns(apprenticeships);
            var result = await sut.Handle(new GetApprenticeshipsByEmailQuery(It.IsAny<string>()), new CancellationToken());
            result.Apprenticeships.Should().BeEquivalentTo(apprenticeships, c => c.ExcludingMissingMembers());
            result.Count.Should().Be(apprenticeships.Count);
        }

        [Test, RecursiveMoqAutoData]
        public async Task Handle_ReturnsNull_IfUserIsNotFound(
            [Frozen] Mock<IApprenticeshipsReadRepository> apprenticeshipsReadRepositoryMock,
            GetApprenticeshipsByEmailHandler sut)
        {
            apprenticeshipsReadRepositoryMock.Setup(a => a.Get(It.IsAny<string>())).Returns(() => new List<Domain.Models.Application.Apprenticeship>());
            var result = await sut.Handle(new GetApprenticeshipsByEmailQuery(It.IsAny<string>()), new CancellationToken());
            result.Apprenticeships.Should().BeEmpty();
            result.Count.Should().Be(0);
        }
    }
}
