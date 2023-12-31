﻿using FluentAssertions;
using Microsoft.Extensions.Logging;
using Moq;
using SFA.DAS.FAA.Legacy.Data.Repositories;
using SFA.DAS.FAA.Legacy.Data.User.Entities;
using SFA.DAS.FAA.Legacy.Domain.Interfaces.Configuration;
using SFA.DAS.FAA.Legacy.Domain.Interfaces.Repositories;
using SFA.DAS.FAA.Legacy.Domain.Models.HealthStatus;

namespace SFA.DAS.FAA.Legacy.Data.UnitTests.Repositories
{
    public class HealthStatusRepositoryTests
    {
        private readonly Mock<ILogger<HealthStatusRepository>> _mockLogger = new();
        private readonly Mock<IMongoConfiguration> _mockConfiguration = new();
        private readonly Mock<IBaseRepository<MongoUser>> _mockBaseRepository = new();

        [TestCase("mongodb://xxx-xxx:xxx==@username-xxx-cdb.xxx.azure.com:10255/xxxx")]
        public async Task HealthCheck_GivenInvalid_Connection_Returns_Unhealthy(string dbConnectionString)
        {
            //arrange
            _mockConfiguration.Setup(x => x.AzureCosmosDb).Returns(dbConnectionString);
            _mockBaseRepository.Setup(x => x.Ping()).Returns(Task.CompletedTask);

            var sut = new HealthStatusRepository(_mockConfiguration.Object, _mockLogger.Object);

            //sut
            var result = await sut.HealthCheck();

            //assert
            result.Should().Be(HealthCheckResult.UnHealthy);
            _mockLogger.Verify(l =>
                l.Log(
                    LogLevel.Error,
                    It.IsAny<EventId>(),
                    It.Is<It.IsAnyType>((state, type) => state.ToString()!.Contains("Unable to communicate with MongoDb.")),
                    It.IsAny<Exception>(),
                    It.IsAny<Func<It.IsAnyType, Exception, string>>()!
                ), Times.AtLeastOnce);
        }

        [TestCase("mongodb://xxx-xxx:xxx==@username-xxx-cdb.xxx.azure.com:10255/xxxx")]
        public async Task HealthCheck_GivenException_Returns_Unhealthy(string dbConnectionString)
        {
            //arrange
            _mockConfiguration.Setup(x => x.AzureCosmosDb).Returns(dbConnectionString);
            _mockBaseRepository.Setup(x => x.Ping()).ThrowsAsync(new Exception());

            var sut = new HealthStatusRepository(_mockConfiguration.Object, _mockLogger.Object);

            //sut
            var result = await sut.HealthCheck();

            //assert
            result.Should().Be(HealthCheckResult.UnHealthy);
            _mockLogger.Verify(l =>
                l.Log(
                    LogLevel.Error,
                    It.IsAny<EventId>(),
                    It.Is<It.IsAnyType>((state, type) => state.ToString()!.Contains("Unable to communicate with MongoDb.")),
                    It.IsAny<Exception>(),
                    It.IsAny<Func<It.IsAnyType, Exception, string>>()!
                ), Times.AtLeastOnce);
        }
    }
}
