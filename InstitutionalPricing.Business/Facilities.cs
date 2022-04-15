using System;
using System.Collections.Generic;
using System.Text;

namespace InstitutionalPricing.Business
{
    public class Facilities
    {
        public Guid Id { get; set; }
        public string ProposalName { get; set; }
        public string FacilityName { get; set; }
        public string BookingCountry { get; set; }
        public string Currency { get; set; }

        public DateTime StartDate { get; set; }

        public DateTime MaturityDate { get; set; }

        public Decimal Limit { get; set; }
    }
}
