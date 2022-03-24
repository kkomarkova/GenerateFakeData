using GenerateFakeData.Model;
using Xunit;

namespace TestingProjectGenerateFakeData
{
    public class CprValidatorTests
    {
        Person person = new Person();

        #region Validate Cpr Validator

        //10 digits
        [Fact]
        public void IfValidCpr_ReturnTrue()
        {
            string gender = "male";
            string validcprToTest = "0812902221";
            string dateOfBirth = "081290";
            bool isValid = person.ValidateCpr(gender, validcprToTest, dateOfBirth);
            Assert.True(isValid);
        }

        //Starting with DateofBirth
        [Fact]
        public void IfValidCpr_ReturnFalseBecauseDateIsString()
        {
            string gender = "male";
            string invalidDateofBirthToTest = "ddMMyy";
            string dateOfBirth = "222222";

            Assert.ThrowsAny<System.Exception>(() => person.ValidateCpr(
                gender, invalidDateofBirthToTest, dateOfBirth)
            );
        }
        // Zde jsem skoncila :-) TO GO ----> Validatovat Validatory CPR a potom dopsat testy v CprTest class.

        #endregion
    }
}
