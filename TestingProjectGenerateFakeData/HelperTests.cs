using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GenerateFakeData.Model;
using Xunit;

namespace TestingProjectGenerateFakeData
{
    public class HelperTests
    {
        Person person = new Person();

#region Validate PhoneNumber Validator

        //8 digits
        [Fact]
        public void IfValidPhoneNumber_ReturnTrue()
        {   
            string validNumberToTest = "22222222";
            bool isValid = person.ValidatePhoneNumber(validNumberToTest);
            Assert.True(isValid);
        }
        [Fact]
        public void IfValidPhoneNumber_ReturnFalseBecauseEmptyString()
        {
            string validNumberToTest = "";
            bool isValid = person.ValidatePhoneNumber(validNumberToTest);
            Assert.False(isValid);
        }
        [Fact]
        public void IfValidPhoneNumber_ReturnFalseBecauseInvalidString()
        {
            string validNumberToTest = "xxx";
            bool isValid = person.ValidatePhoneNumber(validNumberToTest);
            Assert.False(isValid);
        }
        [Fact]
        public void IfValidPhoneNumber_ReturnFalseBecauseInvalidStartingNumber()
        {
            string validNumberToTest = "99999999";
            bool isValid = person.ValidatePhoneNumber(validNumberToTest);
            Assert.False(isValid);
        }
        [Fact]
        public void IfValidPhoneNumber_ReturnFalseBecauseInvalidLength()
        {
            string validNumberToTest = "222222222"; //valid starter, 9 numbers
            bool isValid = person.ValidatePhoneNumber(validNumberToTest);
            Assert.False(isValid);
        }
        #endregion

        #region Validate Cpr Validator

        //10 digits
        [Fact]
        public void IfValidCpr_ReturnTrue()
        {
            string validcprToTest = "2222222222";
            bool isValid = person.ValidatePhoneNumber(validcprToTest);
            Assert.True(isValid);
        }

        //Starting with DateofBirth
        [Fact]
        public void IfValidCpr_ReturnFalseBecauseNotStartingwithDateofBirth()
        {
            string validDateofBirthToTest = "ddMMyy";
            bool isValid = person.ValidatePhoneNumber(validDateofBirthToTest);
            Assert.False(isValid);
        }
        // Zde jsem skoncila :-) TO GO ----> Validatovat Validatory CPR a potom dopsat testy v CprTest class.

        #endregion
    }
}
