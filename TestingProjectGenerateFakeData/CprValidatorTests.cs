using GenerateFakeData.Model;
using GenerateFakeData.Service;
using Xunit;

namespace TestingProjectGenerateFakeData
{
    public class CprValidatorTests
    {
        CprService cprGenerator = new CprService();

        #region Validate Cpr Validator

        //10 digits
        [Fact]
        public void IfValidCpr_ReturnTrue()
        {
            Gender gender = Gender.Male;
            string validCprToTest = "0812902221";
            string dateOfBirth = "081290";
            bool isValid = cprGenerator.ValidateCpr(gender, validCprToTest, dateOfBirth);
            Assert.True(isValid);
        }

        //Starting with DateOfBirth
        [Fact]
        public void IfValidCpr_ReturnFalseBecauseDateIsString()
        {
            Gender gender = Gender.Male;
            string invalidDateOfBirthToTest = "ddMMyy";
            string dateOfBirth = "222222";

            Assert.ThrowsAny<System.Exception>(() => cprGenerator.ValidateCpr(
                gender, invalidDateOfBirthToTest, dateOfBirth)
            );
        }
        // Zde jsem skoncila :-) TO GO ----> Validatovat Validatory CPR a potom dopsat testy v CprTest class.

        #endregion
    }
}
