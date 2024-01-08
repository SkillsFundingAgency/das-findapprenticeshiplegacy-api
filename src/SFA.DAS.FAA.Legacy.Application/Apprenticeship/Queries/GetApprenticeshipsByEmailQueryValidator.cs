using FluentValidation;

namespace SFA.DAS.FAA.Legacy.Application.Apprenticeship.Queries
{
    public class GetApprenticeshipsByEmailQueryValidator : AbstractValidator<GetApprenticeshipsByEmailQuery>
    {
        public const string EmailMissingMessage = "Email must have a value";
        public const string EmailInvalidMessage = "Email must have a value Email Address";

        public GetApprenticeshipsByEmailQueryValidator()
        {
            RuleFor(a => a.Email)
                .NotEmpty().WithMessage(EmailMissingMessage)
                .EmailAddress().WithMessage(EmailInvalidMessage);

        }
    }
}
