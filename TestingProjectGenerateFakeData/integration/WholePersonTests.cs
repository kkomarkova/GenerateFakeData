using System;
using System.Threading.Tasks;
using GenerateFakeData.Model;
using Xunit;

namespace TestingProjectGenerateFakeData.integration
{
    public class WholePersonTests
    {
        [Fact]
        public async Task FakeDataTest()
        {
            //Arrange
            Person person = new Person();
            //Act
            bool successfulGeneration = await person.GenerateAllInfo();
            //Assert
            Assert.True(successfulGeneration);
            Assert.NotEqual("", person.FullName); //Check if there is a name
            Assert.NotEqual(Gender.Uninitialized, person.Gender); //Check if there is a gender that ends with -male, i.e. male/female TODO: Marek: I refactored, check if this what you meant
            Assert.Equal(10, person.CprNumber.Length); //Checks for a 12-character string
            Assert.Equal(Convert.ToInt64(person.CprNumber), Convert.ToInt64(person.CprNumber)); //Checks if cpr is convertible to number
            Assert.Equal(8, person.PhoneNumber.Length);
            Assert.Equal(Convert.ToInt64(person.PhoneNumber), Convert.ToInt64(person.PhoneNumber));
            Assert.NotEqual("", person.Address.Door);
            Assert.NotEqual("", person.Address.Floor);
            Assert.NotEqual("", person.Address.Street);
            Assert.NotEqual("", person.Address.StreetNumber);
            Assert.NotEqual("", person.Address.City.CityName);
            Assert.Equal(4, person.Address.City.PostalCode.ToString().Length);
            Assert.Equal(6, person.DateOfBirth.Length);
        }
    }
}
