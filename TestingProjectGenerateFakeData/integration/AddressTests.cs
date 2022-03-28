using System.Threading.Tasks;
using GenerateFakeData.Service;
using Xunit;

namespace TestingProjectGenerateFakeData.integration;

public class AddressTests
{
    [Fact]
    public void IfSuccessfulCityGenerate_ReturnTrue()
    {
        var addressService = new AddressService();
        var randomAddress = addressService.GenerateAddress().Result;
        
        Assert.NotNull(randomAddress.City.CityName);
        Assert.InRange(randomAddress.City.PostalCode, 0, 10000);
    }
    [Fact]
    public async Task IfSuccessfulCityGenerateWithExistingCityList_ReturnTrue()
    {
        var addressService = new AddressService();
        var randomAddress = await addressService.GenerateAddress();
        var regeneratedRandomAddress = await addressService.GenerateAddress();

        Assert.NotEqual(randomAddress.City.PostalCode, regeneratedRandomAddress.City.PostalCode);
        Assert.NotNull(randomAddress);
        Assert.NotNull(regeneratedRandomAddress.City.CityName);
    }
}