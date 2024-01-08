namespace SFA.DAS.FAA.Legacy.Domain.Models.Apprenticeship
{
    public class RegistrationDetails
    {
        private string _emailAddress;

        public RegistrationDetails() => this.Address = new Address();

        public string FirstName { get; set; }

        public string MiddleNames { get; set; }

        public string LastName { get; set; }

        public DateTime DateOfBirth { get; set; }

        public Address Address { get; set; }

        public string EmailAddress
        {
            get
            {
                return !string.IsNullOrWhiteSpace(this._emailAddress) ? this._emailAddress.ToLower() : this._emailAddress;
            }
            set => this._emailAddress = value;
        }

        public string PhoneNumber { get; set; }

        public string AcceptedTermsAndConditionsVersion { get; set; }
    }
}
