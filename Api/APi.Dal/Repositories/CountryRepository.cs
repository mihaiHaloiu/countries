using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using APi.Dal.ApiModels;
using Api.Exceptions;
using Newtonsoft.Json;

namespace APi.Dal.Repositories
{
    public class CountryRepository : ICountryRepository
    {
        private static readonly HttpClient Client = new HttpClient();

        /// <summary>
        /// Consumes an API to get details about a country based on the country code .
        /// </summary>
        /// <returns>Returns details about the matching country</returns>
        public async Task<CountryModelDto> GetCountryByCode(string countryCode)
        {
            try
            {
                HttpResponseMessage response =
                    await Client.GetAsync($"http://api.worldbank.org/v2/country/{countryCode}?format=json");
                response.EnsureSuccessStatusCode();
                string responseBody = await response.Content.ReadAsStringAsync();

                var countriesResponse = JsonConvert.DeserializeObject<CountriesResponseModel>(responseBody);

                if (countriesResponse != null && countriesResponse.Countries.Any())
                {
                    return countriesResponse.Countries.First();
                }

                return null;
            }
            catch (HttpRequestException e)
            {
                throw new ApiException(e.Message);
            }
        }
    }
}
