namespace APi.Dal.ApiModels
{
    public class CountryModelDto
    {
        public string Id { get; set; }

        public string Iso2code { get; set; }

        public string Name { get; set; }

        public string CapitalCity { get; set; }

        public string Longitude { get; set; }

        public string Latitude { get; set; }

        public RegionModel Region { get; set; }

        public RegionModel AdminRegion { get; set; }

        public RegionModel IncomeLevel { get; set; }

        public RegionModel LendingType { get; set; }
    }
}
