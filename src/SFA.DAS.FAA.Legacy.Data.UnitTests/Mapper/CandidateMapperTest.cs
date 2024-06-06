using FluentAssertions;
using SFA.DAS.FAA.Legacy.Data.Candidate.Entities;
using SFA.DAS.FAA.Legacy.Data.Mapper;
using SFA.DAS.Testing.AutoFixture;

namespace SFA.DAS.FAA.Legacy.Data.UnitTests.Mapper
{
    public class CandidateMapperTest
    {
        [Test, MoqAutoData]
        public void ConvertToCandidate(
            MongoCandidate mongoCandidate)
        {
            //sut
            var sut = mongoCandidate.ConvertToCandidate();

            //assert
            sut.CommunicationPreferences.Should().Be(mongoCandidate.CommunicationPreferences);
            sut.RegistrationDetails.Should().Be(mongoCandidate.RegistrationDetails);
            sut.ApplicationTemplate.Should().Be(mongoCandidate.ApplicationTemplate);
            sut.HelpPreferences.Should().Be(mongoCandidate.HelpPreferences);
            sut.LegacyCandidateId.Should().Be(mongoCandidate.LegacyCandidateId);
            sut.SubscriberId.Should().Be(mongoCandidate.SubscriberId);
            sut.DateCreated.Should().Be(mongoCandidate.DateCreated);
            sut.DateUpdated.Should().Be(mongoCandidate.DateUpdated);
            sut.EntityId.Should().Be(mongoCandidate.EntityId);
            sut.MonitoringInformation.Should().Be(mongoCandidate.MonitoringInformation);
        }
    }
}
