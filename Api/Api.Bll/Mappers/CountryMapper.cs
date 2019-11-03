using System;
using System.Linq;
using APi.Dal.ApiModels;
using CountryModel = Api.Bll.Models.CountryModel;


namespace Api.Bll.Mappers
{
    public class CountryMapper : ICountryMapper
    {
        /// <summary>
        /// Maps a CountryModelDto object to a CountryModelDto one.
        /// </summary>
        public CountryModel CountriesResponseModelToCountryModel(CountryModelDto countryModelDto)
        {
            var country = new CountryModel
            {
                Name = countryModelDto.Name,
                Region = countryModelDto.Region.Value,
                CapitalCity = countryModelDto.CapitalCity,
                Longitude = Convert.ToDouble(countryModelDto.Longitude),
                Latitude = Convert.ToDouble(countryModelDto.Latitude)
            };

            return country;
        }
    }
}
