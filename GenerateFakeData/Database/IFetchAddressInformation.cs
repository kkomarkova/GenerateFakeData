using GenerateFakeData.Model;

namespace GenerateFakeData.Database;

public interface IFetchAddressInformation
{
    Task<(bool success, List<City>)> FetchCityInformation();
}