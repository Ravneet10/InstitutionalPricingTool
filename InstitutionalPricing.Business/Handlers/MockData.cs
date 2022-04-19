using System;
using System.Collections.Generic;
using System.Text;

namespace InstitutionalPricing.Business.Handlers
{
    public static class MockData
    {
        public static List<Proposals> GetProposals()
        {
            List<Proposals> proposals = new List<Proposals>();

            proposals.Add(new Proposals
            {
                Id = Guid.NewGuid(),
                Description = "Detailed description1",
                ProposalName = "proposal1",
                CustomerGrpName = "customerGrpName1",
                Date = DateTime.Now,
                Status = "In Preparation",
            });
            proposals.Add(new Proposals
            {
                Id = Guid.NewGuid(),
                Description = "Detailed description2",
                ProposalName = "proposal2",
                CustomerGrpName = "customerGrpName2",
                Date = DateTime.Now,
                Status = "Approved",
            });
            proposals.Add(new Proposals
            {
                Id = Guid.NewGuid(),
                Description = "Detailed description3",
                ProposalName = "proposal3",
                CustomerGrpName = "customerGrpName3",
                Date = DateTime.Now,
                Status = "In Support",
            });
            proposals.Add(new Proposals
            {
                Id = Guid.NewGuid(),
                Description = "Detailed description4",
                ProposalName = "proposal4",
                CustomerGrpName = "customerGrpName4",
                Date = DateTime.Now,
                Status = "In Support",
            });
            proposals.Add(new Proposals
            {
                Id = Guid.NewGuid(),
                Description = "Detailed description5",
                ProposalName = "proposal5",
                CustomerGrpName = "customerGrpName5",
                Date = DateTime.Now,
                Status = "In Preparation",
            });
            return proposals;
        }
        public static List<Facilities> GetFacilities()
        {
            List<Facilities> facilities = new List<Facilities>();

            facilities.Add(new Facilities
            {
                Id = Guid.NewGuid(),
                ProposalName = "test",
                MaturityDate = DateTime.Now,
                StartDate = DateTime.Now,
                BookingCountry = "Australia",
                Currency = "AUD",
                FacilityName = "Facility1",
                Limit = 225000.00M
            });
            facilities.Add(new Facilities
            {
                Id = Guid.NewGuid(),
                ProposalName = "test",
                MaturityDate = DateTime.Now,
                StartDate = DateTime.Now,
                BookingCountry = "India",
                Currency = "IND",
                FacilityName = "Facility2",
                Limit = 225000.00M
            });
            facilities.Add(new Facilities
            {
                Id = Guid.NewGuid(),
                ProposalName = "test",
                MaturityDate = DateTime.Now,
                StartDate = DateTime.Now,
                BookingCountry = "New Zealand",
                Currency = "NZD",
                FacilityName = "Facility3",
                Limit = 225000.00M
            });
            facilities.Add(new Facilities
            {
                Id = Guid.NewGuid(),
                ProposalName = "test",
                MaturityDate = DateTime.Now,
                StartDate = DateTime.Now,
                BookingCountry = "America",
                Currency = "USD",
                FacilityName = "Facility4",
                Limit = 225000.00M
            });

            return facilities;
        }
    }
}
