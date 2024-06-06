using SFA.DAS.FAA.Legacy.Data.Candidate.Entities;

namespace SFA.DAS.FAA.Legacy.Data.Mapper
{
    public static class CandidateMapper
    {
        public static Domain.Models.Candidate.Candidate ConvertToCandidate(this MongoCandidate mongoCandidate)
        {
            return new Domain.Models.Candidate.Candidate
            {
                RegistrationDetails = mongoCandidate.RegistrationDetails,
                ApplicationTemplate = mongoCandidate.ApplicationTemplate,
                CommunicationPreferences = mongoCandidate.CommunicationPreferences,
                HelpPreferences = mongoCandidate.HelpPreferences,
                MonitoringInformation = mongoCandidate.MonitoringInformation,
                LegacyCandidateId = mongoCandidate.LegacyCandidateId,
                SubscriberId = mongoCandidate.SubscriberId,
                DateCreated = mongoCandidate.DateCreated,
                DateUpdated = mongoCandidate.DateUpdated,
                EntityId = mongoCandidate.EntityId,
            };
        }
    }
}
