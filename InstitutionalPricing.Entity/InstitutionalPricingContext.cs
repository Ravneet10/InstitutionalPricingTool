//using Microsoft.EntityFrameworkCore;
//using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System.Data.Common;
//using System.Data.Entity;

namespace InstitutionalPricing.Entity
{
    public class InstitutionalPricingContext : DbContext, IInstitutionalPricingContext
    {
        public InstitutionalPricingContext() { }
        public InstitutionalPricingContext(DbContextOptions<InstitutionalPricingContext> options) : base(options)
        {
        }
        //protected InstitutionalPricingContext(DbConnection dbConnection) : base(dbConnection, true)
        //{
        //    Database.SetInitializer<InstitutionalPricingContext>(null);
        //}
         //public  DbSet<Facilities> Facilities { get; set; }
       // public DbSet<Proposals> Proposals { get; set; }
        public virtual System.Data.Entity.IDbSet<Proposals> Proposals { get; set; }
        public virtual System.Data.Entity.IDbSet<Facilities> Facilities { get; set; }
        //protected override void OnModelCreating(DbModelBuilder modelBuilder)
        //{
        //    modelBuilder.Entity<Proposals>(entity =>
        //    {
        //        entity.Property(e => e.CustomerGrpName);
        //        entity.Property(e => e.CreatedBy);
        //        entity.Property(e => e.Id);
        //        entity.Property(e => e.IsDeleted);
        //        entity.Property(e => e.ProposalName); 
        //        entity.Property(e => e.ModifiedBy);
        //        entity.Property(e => e.Status);
        //        entity.Property(e => e.Date);
        //        entity.Property(e => e.DateCreated);
        //        entity.Property(e => e.DateDeleted);
        //        entity.Property(e => e.DateModified);
        //        entity.Property(e => e.DeletedBy);
        //        entity.Property(e => e.Description);
        //    });
        //}
        //}
    }
}
