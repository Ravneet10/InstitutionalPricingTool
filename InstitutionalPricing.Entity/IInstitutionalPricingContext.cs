using Microsoft.EntityFrameworkCore;
using System;
using System.Data.Entity;

namespace InstitutionalPricing.Entity
{
    public interface IInstitutionalPricingContext 
    {
        public IDbSet<Proposals> Proposals { get; set; }
        public IDbSet<Facilities> Facilities { get; set; }
    }
}
