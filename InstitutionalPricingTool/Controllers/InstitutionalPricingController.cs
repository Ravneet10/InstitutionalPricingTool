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

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace InstitutionalPricingTool.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class InstitutionalPricingController : ControllerBase
    {
        //private readonly IDbContextFactory<IInstitutionalPricingContext> _contextFactory;

        private readonly IMediator _mediator;
        public InstitutionalPricingController(IMediator mediator)
        {
            _mediator = mediator;
        }
        [HttpGet]
        [Route("getproposals")]
        public async Task<IActionResult> Get()
        {
            var proposalsResponse = await _mediator.SendAsync(new GetProposalsQuery() { });
            return Ok(proposalsResponse.ProposalList);
        }

        [HttpGet]
        [Route("getFacilities")]
        public async Task<IActionResult> Get(Guid proposalId)
        {
            if (proposalId == Guid.Empty)
            {
                throw new Exception("Invalid Proposal Id");
            }
            var facilityResponse = await _mediator.SendAsync(new GetFaclitiesQuery() { ProposalId=proposalId});
            return Ok(facilityResponse.FacilitiesList);
        }

    }
}
