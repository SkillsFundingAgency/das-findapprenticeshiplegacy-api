namespace SFA.DAS.FAA.Legacy.Domain.Models.Candidate
{
    public class RegistrationDetails
    {
        private string _emailAddress;

        public string FirstName { get; set; }

        public string MiddleNames { get; set; }

        public string LastName { get; set; }

        public DateTime DateOfBirth { get; set; }

        public Address Address { get; set; }

        public string EmailAddress
        {
            get
            {
                if (!string.IsNullOrWhiteSpace(_emailAddress))
                {
                    return _emailAddress.ToLower();
                }

                return _emailAddress;
            }
            set
            {
                _emailAddress = value;
            }
        }

        public string PhoneNumber { get; set; }

        public string AcceptedTermsAndConditionsVersion { get; set; }

        public RegistrationDetails()
        {
            Address = new Address();
        }
    }
}
