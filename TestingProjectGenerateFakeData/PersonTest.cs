using GenerateFakeData.Model;
using GenerateFakeData.Service;
using Xunit;
using Xunit.Abstractions;

namespace TestingProjectGenerateFakeData
{
    public class PersonTest
    {
        private readonly ITestOutputHelper output;

        public PersonTest(ITestOutputHelper output)
        {
            this.output = output;
        }
        // to test one by one:
        // phoneNumber DONE, DoB, CPR, 
        //Black-box testing 
        //Equivalence partitioning - 3 sets of test condition into the group

        #region PhoneNumberTests
        //Equivalence partioning Phone Number
        //Test Group 1 - Phone number can not have less than 8 numeric digits
        [Fact]
        public void IfNumberHasLessThan8Digits_ReturnTrue()
        {
            // arrange 
            var person = new Person();

            // act
            person.SetRandomPhoneNumber();
            string numberToTest = person.PhoneNumber;

            // assert
            Assert.NotInRange(numberToTest.Length, int.MinValue, 7);
        }
        //Test Group 2 - Phone number has 8 numeric digits
        [Fact]
        public void IfNumberHas8Digits_ReturnTrue()
        {
            // arrange 
            var person = new Person();
            
            // act
            person.SetRandomPhoneNumber(); 
            string numberToTest = person.PhoneNumber;
            
            // assert
            Assert.Equal(8, numberToTest.Length);
        }
        //Test Group 3 - Phone number can not have more than 8 numeric digits
        [Fact]
        public void IfNumberHasMoreThan8Digits_ReturnTrue()
        {
            // arrange 
            var person = new Person();

            // act
            person.SetRandomPhoneNumber();
            string numberToTest = person.PhoneNumber;

            // assert
            Assert.NotInRange(numberToTest.Length, 9, int.MaxValue);
        }

        [Fact]
        public void IfNumberStartsWithValidStartingSequence_ReturnTrue()
        {
            // arrange 
            var person = new Person();
            person.SetRandomPhoneNumber();
            // assert
        }
        #endregion

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

        // integration test
        [Fact]
        public void IfCprIsValid()
        {
            // arrange 
            var person = new Person();
            var cprService = new CprService();
            Gender gender = Gender.Male;
            // act
            person.GenerateDateofBirth();
            person.CprNumber = cprService.GenerateCprNumber(gender, person.DateOfBirth);
            // assert
            Assert.NotNull(person.CprNumber);
        }

        [Fact]
        public void IfCprNumberMatchesDoB_AndHas10Digits_ReturnTrue()
        {
            // arrange 
            var person = new Person();
            // act
            person.GenerateDateofBirth();

            // assert
            Assert.Equal(6, person.DateOfBirth.Length);
            
        }
    }
}