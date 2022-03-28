using GenerateFakeData.Model;
using GenerateFakeData.Service;
using Xunit;

namespace TestingProjectGenerateFakeData.unit
{
    public class DateOfBirthValidatorTests
    {
        [Theory]
        [InlineData(01, 01, 01)]
        [InlineData(01, 01, 2022)]
        [InlineData(01, 12, 2022)]
        [InlineData(31, 01, 2022)]
        [InlineData(28, 02, 2022)]
        [InlineData(29, 02, 2020)]
        [InlineData(30, 04, 2022)]
        public void TestValidDates(int day, int month, int year)
        {
            //Arrange
            DateService dateService = new DateService();
            //Act
            bool passed = dateService.IsDateValid(day, month, year);
            //Assert
            Assert.True(passed);
        }

        [Theory]
        [InlineData(01, 01, 00)]
        [InlineData(01, 01, 2023)]
        [InlineData(01, 00, 2022)]
        [InlineData(01, 13, 2022)]
        [InlineData(32, 01, 2022)]
        [InlineData(29, 02, 2022)]
        [InlineData(30, 02, 2022)]
        [InlineData(31, 04, 2022)]
        public void TestInvalidDates(int day, int month, int year)
        {
            //Arrange
            DateService dateService = new DateService();
            //Act
            bool passed = dateService.IsDateValid(day, month, year);
            //Assert
            Assert.True(!passed);
        }
    }
}
