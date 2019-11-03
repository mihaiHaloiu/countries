using Newtonsoft.Json;

namespace APi.Dal.ApiModels
{
    public class PaginationModel
    {
        public int Page { get; set; }

        public int Pages { get; set; }

        [JsonProperty("per_page")]
        public string PerPage { get; set; }

        public string Total { get; set; }
    }
}
