using AutoFixture.NUnit3;
using FluentAssertions;
using FluentValidation.Results;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Moq;
using SFA.DAS.FAA.Legacy.Api.Common;
using SFA.DAS.FAA.Legacy.Api.Controllers;
using SFA.DAS.FAA.Legacy.Api.Models;
using SFA.DAS.FAA.Legacy.Application.Mediatr.Responses;
using SFA.DAS.FAA.Legacy.Application.User.Queries;
using SFA.DAS.Testing.AutoFixture;

namespace SFA.DAS.FAA.Legacy.Api.UnitTests.Controllers.User
{
    public class UserControllerValidateUserCredentialsTest
    {
        [Test, MoqAutoData]
        public async Task ValidatesUserCredentials_InvokesQueryHandler(
           [Frozen] Mock<IMediator> mediatorMock,
           [Greedy] UserController sut,
           UserCredentialsModel model)
        {
            await sut.ValidateUserCredentials(model);
            mediatorMock.Verify(m => m.Send(It.Is<ValidateUserCredentialsQuery>(q => q.Email == model.Email && q.Password == model.Password), It.IsAny<CancellationToken>()));
        }


        [Test]
        [MoqAutoData]
        public async Task ValidatesUserCredentials_HandlerReturnsData_ReturnsOkResponse(
            [Frozen] Mock<IMediator> mediatorMock,
            [Greedy] UserController sut,
            UserCredentialsModel model,
            ValidateUserCredentialsQueryResult validateUserCredentialsQueryResult)
        {
            var response = new ValidatedResponse<ValidateUserCredentialsQueryResult>(validateUserCredentialsQueryResult);
            mediatorMock.Setup(m => m.Send(It.Is<ValidateUserCredentialsQuery>(q => q.Email == model.Email && q.Password == model.Password), It.IsAny<CancellationToken>()))
                .ReturnsAsync(response);

            var result = await sut.ValidateUserCredentials(model);

            result.As<OkObjectResult>().Should().NotBeNull();
            result.As<OkObjectResult>().Value.Should().Be(validateUserCredentialsQueryResult);
        }

        [Test]
        [MoqAutoData]
        public async Task ValidatesUserCredentials_InvalidRequest_ReturnsBadRequestResponse(
            [Frozen] Mock<IMediator> mediatorMock,
            [Greedy] UserController sut,
            List<ValidationFailure> errors,
            UserCredentialsModel model)
        {
            var errorResponse = new ValidatedResponse<ValidateUserCredentialsQueryResult>(errors);
            mediatorMock.Setup(m => m.Send(It.Is<ValidateUserCredentialsQuery>(q => q.Email == model.Email && q.Password == model.Password), It.IsAny<CancellationToken>()))
                .ReturnsAsync(errorResponse);

            var result = await sut.ValidateUserCredentials(model);

            result.As<BadRequestObjectResult>().Should().NotBeNull();
            result.As<BadRequestObjectResult>().Value.As<List<ValidationError>>().Count.Should().Be(errors.Count);
        }
    }
}
