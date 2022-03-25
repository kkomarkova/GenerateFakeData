using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;
using Xunit.Abstractions;
using GenerateFakeData.Model;

namespace TestingProjectGenerateFakeData
{
    public class CprTest
    {
        [Fact]
        public void TestIfFemaleCPREven()
        {
            //Arrange
            Person person = new Person();
            int cpr;
            //Act
            person.Gender = "female";
            person.GenerateCprNumber();
            cpr = Convert.ToInt32(person.CprNumber);
            //Assert
            Assert.True(cpr % 2 == 0);
        }

        [Fact]
        public void TestIfMaleCPRUneven()
        {
            //Arrange
            Person person = new Person();
            int cpr;
            //Act
            person.Gender = "male";
            person.GenerateCprNumber();
            cpr = Convert.ToInt32(person.CprNumber);
            //Assert
            Assert.True(cpr % 2 == 1);
        }
    }
}
