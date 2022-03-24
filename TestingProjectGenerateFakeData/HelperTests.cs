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
    }
}
