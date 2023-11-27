using AutoFixture.NUnit3;
using FluentAssertions;
using FluentValidation.Results;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Moq;
using SFA.DAS.FAA.Legacy.Api.Common;
using SFA.DAS.FAA.Legacy.Api.Controllers;
using SFA.DAS.FAA.Legacy.Application.Mediatr.Responses;
using SFA.DAS.FAA.Legacy.Application.User.Queries;
using SFA.DAS.Testing.AutoFixture;

namespace SFA.DAS.FAA.Legacy.Api.UnitTests.Controllers.User
{
    public class UserControllerGetByEmailTest
    {
        [Test, MoqAutoData]
        public async Task GetUserByEmail_InvokesQueryHandler(
       [Frozen] Mock<IMediator> mediatorMock,
       [Greedy] UserController sut,
       string email)
        {
            await sut.Get(email);
            mediatorMock.Verify(m => m.Send(It.Is<GetUserByEmailQuery>(q => q.Email == email), It.IsAny<CancellationToken>()));
        }

        [Test]
        [MoqAutoData]
        public async Task GetUserByEmail_HandlerReturnsNullResult_ReturnsNotFoundResponse(
            [Frozen] Mock<IMediator> mediatorMock,
            [Greedy] UserController sut,
            string email)
        {
            var notFoundResponse = ValidatedResponse<GetUserByEmailResult>.EmptySuccessResponse();
            mediatorMock.Setup(m => m.Send(It.Is<GetUserByEmailQuery>(q => q.Email == email), It.IsAny<CancellationToken>())).ReturnsAsync(notFoundResponse);

            var result = await sut.Get(email);
            result.As<NotFoundResult>().Should().NotBeNull();
        }

        [Test]
        [MoqAutoData]
        public async Task GetUserByEmail_HandlerReturnsData_ReturnsOkResponse(
            [Frozen] Mock<IMediator> mediatorMock,
            [Greedy] UserController sut,
            string email,
            GetUserByEmailResult getUserByEmailResult)
        {
            var response = new ValidatedResponse<GetUserByEmailResult>(getUserByEmailResult);
            mediatorMock.Setup(m => m.Send(It.Is<GetUserByEmailQuery>(q => q.Email == email), It.IsAny<CancellationToken>()))
                .ReturnsAsync(response);

            var result = await sut.Get(email);

            result.As<OkObjectResult>().Should().NotBeNull();
            result.As<OkObjectResult>().Value.Should().Be(getUserByEmailResult);
        }

        [Test]
        [MoqAutoData]
        public async Task GetUserByEmail_InvalidRequest_ReturnsBadRequestResponse(
            [Frozen] Mock<IMediator> mediatorMock,
            [Greedy] UserController sut,
            List<ValidationFailure> errors,
            string email)
        {
            var errorResponse = new ValidatedResponse<GetUserByEmailResult>(errors);
            mediatorMock.Setup(m => m.Send(It.Is<GetUserByEmailQuery>(q => q.Email == email), It.IsAny<CancellationToken>())).ReturnsAsync(errorResponse);

            var result = await sut.Get(email);

            result.As<BadRequestObjectResult>().Should().NotBeNull();
            result.As<BadRequestObjectResult>().Value.As<List<ValidationError>>().Count.Should().Be(errors.Count);
        }
    }
}
