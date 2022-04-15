using Microsoft.EntityFrameworkCore;
using System;
using System.Data.Entity;

namespace InstitutionalPricing.Entity
{
    public interface IInstitutionalPricingContext 
    {
        IDbSet<Proposals> Proposals { get; set; }
        IDbSet<Facilities> Facilities { get; set; }
    }
}
