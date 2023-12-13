using FluentValidation.TestHelper;
using SFA.DAS.FAA.Legacy.Application.User.Queries;

namespace SFA.DAS.FAA.Legacy.Application.UnitTests.User.Queries.GetUserByEmail
{
    public class GetUserByEmailQueryValidatorTests
    {
        [TestCase("test@test.com", true)]
        [TestCase(null, false)]
        [TestCase("", false)]
        [TestCase(" ", false)]
        public async Task Validates_User_Email_NotNull_Not_Empty(string email, bool isValid)
        {
            var query = new GetUserByEmailQuery(email);
            var sut = new GetUserByEmailQueryValidator();
            var result = await sut.TestValidateAsync(query);

            if (isValid)
                result.ShouldNotHaveValidationErrorFor(c => c.Email);
            else
            {
                result.ShouldHaveValidationErrorFor(c => c.Email)
                    .WithErrorMessage(GetUserByEmailQueryValidator.EmailMissingMessage);
            }
        }

        [TestCase("test.test.com")]
        [TestCase("@test.com")]
        public async Task Validates_User_Email_NotNull_Not_Valid(string email)
        {
            var query = new GetUserByEmailQuery(email);
            var sut = new GetUserByEmailQueryValidator();
            var result = await sut.TestValidateAsync(query);
            
            result.ShouldHaveValidationErrorFor(c => c.Email)
                .WithErrorMessage(GetUserByEmailQueryValidator.EmailInvalidMessage);
            
        }
    }
}
