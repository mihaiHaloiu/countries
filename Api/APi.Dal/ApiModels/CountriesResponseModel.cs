using System.Collections.Generic;
using APi.Dal.JsonConverters;
using Newtonsoft.Json;

namespace APi.Dal.ApiModels
{
    [JsonConverter(typeof(CountriesResponseModelConverter))]
    public class CountriesResponseModel
    {
        public PaginationModel Pagination { get; set; }

        public List<CountryModelDto> Countries { get; set; }
    }
}
