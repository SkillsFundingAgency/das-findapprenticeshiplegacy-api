using FluentAssertions;
using FluentAssertions.Execution;
using Microsoft.Extensions.Logging;
using Moq;
using SFA.DAS.FAA.Legacy.Data.Apprenticeships.Entities;
using SFA.DAS.FAA.Legacy.Data.Repositories;
using SFA.DAS.FAA.Legacy.Domain.Interfaces.Configuration;
using SFA.DAS.Testing.AutoFixture;

namespace SFA.DAS.FAA.Legacy.Data.UnitTests.Repositories
{
    public class ApprenticeshipsRepositoryTests
    {
        private readonly Mock<ILogger<ApprenticeshipsRepository>> _mockLogger = new();
        private readonly Mock<IMongoConfiguration> _mockConfiguration = new();
        private readonly Mock<BaseRepository<MongoApprenticeships>> _mockBaseRepository = new();

        [Test, MoqAutoData]
        public void Get_Given_Result_Not_Throws_Exception(
            string username,
            List<MongoApprenticeships> apprenticeships)
        {
            //arrange
            _mockConfiguration.Setup(x => x.AzureCosmosDb).Returns("mongodb://xxx-xxx:xxx==@username-xxx-cdb.xxx.azure.com:10255/xxxx");
            _mockBaseRepository.Setup(x => x.FilterBy(fil => fil.CandidateDetails.EmailAddress == username, null)).Returns(apprenticeships);

            var sut = new ApprenticeshipsRepository(_mockConfiguration.Object, _mockLogger.Object);

            using (new AssertionScope())
            {
                Func<Task> result = () => Task.FromResult(sut.Get(username));
                result.Should().NotThrowAsync();
            }
        }
    }
}
