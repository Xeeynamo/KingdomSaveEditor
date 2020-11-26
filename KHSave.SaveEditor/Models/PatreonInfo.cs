using System.Collections.Generic;

namespace KHSave.SaveEditor.Models
{
    public class PatreonInfo
    {
        public string PatreonUrl { get; set; }

        public IEnumerable<PatronModel> Patrons { get; set; }

        public SponsorshipInfo SponsorshipInfo { get; set; }

        public IEnumerable<ServiceMessage> Messages { get; set; }
    }
}
