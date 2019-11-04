using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Helpers;
using System.Web.Http;
using Api.Bll.Mappers;
using Api.Bll.Models;
using Api.Bll.Services;
using Api.Contracts;
using Api.Controllers;
using APi.Dal.ApiModels;
using APi.Dal.Repositories;
using Api.Exceptions;
using Moq;
using NUnit.Framework;
using Assert = Microsoft.VisualStudio.TestTools.UnitTesting.Assert;

namespace Api.Tests
{
    public class GetCountryByCodeTests
    {

        #region Fields

        private Mock<ICountryRepository> _countryRepository;

        private CountriesController _countriesController;

        #endregion

        #region Properties

        private static CountryModel CountryModel =>
            new CountryModel()
            {
               
                Name = "Brazil",
                CapitalCity = "Brasilia",
                Longitude = -47.9292,
                Latitude = -15.7801,
                Region = "Latin America & Caribbean (all income levels)"
            };

        private static CountryModelDto CountryModelDto =>
            new CountryModelDto()
            {
                Region = new RegionModel()
                {
                    Id = "BRA",
                    Iso2code = "BR",
                    Value = "Latin America & Caribbean (all income levels)"
                },
                Iso2code = "BRA",
                Id = "BRA",
                Name = "Brazil",
                AdminRegion = new RegionModel()
                {
                    Id = "LAC",
                    Iso2code = "XJ",
                    Value = "Latin America & Caribbean (developing only)"
                },
                IncomeLevel = new RegionModel()
                {
                    Id = "UMC",
                    Iso2code = "XT",
                    Value = "Upper middle income"
                },
                LendingType = new RegionModel()
                {
                    Id = "IBD",
                    Iso2code = "XF",
                    Value = "IBRD"
                },
                CapitalCity = "Brasilia",
                Longitude = "-47.9292",
                Latitude = "-15.7801"
            };

        #endregion

        [SetUp]
        protected void SetUp()
        {
            _countryRepository = new Mock<ICountryRepository>();

            var countryMapper = new CountryMapper();

            var countryService = new CountryService(_countryRepository.Object, countryMapper);

            _countriesController = new CountriesController(countryService)
            {
                Request = new HttpRequestMessage(),
                Configuration = new HttpConfiguration()
            };
        }


        #region Test Methods

        [TestCase(
            TestName = "GIVEN a request with an existing countryCode value"
                       + "WHEN Countries/GetCountryByCode endpoint is called "
                       + "THEN the endpoint returns 200 (OK) along with the country details")]
        public async Task GetCountryByCode_ValidCountryCode_ReturnsTheRightResponse()
        {
            //Arrange
            var countryCodeRequest = new CountryCodeRequest()
            {
                CountryCode = "RO"
            };

            _countryRepository.Setup(x => x.GetCountryByCode(countryCodeRequest.CountryCode)).Returns(Task.FromResult(CountryModelDto));

            //Act
            var response = await _countriesController.GetByCountryCode(countryCodeRequest);

            //Assert
            Assert.AreEqual(HttpStatusCode.OK, response.StatusCode);

            var responseObject = GetDynamicObjectFromResponse(response);
            var expectedResponse = CountryModel;

            AssertCountryDetails(expectedResponse, responseObject);
        }

        [TestCase(
            TestName = "GIVEN a valid request that has no matching country for the provided countryCode value"
                       + "WHEN Countries/GetCountryByCode endpoint is called "
                       + "THEN returns 204 (NoContent)")]
        public async Task GetCountryByCode_NoMatchingCountry_ReturnsNoContent()
        {
            //Arrange
            var countryCodeRequest = new CountryCodeRequest()
            {
                CountryCode = "RO"
            };

            _countryRepository.Setup(x => x.GetCountryByCode(countryCodeRequest.CountryCode)).Returns(Task.FromResult<CountryModelDto>(null));

            //Act
            var response = await _countriesController.GetByCountryCode(countryCodeRequest);

            Assert.AreEqual(HttpStatusCode.NoContent, response.StatusCode);
        }

        [TestCase(
            TestName = "GIVEN a valid request"
                       + "WHEN Countries/GetCountryByCode endpoint is called "
                       + "AND an error is thrown when trying to get the country details "
                       + "THEN the endpoint returns 503 (ServiceUnavailable)")]
        public async Task GetCountryByCode_ExceptionOccured_ReturnsServiceUnavailableError()
        {
            //Arrange
            var countryCodeRequest = new CountryCodeRequest()
            {
                CountryCode = "RO"
            };

            _countryRepository.Setup(x => x.GetCountryByCode(countryCodeRequest.CountryCode)).Throws(new ApiException());

            //Act
            var response = await _countriesController.GetByCountryCode(countryCodeRequest);

            Assert.AreEqual(HttpStatusCode.ServiceUnavailable, response.StatusCode);
        }

        #endregion

        #region Methods

        private static void AssertCountryDetails(CountryModel expectedCountryDetails, dynamic actualCountryDetails)
        {
            Assert.AreEqual(expectedCountryDetails.CapitalCity, actualCountryDetails.CapitalCity);
            Assert.AreEqual(expectedCountryDetails.Latitude, (double)actualCountryDetails.Latitude);
            Assert.AreEqual(expectedCountryDetails.Longitude, (double)actualCountryDetails.Longitude);
            Assert.AreEqual(expectedCountryDetails.Name, actualCountryDetails.Name);
            Assert.AreEqual(expectedCountryDetails.Region, actualCountryDetails.Region);
        }

        private static dynamic GetDynamicObjectFromResponse(HttpResponseMessage response)
        {
            var responseContent = response.Content.ReadAsStringAsync();
            var result = responseContent.Result;

            return Json.Decode(result);
        }

        #endregion
    }
}
