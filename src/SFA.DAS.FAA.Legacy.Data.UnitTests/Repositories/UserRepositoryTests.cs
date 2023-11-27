using Microsoft.Extensions.Logging;
using MongoDB.Driver;
using Moq;
using SFA.DAS.FAA.Legacy.Data.Repositories;
using SFA.DAS.FAA.Legacy.Data.User.Entities;
using SFA.DAS.FAA.Legacy.Domain.Interfaces.Configuration;
using SFA.DAS.Testing.AutoFixture;

namespace SFA.DAS.FAA.Legacy.Data.UnitTests.Repositories
{
    public class UserRepositoryTests
    {
        private readonly Mock<ILogger<UserRepository>> _mockLogger = new();
        private readonly Mock<IMongoConfiguration> _mockConfiguration = new();
        private readonly Mock<BaseRepository<MongoUser>> _mockBaseRepository = new();

        [Test, MoqAutoData]
        public void Get_GivenException_Rethrows_Exception(
            string username)
        {
            //arrange
            _mockConfiguration.Setup(x => x.AzureCosmosDb).Returns("mongodb://xxx-xxx:xxx==@username-xxx-cdb.xxx.azure.com:10255/xxxx");
            _mockBaseRepository.Setup(x => x.FilterBy(fil => fil.Username == username, Builders<MongoUser>.Sort.Ascending(fil => fil.Status))).Throws(new TimeoutException());

            var sut = new UserRepository(_mockConfiguration.Object, _mockLogger.Object);

            //assert
            Assert.Throws<TimeoutException>(() => sut.Get(username));

            _mockLogger.Verify(l =>
                l.Log(
                    LogLevel.Error,
                    It.IsAny<EventId>(),
                    It.Is<It.IsAnyType>((state, type) => state.ToString()!.Contains("Unable to communicate with MongoDb. Details:")),
                    It.IsAny<Exception>(),
                    It.IsAny<Func<It.IsAnyType, Exception, string>>()!
                ), Times.AtLeastOnce);
        }
    }
}
