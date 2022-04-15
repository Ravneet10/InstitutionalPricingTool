using Microsoft.EntityFrameworkCore;

namespace InstitutionalPricing.Entity
{
   public class InstitutionalPricingContext : DbContext
    {
        public InstitutionalPricingContext(DbContextOptions<InstitutionalPricingContext> options): base(options)
        {
        }
        public DbSet<Facilities> Facilities { get; set; }
        public DbSet<Proposals> Proposals { get; set; }
    }
}
