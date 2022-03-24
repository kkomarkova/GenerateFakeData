using GenerateFakeData.Model;
using Xunit;

namespace TestingProjectGenerateFakeData
{
    public class PersonTest
    {
        [Fact]
        public void ifNumberHas8Digits_ReturnTrue()
        {
            // arrange 
            var person = new Person();
            
            // act
            person.SetRandomPhoneNumber(); 
            string numberToTest = person.PhoneNumber;
            
            // assert
            Assert.Equal(8, numberToTest.Length);
        }

        [Fact]
        public void IfDoBhas6Digits_ReturnTrue()
        {
            // arrange 
            var person = new Person();

            // act
            person.GenerateDateofBirth();
            string numberToTest = person.DateOfBirth;

            // assert
            Assert.Equal(6, numberToTest.Length);
        }

        [Fact]
        public void IfCprNumberMatchesDoB_AndHas10Digits_ReturnTrue()
        {
            // arrange 
            var person = new Person();

            // act
            person.GenerateDateofBirth();
            string numberToTest = person.DateOfBirth;

            // assert
            Assert.Equal(8, numberToTest.Length);
        }
    }
}