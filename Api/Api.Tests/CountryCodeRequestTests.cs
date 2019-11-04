using Api.Validators;
using NUnit.Framework;

namespace Api.Tests
{
    public class CountryCodeRequestTests
    {
        [TestCase("a",
            TestName = "GIVEN an invalid value for countryCode that has less than two characters "
                       + "THEN the validator returns false ")]
        [TestCase("abcd",
            TestName = "GIVEN an invalid value for countryCode that has more than three characters "
                       + "THEN the validator returns false ")]
        [TestCase("a2d",
            TestName = "GIVEN an invalid value for countryCode that has numbers "
                       + "THEN the validator returns false ")]
        [TestCase(" ",
            TestName = "GIVEN an empty value for countryCode "
                       + "THEN the validator returns false ")]
        public void CountryCode_InvalidScenario(string countryCode)
        {
            // Arrange
            var countryCodeValidator = new CountryCodeValidator();

            // Act
            var result = countryCodeValidator.IsValid(countryCode);

            // Assert
            Assert.That(result, Is.False);
        }

        [TestCase("ba",
            TestName = "GIVEN a valid value for countryCode  "
                       + "THEN the validator returns true ")]
        [TestCase("bac",
            TestName = "GIVEN a valid value for countryCode  "
                       + "THEN the validator returns true ")]
        public void CountryCode_ValidScenario(string countryCode)
        {
            // Arrange
            var countryCodeValidator = new CountryCodeValidator();

            // Act
            var result = countryCodeValidator.IsValid(countryCode);

            // Assert
            Assert.That(result, Is.True);
        }
    }
}
