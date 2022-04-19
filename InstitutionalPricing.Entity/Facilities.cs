using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace InstitutionalPricing.Entity
{
    [Table("Facilities")]
    public class Facilities
    {
        public Guid Id { get; set; }
        public Guid ProposalId { get; set; }
        public string FacilityName { get; set; }
        public string BookingCountry { get; set; }
        public string Currency { get; set; }

        [Column(TypeName = "date")]
        public DateTime StartDate { get; set; }

        [Column(TypeName = "date")]
        public DateTime MaturityDate { get; set; }

        public Decimal Limit { get; set; }
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
