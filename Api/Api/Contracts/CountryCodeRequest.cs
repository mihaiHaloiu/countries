using System.Web.Http;
using Api.Validators;

namespace Api.Contracts
{
    [FromUri]
    public class CountryCodeRequest
    {
        [CountryCodeValidator]
        public string CountryCode { get; set; }
    }
}