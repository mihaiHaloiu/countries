using APi.Dal.ApiModels;
using CountryModel = Api.Bll.Models.CountryModel;

namespace Api.Bll.Mappers
{
    public interface ICountryMapper
    {
        /// <summary>
        /// Maps a CountryModelDto object to a CountryModelDto one.
        /// </summary>
        CountryModel CountriesResponseModelToCountryModel(CountryModelDto countryModelDto);
    }
}
