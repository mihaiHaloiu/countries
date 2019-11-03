using System;
using System.Collections.Generic;
using APi.Dal.ApiModels;
using Newtonsoft.Json;

namespace APi.Dal.JsonConverters
{
    public class CountriesResponseModelConverter : JsonConverter
    {

        public override bool CanConvert(Type objectType)
        {
            if (objectType == typeof(CountriesResponseModel))
            {
                return true;
            }

            return false;
        }

        public override object ReadJson(JsonReader reader, Type objectType
            , object existingValue, JsonSerializer serializer)
        {
            try
            {
                var model = new CountriesResponseModel();

                reader.Read(); //first object

                model.Pagination = serializer.Deserialize<PaginationModel>(reader);

                reader.Read(); //array

                model.Countries = serializer.Deserialize<List<CountryModelDto>>(reader);

                reader.Read(); //end array

                return model;
            }
            catch (Exception)
            {
                return null;
            }
        }

        public override void WriteJson(JsonWriter writer, object value
            , JsonSerializer serializer)
        {
            throw new NotImplementedException();
        }
    }
}
