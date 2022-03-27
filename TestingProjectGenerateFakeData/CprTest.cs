using System;
using Xunit;
using GenerateFakeData.Model;

namespace TestingProjectGenerateFakeData
{
    public class CprTest
    {
        [Fact]
        public void TestIfFemaleCprEven()
        {
            //Arrange
            Person person = new Person();
            //Act
            person.Gender = Gender.Female;
            person.GenerateCprNumber();
            var cpr = Convert.ToInt64(person.CprNumber);
            //Assert
            Assert.True(cpr % 2 == 0);
        }

        [Fact]
        public void TestIfMaleCprUneven()
        {
            //Arrange
            Person person = new Person();
            //Act
            person.Gender = Gender.Male;
            person.GenerateCprNumber();
            var cpr = Convert.ToInt64(person.CprNumber);
            //Assert
            Assert.True(cpr % 2 == 1);
        }
    }
}
