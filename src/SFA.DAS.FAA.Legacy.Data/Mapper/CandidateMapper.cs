using SFA.DAS.FAA.Legacy.Data.Candidate.Entities;

namespace SFA.DAS.FAA.Legacy.Data.Mapper
{
    public static class CandidateMapper
    {
        public static Domain.Models.Candidate.Candidate ConvertToCandidate(this MongoCandidate mongoCandidate)
        {
            return new Domain.Models.Candidate.Candidate
            {
                DateCreated = mongoCandidate.DateCreated,
                DateUpdated = mongoCandidate.DateUpdated,
                EntityId = mongoCandidate.EntityId,
                RegistrationDetails = mongoCandidate.RegistrationDetails,
                ApplicationTemplate = mongoCandidate.ApplicationTemplate,
                CommunicationPreferences = mongoCandidate.CommunicationPreferences,
                HelpPreferences = mongoCandidate.HelpPreferences,
                LegacyCandidateId = mongoCandidate.LegacyCandidateId,
                MonitoringInformation = mongoCandidate.MonitoringInformation,
                SubscriberId = mongoCandidate.SubscriberId
            };
        }
    }
}
