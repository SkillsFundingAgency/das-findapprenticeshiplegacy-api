using FluentValidation;

namespace SFA.DAS.FAA.Legacy.Application.User.Queries
{
    public class ValidateUserCredentialsQueryValidator : AbstractValidator<ValidateUserCredentialsQuery>
    {
        public const string EmailMissingMessage = "Email must have a value";
        public const string EmailInvalidMessage = "Email must have a value Email Address";
        public const string PasswordMissingMessage = "Password must have a value";

        public ValidateUserCredentialsQueryValidator()
        {
            RuleFor(a => a.Email)
                .NotEmpty().WithMessage(EmailMissingMessage)
                .EmailAddress().WithMessage(EmailInvalidMessage);

            RuleFor(a => a.Password)
                .NotEmpty().WithMessage(PasswordMissingMessage);
        }
    }
}
