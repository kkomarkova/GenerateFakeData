using GenerateFakeData.Service;
using Xunit;
using System;

namespace TestingProjectGenerateFakeData.integration
{
    public class PhoneNumberTests
    {
        [Fact]
        public void TestRandomPhoneNumberGeneration()
        {
            //Arrange
            PhoneNoService phoneNoService = new PhoneNoService();
            bool passed = true;
            //Act
            for (int i = 0; i < 100; i++)
            {
                string phoneNumber = phoneNoService.GenerateRandomPhoneNumber();
                if (!phoneNoService.ValidatePhoneNumber(phoneNumber))
                {
                    passed = false;
                    break;
                }
            }
            //Assert
            Assert.True(passed);

        }
    }
}
