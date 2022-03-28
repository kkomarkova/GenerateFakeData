using System.Diagnostics.CodeAnalysis;
using GenerateFakeData.Model;
using GenerateFakeData.Service;
using Xunit;

namespace TestingProjectGenerateFakeData.unit
{
    [ExcludeFromCodeCoverage]  
    public class CprValidatorTests
    {
        private readonly CprService _cprGenerator;

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
        // date of birth too short
        [InlineData(Gender.Male, "0812902229", "08129")]
        // invalid date of birth provided (31st February) 
        [InlineData(Gender.Male, "3102962229", "310296")]
        // gender not initialized yet
        [InlineData(Gender.Uninitialized, "0812902228", "081290")]
        // no data provided
        [InlineData(Gender.Uninitialized, "", "")]
        // date of birth not a numeric string
        [InlineData(Gender.Male, "222222", "ddMMyy")]
        // CPR not a numeric string
        [InlineData(Gender.Male, "nonNumericCPR", "081290")]
        // non-numeric date of birth can't be part of CPR
        [InlineData(Gender.Male, "ddMMyy2222", "ddMMyy")]
        public void IfInvalidCpr_ReturnTrue(Gender gender, string cprNumber, string dateOfBirth)
        {
            bool isValid = _cprGenerator.ValidateCpr(gender, cprNumber, dateOfBirth);
            Assert.False(isValid);
        }
    }
}
