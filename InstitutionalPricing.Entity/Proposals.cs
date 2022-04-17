using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace InstitutionalPricing.Entity
{
    public class Proposals: IdentityUser
    {
        public Guid Id { get; set; }
        public string ProposalName { get; set; }
        public string CustomerGrpName { get; set; }

        public DateTime Date { get; set; }
        public string Description { get; set; }
        public string Status { get; set; }

        public DateTime DateCreated { get; set; }

        [StringLength(256)]
        public string CreatedBy { get; set; }
        public DateTime DateModified { get; set; }

        [StringLength(256)]
        public string ModifiedBy { get; set; }
        public DateTime? DateDeleted { get; set; }

        [StringLength(256)]
        public string DeletedBy { get; set; }

        public bool IsDeleted { get; set; }
    }
}
