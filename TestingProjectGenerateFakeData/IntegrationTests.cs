﻿using GenerateFakeData.Model;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace TestingProjectGenerateFakeData
{
    public class IntegrationTests
    {
        [Fact]
        public async Task FakeDataTest()
        {
            //Arrange
            Person person = new Person();
            //Act
            await person.GenerateAllInfo();
            //Assert
            Assert.NotEqual("", person.FullName); //Check if there is a name
            Assert.EndsWith("male", person.Gender); //Check if there is a gender that ends with -male, i.e. male/female
            Assert.Equal(10, person.CprNumber.Length); //Checks for a 12-character string
            Assert.Equal(Convert.ToInt64(person.CprNumber), Convert.ToInt64(person.CprNumber)); //Checks if cpr is convertible to number
            Assert.Equal(8, person.PhoneNumber.Length);
            Assert.Equal(Convert.ToInt64(person.PhoneNumber), Convert.ToInt64(person.PhoneNumber));
            Assert.NotEqual("", person.Door);
            Assert.NotEqual("", person.Floor);
            Assert.NotEqual("", person.Street);
            Assert.NotEqual("", person.StreetNumber);
            Assert.NotEqual("", person.CityName);
            Assert.Equal(4, person.PostalCode.ToString().Length);
            Assert.Equal(6, person.DateOfBirth.Length);
        }
    }
}