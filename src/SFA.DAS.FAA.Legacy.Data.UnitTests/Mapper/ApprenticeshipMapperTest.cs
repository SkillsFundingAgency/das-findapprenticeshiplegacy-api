using FluentAssertions;
using FluentAssertions.Execution;
using SFA.DAS.FAA.Legacy.Data.Apprenticeships.Entities;
using SFA.DAS.FAA.Legacy.Data.Mapper;
using SFA.DAS.Testing.AutoFixture;

namespace SFA.DAS.FAA.Legacy.Data.UnitTests.Mapper
{
    public class ApprenticeshipMapperTest
    {
        [Test, MoqAutoData]
        public void ConvertToApprenticeship(
            MongoApprenticeships mongoApprenticeships)
        {
            //sut
            var sut = mongoApprenticeships.ConvertToApprenticeship();

            //assert
            using (new AssertionScope())
            {
                sut.ApplicationId.Should().Be(mongoApprenticeships.Id);
                sut.Status.Should().Be(mongoApprenticeships.Status);
                sut.AdditionalQuestion1Answer.Should().Be(mongoApprenticeships.AdditionalQuestion1Answer);
                sut.AdditionalQuestion2Answer.Should().Be(mongoApprenticeships.AdditionalQuestion2Answer);
                sut.DateCreated.Should().Be(mongoApprenticeships.DateCreated);
                sut.DateLastViewed.Should().Be(mongoApprenticeships.DateLastViewed);
                sut.LegacyApplicationId.Should().Be(mongoApprenticeships.LegacyApplicationId);
                sut.Notes.Should().Be(mongoApprenticeships.Notes);
                sut.UnsuccessfulReason.Should().Be(mongoApprenticeships.UnsuccessfulReason);
                sut.VacancyStatus.Should().Be(mongoApprenticeships.VacancyStatus);
                sut.DateUpdated.Should().Be(mongoApprenticeships.DateUpdated);
                sut.IsArchived.Should().Be(mongoApprenticeships.IsArchived);
                sut.CandidateDetails.Should().BeEquivalentTo(mongoApprenticeships.CandidateDetails);
                sut.WithdrawnOrDeclinedReason.Should().Be(mongoApprenticeships.WithdrawnOrDeclinedReason);
                sut.Vacancy.Should().BeEquivalentTo(mongoApprenticeships.Vacancy);
                sut.CandidateDetails.Should().BeEquivalentTo(mongoApprenticeships.CandidateDetails);
                sut.CandidateInformation.Should().BeEquivalentTo(mongoApprenticeships.CandidateInformation);
                sut.VacancyStatus.Should().Be(mongoApprenticeships.VacancyStatus);
                sut.CandidateId.Should().Be(mongoApprenticeships.CandidateId);
                sut.Skills.Should().BeEquivalentTo(mongoApprenticeships.Skills);
                sut.UnsuccessfulDateTime.Should().Be(mongoApprenticeships.UnsuccessfulDateTime);
                sut.SuccessfulDateTime.Should().Be(mongoApprenticeships.SuccessfulDateTime);
            }
        }
    }
}
