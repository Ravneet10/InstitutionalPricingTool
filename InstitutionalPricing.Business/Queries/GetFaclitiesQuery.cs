using System;
using MediatR;

namespace InstitutionalPricing.Business.Queries
{
    public class GetFaclitiesQuery : IAsyncRequest<GetFacilitiesResult>
    {
        public Guid ProposalId { get; set; }
        public string ProposalName { get; set; }
    }
}
