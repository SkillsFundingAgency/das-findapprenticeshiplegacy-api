using AutoFixture.NUnit3;
using FluentAssertions;
using FluentAssertions.Execution;
using SFA.DAS.FAA.Legacy.Application.Apprenticeship.Queries;

namespace SFA.DAS.FAA.Legacy.Application.UnitTests.Apprenticeship.Queries.GetApprenticeshipsByEmail
{
    public class WhenCreatingGetApprenticeshipsByEmailQueryResultTest
    {
        [Test, AutoData]
        public void Then_The_Fields_Are_Mapped(Domain.Models.Application.Apprenticeship source)
        {
            var actual = (ApprenticeshipResult)source;

            using (new AssertionScope())
            {
                actual.Status.Should().Be(source.Status);
                actual.AdditionalQuestion1Answer.Should().Be(source.AdditionalQuestion1Answer);
                actual.AdditionalQuestion2Answer.Should().Be(source.AdditionalQuestion2Answer);
                actual.DateCreated.Should().Be(source.DateCreated);
                actual.DateLastViewed.Should().Be(source.DateLastViewed);
                actual.LegacyApplicationId.Should().Be(source.LegacyApplicationId);
                actual.Notes.Should().Be(source.Notes);
                actual.UnsuccessfulReason.Should().Be(source.UnsuccessfulReason);
                actual.VacancyStatus.Should().Be(source.VacancyStatus);
                actual.DateUpdated.Should().Be(source.DateUpdated);
                actual.DateApplied.Should().Be(source.DateApplied);
                actual.CandidateDetails.Should().BeEquivalentTo(source.CandidateDetails);
                actual.WithdrawnOrDeclinedReason.Should().Be(source.WithdrawnOrDeclinedReason);
                actual.Vacancy.Should().BeEquivalentTo(source.Vacancy);
                actual.CandidateId.Should().Be(source.CandidateId);
                actual.CandidateInformation.Should().BeEquivalentTo(source.CandidateInformation);
                actual.Skills.Should().BeEquivalentTo(source.Skills);
                actual.SuccessfulDateTime.Should().Be(source.SuccessfulDateTime);
                actual.UnsuccessfulDateTime.Should().Be(source.UnsuccessfulDateTime);
                actual.IsArchived.Should().Be(source.IsArchived);
            }
        }
    }
}
