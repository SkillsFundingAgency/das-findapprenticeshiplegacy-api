namespace SFA.DAS.FAA.Legacy.Domain.Models.Apprenticeship
{
    public record RegistrationDetails
    {
        private string? _emailAddress;

        public string? FirstName { get; set; }

        public string? MiddleNames { get; set; }

        public string? LastName { get; set; }

        public DateTime DateOfBirth { get; set; }

        public Address Address { get; set; } = new Address();

        public string? EmailAddress
        {
            get => !string.IsNullOrWhiteSpace(this._emailAddress) ? this._emailAddress.ToLower() : this._emailAddress;
            set => this._emailAddress = value;
        }

        public string? PhoneNumber { get; set; }

        public string? AcceptedTermsAndConditionsVersion { get; set; }
    }
}
