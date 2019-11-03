using System.Threading.Tasks;
using APi.Dal.ApiModels;

namespace APi.Dal.Repositories
{
    public interface ICountryRepository
    {
        /// <summary>
        /// Consumes an API to get details about a country based on the country code .
        /// </summary>
        /// <returns>Returns details about the matching country</returns>
        Task<CountryModelDto> GetCountryByCode(string countryCode);
    }
}
