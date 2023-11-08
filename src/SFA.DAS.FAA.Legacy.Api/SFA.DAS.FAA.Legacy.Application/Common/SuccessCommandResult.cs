using System.Diagnostics.CodeAnalysis;

namespace SFA.DAS.FAA.Legacy.Application.Common
{
    [ExcludeFromCodeCoverage]
    public record SuccessCommandResult(bool IsSuccess = true);
}
