using GenerateFakeData.Service;
using System;
using System.Diagnostics.CodeAnalysis;
using Xunit;

namespace TestingProjectGenerateFakeData.integration
{
    [ExcludeFromCodeCoverage]  
    public class DateOfBirthTests
    {
        [Fact]
        public void TestRandomDateGeneration()
        {
            //Arrange
            DobService dobService = new DobService();
            DateService dateService = new DateService();
            bool passed = true;
            //Act
            for (int i = 0; i < 100; i++)
            {
                string dateOfBirth = dobService.GenerateDateOfBirth();
                if (!dateService.IsDateValid(Convert.ToInt32($"{dateOfBirth[0]}{dateOfBirth[1]}"), Convert.ToInt32($"{dateOfBirth[2]}{dateOfBirth[3]}"), Convert.ToInt32($"{dateOfBirth[4]}{dateOfBirth[5]}")))
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
