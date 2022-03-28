using System;
using System.Diagnostics.CodeAnalysis;
using GenerateFakeData.Model;
using GenerateFakeData.Service;
using Xunit;

namespace TestingProjectGenerateFakeData.integration
{
    [ExcludeFromCodeCoverage]  
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
        [Fact]
        public void IfCprIsValidWithDefinedDoBAndGender()
        {
            // arrange 
            var person = new Person();
            var cprService = new CprService();
            Gender gender = Gender.Male;
            // act
            person.GenerateDateOfBirth();
            person.CprNumber = cprService.GenerateCprNumber(gender, person.DateOfBirth);
            // assert
            Assert.NotNull(person.CprNumber);
        }
        [Theory]
        [InlineData("08080")]
        public void TestIfCprIncorrect(string dateOfBirth)
        {
            //Arrange
            Person person = new Person();
            CprService cprValidator = new CprService();
            //Act
            person.DateOfBirth = dateOfBirth;
            person.GenerateCprNumber();
            var isCprValid = cprValidator.ValidateCpr(person.Gender, 
                person.CprNumber, person.DateOfBirth);
            //Assert
            Assert.Null(person.CprNumber);
            Assert.False(isCprValid);
        }
    }
}
