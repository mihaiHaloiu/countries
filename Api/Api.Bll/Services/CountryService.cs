using System.Threading.Tasks;
using Api.Bll.Mappers;
using APi.Dal.Repositories;
using CountryModel = Api.Bll.Models.CountryModel;

namespace Api.Bll.Services
{
    public class CountryService : ICountryService
    {
        private readonly ICountryRepository _countryRepository;
        private readonly ICountryMapper _countryMapper;

        public CountryService(ICountryRepository countryRepository, ICountryMapper countryMapper)
        {
            _countryRepository = countryRepository;
            _countryMapper = countryMapper;
        }

        /// <summary>
        /// Gets country details by a given country code.
        /// </summary>
        public async Task<CountryModel> GetCountryByCode(string countryCode)
        {
            var countriesResponse = await _countryRepository.GetCountryByCode(countryCode);

            if (countriesResponse == null)
            {
                return null;
            }

            var country = _countryMapper.CountriesResponseModelToCountryModel(countriesResponse);
            return country;
        }
    }
}
