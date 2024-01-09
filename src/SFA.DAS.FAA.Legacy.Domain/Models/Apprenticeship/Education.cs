namespace SFA.DAS.FAA.Legacy.Domain.Models.Apprenticeship
{
    public record Education
    {
        public string? Institution { get; set; }

        public int FromYear { get; set; }

        public int ToYear { get; set; }
    }
}
