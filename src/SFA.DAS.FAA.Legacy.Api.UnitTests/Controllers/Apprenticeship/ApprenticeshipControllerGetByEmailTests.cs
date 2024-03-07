using AutoFixture.NUnit3;
using FluentAssertions;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Moq;
using SFA.DAS.FAA.Legacy.Api.Controllers;
using SFA.DAS.FAA.Legacy.Application.Apprenticeship.Queries;
using SFA.DAS.FAA.Legacy.Application.Mediatr.Responses;
using SFA.DAS.Testing.AutoFixture;

namespace SFA.DAS.FAA.Legacy.Api.UnitTests.Controllers.Apprenticeship
{
    public class ApprenticeshipControllerGetByEmailTests
    {
        [Test, MoqAutoData]
        public async Task GetApprenticeshipsByEmail_InvokesQueryHandler(
            [Frozen] Mock<IMediator> mediatorMock,
            [Greedy] ApprenticeshipController sut,
            string email)
        {
            await sut.Get(email);
            mediatorMock.Verify(m => m.Send(It.Is<GetApprenticeshipsByEmailQuery>(q => q.Email == email),
                It.IsAny<CancellationToken>()));
        }

        [Test]
        [MoqAutoData]
        public async Task GetApprenticeshipsByEmail_HandlerReturnsData_ReturnsOkResponse(
            [Frozen] Mock<IMediator> mediatorMock,
            [Greedy] ApprenticeshipController sut,
            string email,
            GetApprenticeshipsByEmailQueryResult getApprenticeshipsByEmailQueryResult)
        {
            var response =
                new ValidatedResponse<GetApprenticeshipsByEmailQueryResult>(getApprenticeshipsByEmailQueryResult);
            mediatorMock.Setup(m => m.Send(It.Is<GetApprenticeshipsByEmailQuery>(q => q.Email == email),
                    It.IsAny<CancellationToken>()))
                .ReturnsAsync(response);

            var result = await sut.Get(email);

            result.As<OkObjectResult>().Should().NotBeNull();
            result.As<OkObjectResult>().Value.Should().Be(getApprenticeshipsByEmailQueryResult);
        }
    }
}