using SFA.DAS.FAA.Legacy.Application.Mediatr.Responses;

namespace SFA.DAS.FAA.Legacy.Application.User.Queries;

public class ValidateUserCredentialsQueryResult : ValidatedResponse
{
    public bool IsValid { get; set; }
}