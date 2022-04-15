using InstitutionalPricing.Business.Queries;
using InstitutionalPricing.Entity;
using MediatR;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InstitutionalPricing.Business.Handlers
{
    public class GetProposalsQueryHandler : IAsyncRequestHandler<GetProposalsQuery, GetProposalsResult>
    {
        private readonly IInstitutionalPricingContext _pricingContext;

        public GetProposalsQueryHandler(IInstitutionalPricingContext pricingContext)
        {
            _pricingContext = pricingContext;
        }
        public async Task<GetProposalsResult> Handle(GetProposalsQuery query)
        {
            var getProposalsResult = new GetProposalsResult
            {
                ProposalList = new List<Proposals>()
            };

            var clientLeaveReasonsQuery = _pricingContext.Proposals.ToListAsync();

            var results = await _pricingContext.Proposals
                .Select(proposal => new Proposals
                {
                    Id = proposal.Id,
                    Description = proposal.Description,
                    ProposalName = proposal.ProposalName,
                    CustomerGrpName = proposal.CustomerGrpName,
                    Date = proposal.Date,
                    Status = proposal.Status,
                }).ToListAsync();

            getProposalsResult.ProposalList = results;
            return getProposalsResult;
        }

    }
}
