using FluentValidation;
using MediatR;
using SFA.DAS.FAA.Legacy.Application.Mediatr.Responses;
using SFA.DAS.FAA.Legacy.Domain.Interfaces.Repositories;

namespace SFA.DAS.FAA.Legacy.Application.User.Queries
{
    public class GetUserByEmailHandler(
        IUserReadRepository userReadRepository,
        IValidator<GetUserByEmailQuery> validator)
        : IRequestHandler<GetUserByEmailQuery, ValidatedResponse<GetUserByEmailResult>>
    {
        public Task<ValidatedResponse<GetUserByEmailResult>> Handle(GetUserByEmailQuery request,
            CancellationToken cancellationToken)
        {
            validator.ValidateAndThrow(request);

            var user = userReadRepository.Get(request.Email);

            return Task.FromResult(user is null
                ? ValidatedResponse<GetUserByEmailResult>.EmptySuccessResponse()
                : new ValidatedResponse<GetUserByEmailResult>(user));
        }
    }
}