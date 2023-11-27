using System.Linq.Expressions;
using FluentAssertions;
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
        public void Get_GivenInvalid_Username_Returns_Null(
            MongoUser mongoUser,
            string username)
        {
            ////arrange
            //var mockIMongoCollection = new Mock<IMongoCollection<MongoUser>>();
            //var asyncCursor = new Mock<IAsyncCursor<MongoUser>>();
            //mockIMongoCollection.Setup(collection => collection
            //    .Find(fil => fil.Username == mongoUser.Username, null)
            //    .Sort(It.IsAny<SortDefinition<MongoUser>>()).ToEnumerable(CancellationToken.None)).Returns(asyncCursor.Object);

            //_mockConfiguration.Setup(x => x.AzureCosmosDb).Returns("mongodb://xxx-xxx:xxx==@username-xxx-cdb.xxx.azure.com:10255/xxxx");
            //_mockBaseRepository.Setup(x => x._collection).Returns(mockIMongoCollection.Object);



            //_mockBaseRepository.Setup(x => x.FilterBy(fil => fil.Username == mongoUser.Username, Builders<MongoUser>.Sort.Ascending(fil => fil.Status))).Returns((IEnumerable<MongoUser>)null);

            //var sut = new UserRepository(_mockConfiguration.Object, _mockLogger.Object);

            ////sut
            //var result = sut.Get(username);

            ////assert
            //result.Should().BeNull();
        }
    }
}
