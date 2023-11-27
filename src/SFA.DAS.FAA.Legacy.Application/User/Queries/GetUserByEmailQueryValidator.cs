using FluentValidation;

namespace SFA.DAS.FAA.Legacy.Application.User.Queries
{
    public class GetUserByEmailQueryValidator : AbstractValidator<GetUserByEmailQuery>
    {
        public const string EmailMissingMessage = "Email must have a value";
        public const string EmailInvalidMessage = "Email must have a value Email Address";

        public GetUserByEmailQueryValidator()
        {
            RuleFor(a => a.Email)
                .NotEmpty().WithMessage(EmailMissingMessage)
                .EmailAddress().WithMessage(EmailInvalidMessage);

        }
    }
}
