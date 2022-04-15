using System;
using System.Collections.Generic;
using System.Text;

namespace InstitutionalPricing.Business
{
    public class Proposals
    {
        public Guid Id { get; set; }
        public string ProposalName { get; set; }
        public string CustomerGrpName { get; set; }
        public DateTime Date { get; set; }
        public string Description { get; set; }
        public string Status { get; set; }
    }
}
