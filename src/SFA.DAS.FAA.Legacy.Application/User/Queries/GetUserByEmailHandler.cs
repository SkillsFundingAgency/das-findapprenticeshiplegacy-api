using MediatR;
using SFA.DAS.FAA.Legacy.Application.Mediatr.Responses;
using SFA.DAS.FAA.Legacy.Domain.Interfaces.Repositories;

namespace SFA.DAS.FAA.Legacy.Application.User.Queries
{
    public class GetUserByEmailHandler : IRequestHandler<GetUserByEmailQuery, ValidatedResponse<GetUserByEmailResult>>
    {
        private readonly IUserReadRepository _userReadRepository;

        public GetUserByEmailHandler(IUserReadRepository userReadRepository) => _userReadRepository = userReadRepository;

        public Task<ValidatedResponse<GetUserByEmailResult>> Handle(GetUserByEmailQuery request, CancellationToken cancellationToken)
        {
            var user = _userReadRepository.Get(request.Email);

            return Task.FromResult(user is null 
                ? ValidatedResponse<GetUserByEmailResult>.EmptySuccessResponse() 
                : new ValidatedResponse<GetUserByEmailResult>(user));
        }
    }
}
