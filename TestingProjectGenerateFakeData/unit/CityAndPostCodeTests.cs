using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using GenerateFakeData.Database;
using GenerateFakeData.Model;
using GenerateFakeData.Service;
using Xunit;
using Moq;

namespace TestingProjectGenerateFakeData.unit;

[ExcludeFromCodeCoverage] 
public class CityAndPostCodeTests
{
    // TODO: consider testing if branch from line 127
    
    [Fact]
    public void IfSuccessfulCityGenerate_ReturnTrue()
    {
        var testCityArray = new List<City>();
        var testCity1 = new City( 5370, "Mesinge");
        testCityArray.Add(testCity1);
        var mockDatabaseAccess = new Mock<IFetchAddressInformation>();
        mockDatabaseAccess.Setup(x 
            => x.FetchCityInformation()).ReturnsAsync((true, testCityArray));
        
        AddressService mockAddressService = new AddressService(mockDatabaseAccess.Object);
        var (isSuccess, cityName, postalCode) = mockAddressService.GenerateCity().Result;
        Assert.True(isSuccess);
        Assert.Equal(testCity1.CityName, cityName);
        Assert.Equal(testCity1.PostalCode, postalCode);
    }
}