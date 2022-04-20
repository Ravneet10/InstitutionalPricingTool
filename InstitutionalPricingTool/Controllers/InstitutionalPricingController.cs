using InstitutionalPricing.Business;
using InstitutionalPricing.Business.Queries;
using Microsoft.AspNetCore.Mvc;
using MediatR;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web.Http.Description;
using System.Data.Entity.Infrastructure;
using InstitutionalPricing.Entity;

namespace InstitutionalPricingTool.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class InstitutionalPricingController : ControllerBase
    {
        private readonly IMediator _mediator;
        private readonly ILogger _logger;

        public InstitutionalPricingController(IMediator mediator, ILogger<InstitutionalPricingController> logger)
        {
            _mediator = mediator;
            _logger = logger;
        }
        [HttpGet]
        [Route("getproposals")]
        public async Task<IActionResult> Get()
        {
            _logger.LogDebug("Fetch proposals list");
            var proposalsResponse = await _mediator.SendAsync(new GetProposalsQuery() { });
            return Ok(proposalsResponse.ProposalList);
        }

        [HttpGet]
        [Route("getFacilities")]
        public async Task<IActionResult> Get(Guid proposalId)
        {
            if(proposalId == Guid.Empty)
            {
                _logger.LogError("Invalid proposal Id");
                throw new System.Exception("Invalid Proposal Id");
            }
            _logger.LogDebug("Fetch facilities data");
            var facilityResponse = await _mediator.SendAsync(new GetFaclitiesQuery() { ProposalId=proposalId});
            return Ok(facilityResponse.FacilitiesList);
        }

    }
}
