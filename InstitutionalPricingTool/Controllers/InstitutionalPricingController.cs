using InstitutionalPricing.Business;
using InstitutionalPricing.Business.Queries;
using MediatR;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web.Http;
using System.Web.Http.Description;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace InstitutionalPricingTool.Controllers
{
    [RoutePrefix("api/institutionalpricingtool")]
    public class InstitutionalPricingController : ApiController
    {
        private readonly IMediator _mediator;
        private readonly ILogger _logger;

        [HttpGet]
        [Route("getproposals")]
        public async Task<IHttpActionResult> Get()
        {
            _logger.LogDebug("Fetching proposals data");
            var proposalsResponse = await _mediator.SendAsync(new GetProposalsQuery() { });
            return Ok(proposalsResponse);
        }

    }
}
