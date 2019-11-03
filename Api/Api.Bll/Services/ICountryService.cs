using System.Threading.Tasks;
using Api.Bll.Models;

namespace Api.Bll.Services
{
    public interface ICountryService
    {
        /// <summary>
        /// Returns a country details by a given country code.
        /// </summary>
        Task<CountryModel> GetCountryByCode(string countryCode);
    }
}
