using AutoFixture.NUnit3;
using FluentAssertions;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Moq;
using SFA.DAS.FAA.Legacy.Api.Controllers;
using SFA.DAS.FAA.Legacy.Application.Health.Queries;
using SFA.DAS.FAA.Legacy.Application.Mediatr.Responses;
using SFA.DAS.Testing.AutoFixture;

namespace SFA.DAS.FAA.Legacy.Api.UnitTests.Controllers.System
{
    public class SystemControllerGetTests
    {
        [Test]
        [MoqAutoData]
        public async Task GetHealth_InvokesQueryHandler(
            [Frozen] Mock<IMediator> mediatorMock,
            [Greedy] SystemController sut)
        {
            await sut.GetHealth();

            mediatorMock.Verify(m => m.Send(It.IsAny<GetHealthStatusQuery>(), It.IsAny<CancellationToken>()), Times.Once);
        }

        [Test]
        [MoqAutoData]
        public async Task GetHealth_HandlerReturnsData_ReturnsOkResponse(
            [Frozen] Mock<IMediator> mediatorMock,
            [Greedy] SystemController sut,
            GetHealthStatusResult getHealthStatusResult)
        {
            mediatorMock.Setup(m => m.Send(It.IsAny<GetHealthStatusQuery>(), It.IsAny<CancellationToken>())).ReturnsAsync(getHealthStatusResult);

            var result = await sut.GetHealth();

            result.As<OkObjectResult>().Should().NotBeNull();
            result.As<OkObjectResult>().Value.Should().Be(getHealthStatusResult);
        }
    }
}
