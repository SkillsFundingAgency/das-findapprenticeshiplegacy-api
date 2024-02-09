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
            sut.DateUpdated.Should().Be(mongoCandidate.DateUpdated);
            sut.EntityId.Should().Be(mongoCandidate.EntityId);
            sut.SubscriberId.Should().Be(mongoCandidate.SubscriberId);
            sut.LegacyCandidateId.Should().Be(mongoCandidate.LegacyCandidateId);
            sut.ApplicationTemplate.Should().BeEquivalentTo(mongoCandidate.ApplicationTemplate);
            sut.CommunicationPreferences.Should().BeEquivalentTo(mongoCandidate.CommunicationPreferences);
            sut.HelpPreferences.Should().BeEquivalentTo(mongoCandidate.HelpPreferences);
            sut.MonitoringInformation.Should().BeEquivalentTo(mongoCandidate.MonitoringInformation);
            sut.RegistrationDetails.Should().BeEquivalentTo(mongoCandidate.RegistrationDetails);
        }
    }
}
