using SFA.DAS.FAA.Legacy.Data.Apprenticeships.Entities;

namespace SFA.DAS.FAA.Legacy.Data.Mapper
{
    public static class ApprenticeshipMapper
    {
        public static Domain.Models.Application.Apprenticeships ConvertToApprenticeship(this MongoApprenticeships mongoApprenticeships)
        {
            return new Domain.Models.Application.Apprenticeships
            {
                Status = mongoApprenticeships.Status,
                AdditionalQuestion1Answer = mongoApprenticeships.AdditionalQuestion1Answer,
                AdditionalQuestion2Answer = mongoApprenticeships.AdditionalQuestion2Answer,
                DateCreated = mongoApprenticeships.DateCreated,
                DateLastViewed = mongoApprenticeships.DateLastViewed,
                LegacyApplicationId = mongoApprenticeships.LegacyApplicationId,
                Notes = mongoApprenticeships.Notes,
                UnsuccessfulReason = mongoApprenticeships.UnsuccessfulReason,
                VacancyStatus = mongoApprenticeships.VacancyStatus,
                DateUpdated = mongoApprenticeships.DateUpdated,
                DateApplied = mongoApprenticeships.DateApplied,
                CandidateDetails = mongoApprenticeships.CandidateDetails,
                WithdrawnOrDeclinedReason = mongoApprenticeships.WithdrawnOrDeclinedReason,
                Vacancy = mongoApprenticeships.Vacancy,
                CandidateId = mongoApprenticeships.CandidateId,
                CandidateInformation = mongoApprenticeships.CandidateInformation,
                Skills = mongoApprenticeships.Skills,
                SuccessfulDateTime = mongoApprenticeships.SuccessfulDateTime,
                UnsuccessfulDateTime = mongoApprenticeships.UnsuccessfulDateTime
            };
        }
    }
}
