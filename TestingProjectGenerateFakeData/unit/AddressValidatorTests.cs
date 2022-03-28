using GenerateFakeData.Model;
using GenerateFakeData.Service;
using Xunit;
﻿using System.Diagnostics.CodeAnalysis;


namespace TestingProjectGenerateFakeData.unit
{
    [ExcludeFromCodeCoverage]
    public class AddressValidatorTests
    {
        private readonly AddressService _addressService;

        public AddressValidatorTests()
        {
            _addressService = new AddressService();
        }
        [Theory]
        [InlineData("Thesupremegade", "100", "10", "tv", 9000, "Aalborg")]
        [InlineData("Thesupremestreet", "100", "10", "mf", 9000, "Aalborg")]
        [InlineData("Thesupremestreet", "100F", "15", "st", 9000, "Aalborg")]
        [InlineData("Hahahihigade", "50D", "10", "a-10", 9000, "Aalborg")]

        public void IfValidAddress_ReturnTrue(string street, string streetNumber, string floor, string door, int postalCode, string city)
        {
            bool isValid = _addressService.ValidateAddress(new Address(street, streetNumber, floor, door, new City(postalCode, city)));
            Assert.True(isValid);
        }

        [Theory]
        [InlineData("TheLongestStreetIKnowOf", "50D", "10", "a-10", 9000, "Aalborg")]
        [InlineData("Short", "50D", "10", "a-10", 9000, "Aalborg")]
        [InlineData("Hahahihigade", "1000", "10", "a-10", 9000, "Aalborg")]
        [InlineData("Hahahihigade", "50D", "100", "a-10", 9000, "Aalborg")]
        [InlineData("Hahahihigade", "50D", "10", "a-1000", 9000, "Aalborg")]
        public void IfInvalidAddress_ReturnFalse(string street, string streetNumber, string floor, string door, int postalCode, string city)
        {
            bool isValid = _addressService.ValidateAddress(new Address(street, streetNumber, floor, door, new City(postalCode, city)));
            Assert.False(isValid);
        }
    }
}
