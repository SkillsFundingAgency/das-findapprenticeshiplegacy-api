using FluentValidation.TestHelper;
using SFA.DAS.FAA.Legacy.Application.Apprenticeship.Queries;

namespace SFA.DAS.FAA.Legacy.Application.UnitTests.Apprenticeship.Queries.GetApprenticeshipsByEmail
{
    public class GetApprenticeshipsByEmailQueryValidatorTests
    {
        [TestCase("test@test.com", true)]
        [TestCase(null, false)]
        [TestCase("", false)]
        [TestCase(" ", false)]
        public async Task Validates_User_Email_NotNull_Not_Empty(string email, bool isValid)
        {
            var query = new GetApprenticeshipsByEmailQuery(email);
            var sut = new GetApprenticeshipsByEmailQueryValidator();
            var result = await sut.TestValidateAsync(query);

            if (isValid)
                result.ShouldNotHaveValidationErrorFor(c => c.Email);
            else
            {
                result.ShouldHaveValidationErrorFor(c => c.Email)
                    .WithErrorMessage(GetApprenticeshipsByEmailQueryValidator.EmailMissingMessage);
            }
        }

        [TestCase("test.test.com")]
        [TestCase("@test.com")]
        public async Task Validates_User_Email_NotNull_Not_Valid(string email)
        {
            var query = new GetApprenticeshipsByEmailQuery(email);
            var sut = new GetApprenticeshipsByEmailQueryValidator();
            var result = await sut.TestValidateAsync(query);

            result.ShouldHaveValidationErrorFor(c => c.Email)
                .WithErrorMessage(GetApprenticeshipsByEmailQueryValidator.EmailInvalidMessage);

        }
    }
}
