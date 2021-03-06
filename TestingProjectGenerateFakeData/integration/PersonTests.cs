using System.Diagnostics.CodeAnalysis;
using GenerateFakeData.Model;
using Xunit;

namespace TestingProjectGenerateFakeData.integration
{
    [ExcludeFromCodeCoverage]  
    public class PersonTests
    {
        // to test one by one:
        // phoneNumber DONE, DoB, CPR, 
        //Black-box testing 
        //Equivalence partitioning - 3 sets of test condition into the group

        #region PhoneNumberTests
        //Equivalence partitioning Phone Number
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
        public void IfDoBHas6Digits_ReturnTrue()
        {
            // arrange 
            var person = new Person();

            // act
            person.GenerateDateOfBirth();
            string numberToTest = person.DateOfBirth;

            // assert
            Assert.Equal(6, numberToTest.Length);
        }
    }
}