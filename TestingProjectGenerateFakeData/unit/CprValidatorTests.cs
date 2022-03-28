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
        [Theory]
        [InlineData(Gender.Male, "0812902221", "081290")]
        [InlineData(Gender.Male, "0812902223", "081290")]
        [InlineData(Gender.Male, "0812902225", "081290")]
        [InlineData(Gender.Male, "0812902227", "081290")]
        [InlineData(Gender.Male, "0812902229", "081290")]
        [InlineData(Gender.Female, "1606668888", "160666")]
        public void IfValidCpr_ReturnTrue(Gender gender, string cprNumber, string dateOfBirth)
        {
            bool isValid = _cprGenerator.ValidateCpr(gender, cprNumber, dateOfBirth);
            Assert.True(isValid);
        }

        [Theory]
        // last digit doesn't match gender
        [InlineData(Gender.Male, "0812902220", "081290")]
        [InlineData(Gender.Male, "0812902222", "081290")]
        [InlineData(Gender.Male, "0812902224", "081290")]
        [InlineData(Gender.Male, "0812902226", "081290")]
        [InlineData(Gender.Male, "0812902228", "081290")]
        [InlineData(Gender.Female, "1606669999", "160666")]
        // date of birth isn't included in CPR
        [InlineData(Gender.Male, "0812902228", "000000")]
        // no CPR provided
        [InlineData(Gender.Male, "", "000000")]
        // CPR is too long (11 chars)
        [InlineData(Gender.Uninitialized, "08129022281", "081290")]
        // no date of birth provided
        [InlineData(Gender.Male, "0812902229", "")]
        // invalid date of birth provided (31st February) 
        [InlineData(Gender.Male, "3102962229", "310296")]
        // gender not initialized yet
        [InlineData(Gender.Uninitialized, "0812902228", "081290")]
        // no data provided
        [InlineData(Gender.Uninitialized, "", "")]
        public void IfInvalidCpr_ReturnTrue(Gender gender, string cprNumber, string dateOfBirth)
        {
            bool isValid = _cprGenerator.ValidateCpr(gender, cprNumber, dateOfBirth);
            Assert.False(isValid);
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
