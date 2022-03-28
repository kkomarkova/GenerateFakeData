using System;
using GenerateFakeData.Model;
using GenerateFakeData.Service;
using Xunit;

namespace TestingProjectGenerateFakeData.integration
{
    public class CprTests
    {
        [Theory]
        [InlineData(Gender.Male, 1)]
        [InlineData(Gender.Female, 0)]
        public void TestIfCprLastDigitCorrect(Gender gender, int remainderAfterDivision)
        {
            //Arrange
            Person person = new Person();
            //Act
            person.Gender = gender;
            person.GenerateCprNumber();
            var cpr = Convert.ToInt64(person.CprNumber);
            //Assert
            Assert.True(cpr % 2 == remainderAfterDivision);
        }
        [Fact]
        public void TestIfCprGenerationSuccessful()
        {
            //Arrange
            Person person = new Person();
            CprService cprValidator = new CprService();
            //Act
            person.GenerateCprNumber();
            var isCprValid = cprValidator.ValidateCpr(person.Gender, 
                person.CprNumber, person.DateOfBirth);
            //Assert
            Assert.True(isCprValid);
        }
    }
}
