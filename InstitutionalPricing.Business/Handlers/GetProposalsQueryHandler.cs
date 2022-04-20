using InstitutionalPricing.Business.Queries;
using InstitutionalPricing.Entity;
using MediatR;
using Microsoft.EntityFrameworkCore.Extensions.Internal;
using Microsoft.Extensions.Logging;
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
        private readonly ILogger _logger;

        public GetProposalsQueryHandler(IInstitutionalPricingContext pricingContext, ILogger<GetProposalsQueryHandler> logger)
        {
            _pricingContext = pricingContext;
            _logger = logger;
        }
        public async Task<GetProposalsResult> Handle(GetProposalsQuery query)
        {
            _logger.LogDebug("Fetching Proposals data");
            var getProposalsResult = new GetProposalsResult
            {
                ProposalList = new List<Proposals>()
            };
            try
            {
                var proposalsList = _pricingContext.Proposals != null ?
                    await _pricingContext.Proposals
                    .Select(proposal => new Proposals
                    {
                        Id = proposal.Id,
                        Description = proposal.Description,
                        ProposalName = proposal.ProposalName,
                        CustomerGrpName = proposal.CustomerGrpName,
                        Date = proposal.Date,
                        Status = proposal.Status,
                    }).ToListAsync() :
                    MockData.GetProposals();

                getProposalsResult.ProposalList = proposalsList;
            }
            catch (Exception ex)
            {
                _logger.LogError("An error occurred while fetching proposals");
                throw new System.Exception("An error occurred while fetching proposals",ex);
            }
            return getProposalsResult;
        }

    }
}
