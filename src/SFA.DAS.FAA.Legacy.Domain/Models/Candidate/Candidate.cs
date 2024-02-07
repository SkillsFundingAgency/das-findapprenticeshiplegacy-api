using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SFA.DAS.FAA.Legacy.Domain.Concretes;

namespace SFA.DAS.FAA.Legacy.Domain.Models.Candidate
{
    public class Candidate : BaseEntity
    {
        public Candidate()
        {
            RegistrationDetails = new RegistrationDetails();
            ApplicationTemplate = new ApplicationTemplate();
            CommunicationPreferences = new CommunicationPreferences();
            HelpPreferences = new HelpPreferences();
            MonitoringInformation = new MonitoringInformation();
            SubscriberId = Guid.NewGuid();
        }

        public int LegacyCandidateId { get; set; }

        public Guid SubscriberId { get; set; }

        public RegistrationDetails RegistrationDetails { get; set; }

        public ApplicationTemplate ApplicationTemplate { get; set; }

        public CommunicationPreferences CommunicationPreferences { get; set; }

        public HelpPreferences HelpPreferences { get; set; }

        public MonitoringInformation MonitoringInformation { get; set; }

        
    }
}
