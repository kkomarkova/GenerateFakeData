using GenerateFakeData.Model;
using GenerateFakeData.Service;
using Xunit;

namespace TestingProjectGenerateFakeData
{
    public class CprValidatorTests
    {
        private readonly CprService _cprGenerator = new CprService();

        #region Validate Cpr Validator

        //10 digits
        [Fact]
        public void IfValidCpr_ReturnTrue()
        {
            const Gender gender = Gender.Male;
            const string validCprToTest = "0812902221";
            const string dateOfBirth = "081290";
            bool isValid = _cprGenerator.ValidateCpr(gender, validCprToTest, dateOfBirth);
            Assert.True(isValid);
        }

        //Starting with DateOfBirth
        [Fact]
        public void IfValidCpr_ReturnFalseBecauseDateIsString()
        {
            const Gender gender = Gender.Male;
            const string invalidDateOfBirthToTest = "ddMMyy";
            const string dateOfBirth = "222222";

            Assert.ThrowsAny<System.Exception>(() => _cprGenerator.ValidateCpr(
                gender, invalidDateOfBirthToTest, dateOfBirth)
            );
        }
        // Zde jsem skoncila :-) TO GO ----> Validatovat Validatory CPR a potom dopsat testy v CprTest class.

        #endregion
    }
}
