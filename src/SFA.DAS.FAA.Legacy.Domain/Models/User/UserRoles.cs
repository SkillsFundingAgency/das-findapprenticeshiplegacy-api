namespace SFA.DAS.FAA.Legacy.Domain.Models.User
{
    [Flags]
    public enum UserRoles
    {
        Candidate = 1,
        Employer = 2,
        VacancyManager = 4,
        Provider = 8
    }
}
