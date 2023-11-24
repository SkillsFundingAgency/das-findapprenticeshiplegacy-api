using FluentValidation;

namespace SFA.DAS.FAA.Legacy.Application.User.Queries
{
    public class GetUserByEmailQueryValidator : AbstractValidator<GetUserByEmailQuery>
    {
        public const string EmailMissingMessage = "Email must have a value";

        public GetUserByEmailQueryValidator()
        {
            RuleFor(a => a.email)
                .NotEmpty()
                .EmailAddress()
                .WithMessage(EmailMissingMessage);
        }
    }
}
