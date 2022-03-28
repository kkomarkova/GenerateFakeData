using GenerateFakeData.Service;
using Xunit;

namespace TestingProjectGenerateFakeData
{
    public class PhoneValidatorTests
    {
        private readonly PhoneNoService _phoneGenerator = new();

#region Validate PhoneNumber Validator

        //8 digits
        [Fact]
        public void IfValidPhoneNumber_ReturnTrue()
        {   
            const string validNumberToTest = "22222222";
            bool isValid = _phoneGenerator.ValidatePhoneNumber(validNumberToTest);
            Assert.True(isValid);
        }
        [Fact]
        public void IfValidPhoneNumber_ReturnFalseBecauseEmptyString()
        {
            const string validNumberToTest = "";
            bool isValid = _phoneGenerator.ValidatePhoneNumber(validNumberToTest);
            Assert.False(isValid);
        }
        [Fact]
        public void IfValidPhoneNumber_ReturnFalseBecauseInvalidString()
        {
            const string validNumberToTest = "xxx";
            bool isValid = _phoneGenerator.ValidatePhoneNumber(validNumberToTest);
            Assert.False(isValid);
        }
        [Fact]
        public void IfValidPhoneNumber_ReturnFalseBecauseInvalidStartingNumber()
        {
            const string validNumberToTest = "99999999";
            bool isValid = _phoneGenerator.ValidatePhoneNumber(validNumberToTest);
            Assert.False(isValid);
        }
        [Fact]
        public void IfValidPhoneNumber_ReturnFalseBecauseInvalidLength()
        {
            const string validNumberToTest = "222222222"; //valid starter, 9 numbers
            bool isValid = _phoneGenerator.ValidatePhoneNumber(validNumberToTest);
            Assert.False(isValid);
        }
        #endregion
    }
}
