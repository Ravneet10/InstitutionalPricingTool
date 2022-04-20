using InstitutionalPricing.Business.Queries;
using InstitutionalPricing.Entity;
using MediatR;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;

namespace InstitutionalPricing.Business.Handlers
{
    public class GetFacilitiesQueryHandler : IAsyncRequestHandler<GetFaclitiesQuery, GetFacilitiesResult>
    {
        private readonly IInstitutionalPricingContext _pricingContext;
        private readonly ILogger _logger;

        public GetFacilitiesQueryHandler(IInstitutionalPricingContext pricingContext, ILogger<GetFacilitiesQueryHandler> logger)
        {
            _pricingContext = pricingContext;
            _logger = logger;
        }
        public async Task<GetFacilitiesResult> Handle(GetFaclitiesQuery query)
        {
            _logger.LogDebug("Fetching Facilities data");
            var facilitiesResult = new GetFacilitiesResult
            {
                FacilitiesList = new List<Facilities>()
            };
            try
            {
                var facilities = _pricingContext.Facilities != null ?
                   await _pricingContext.Facilities.Where(x => x.ProposalId == query.ProposalId)
                    .Select(facility => new Facilities
                    {
                        Id = facility.Id,
                        FacilityName = facility.FacilityName,
                        BookingCountry = facility.BookingCountry,
                        Limit = facility.Limit,
                        MaturityDate = facility.MaturityDate,
                        StartDate = facility.StartDate,
                        Currency = facility.Currency
                    }).ToListAsync() :
                    MockData.GetFacilities();

                facilitiesResult.FacilitiesList = facilities;
            }
            catch(Exception ex)
            {
                _logger.LogError("An error occurred while fetching facilities");
                throw new System.Exception("An error occurred while fetching facilities",ex);
            }
            return facilitiesResult;
        }

    }

}
