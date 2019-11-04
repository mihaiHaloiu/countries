using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;
using Api.Bll.Services;
using Api.Contracts;
using Api.Enums;
using Api.Exceptions;

namespace Api.Controllers
{
    public class CountriesController : ApiController
    {
        private readonly ICountryService _countryService;

        public CountriesController(ICountryService countryService)
        {
            _countryService = countryService;
        }

        /// <summary>
        /// Gets country details by a given country code.
        /// </summary>
        [Route("api/countries/getByCountryCode/{CountryCode}")]
        public async Task<HttpResponseMessage> GetByCountryCode(CountryCodeRequest requestModel)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    var country = await _countryService.GetCountryByCode(requestModel.CountryCode);

                    if (country == null)
                    {
                        return Request.CreateResponse(HttpStatusCode.NotFound, "Country not found");
                    }

                    return Request.CreateResponse(HttpStatusCode.OK, country);
                }
                catch (ApiException e)
                {
                    return Request.CreateResponse(HttpStatusCode.ServiceUnavailable, e.Message);
                }
            }

            return Request.CreateResponse((HttpStatusCode)AdditionalHttpStatusCodes.UnprocessableEntity, "Invalid country code");
        }
    }
}
