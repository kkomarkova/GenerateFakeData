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
        // street
        [InlineData("Thesupremegadeee", "100", "10", "tv", 9000, "Aalborg")]
        [InlineData("Valida", "100", "1", "mf", 9000, "Aalborg")]
        // streetNumber
        [InlineData("Thesupremestreet", "1", "1", "mf", 9000, "Aalborg")]
        [InlineData("Thesupremestreet", "999", "1", "mf", 9000, "Aalborg")]
        // floor
        [InlineData("Thesupremestreet", "1", "st", "mf", 9000, "Aalborg")]
        [InlineData("Thesupremestreet", "1", "1", "mf", 9000, "Aalborg")]
        [InlineData("Thesupremestreet", "1", "99", "mf", 9000, "Aalborg")]
        // door
        [InlineData("Thesupremestreet", "1", "99", "tv", 9000, "Aalborg")]
        [InlineData("Thesupremestreet", "1", "99", "th", 9000, "Aalborg")]
        [InlineData("Thesupremestreet", "1", "99", "1", 9000, "Aalborg")]
        [InlineData("Thesupremestreet", "1", "99", "50", 9000, "Aalborg")]
        [InlineData("Thesupremestreet", "1", "99", "a1", 9000, "Aalborg")]
        [InlineData("Thesupremestreet", "1", "99", "a999", 9000, "Aalborg")]
        [InlineData("Thesupremestreet", "1", "99", "a-1", 9000, "Aalborg")]
        [InlineData("Thesupremestreet", "1", "99", "a-999", 9000, "Aalborg")]

        public void IfValidAddress_ReturnTrue(string street, string streetNumber, string floor, string door, int postalCode, string city)
        {
            bool isValid = _addressService.ValidateAddress(new Address(street, streetNumber, floor, door, new City(postalCode, city)));
            Assert.True(isValid);
        }

        [Theory]
        //street
        [InlineData("TheLongestStreetIKnowOf", "100F", "1", "mf", 9000, "Aalborg")]
        [InlineData("Short", "100F", "1", "mf", 9000, "Aalborg")]
        // streetNumber
        [InlineData("Thesupremestreet", "0", "1", "mf", 9000, "Aalborg")]
        [InlineData("Thesupremestreet", "1000", "1", "mf", 9000, "Aalborg")]
        [InlineData("Thesupremestreet", "0F", "1", "mf", 9000, "Aalborg")]
        [InlineData("Thesupremestreet", "1000F", "1", "mf", 9000, "Aalborg")]
        // floor
        [InlineData("Thesupremestreet", "1", "0", "mf", 9000, "Aalborg")]
        [InlineData("Thesupremestreet", "1", "100", "mf", 9000, "Aalborg")]
        [InlineData("Thesupremestreet", "1", "stuen", "mf", 9000, "Aalborg")]
        // door
        [InlineData("Thesupremestreet", "1", "99", "xd", 9000, "Aalborg")]
        [InlineData("Thesupremestreet", "1", "99", "0", 9000, "Aalborg")]
        [InlineData("Thesupremestreet", "1", "99", "51", 9000, "Aalborg")]
        [InlineData("Thesupremestreet", "1", "99", "a0", 9000, "Aalborg")]
        [InlineData("Thesupremestreet", "1", "99", "a1000", 9000, "Aalborg")]
        [InlineData("Thesupremestreet", "1", "99", "a-1000", 9000, "Aalborg")]
        [InlineData("Thesupremestreet", "1", "99", "a-0", 9000, "Aalborg")]

        
        public void IfInvalidAddress_ReturnFalse(string street, string streetNumber, string floor, string door, int postalCode, string city)
        {
            bool isValid = _addressService.ValidateAddress(new Address(street, streetNumber, floor, door, new City(postalCode, city)));
            Assert.False(isValid);
        }
    }
}
