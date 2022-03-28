using System.Diagnostics.CodeAnalysis;
using GenerateFakeData.Model;
using Xunit;

namespace TestingProjectGenerateFakeData.unit;

[ExcludeFromCodeCoverage]
public class NameAndGenderTests
{
    [Fact]
    public void TestWrongPathFails()
    {
        var generator = new NameGenderGenerator();
        
        var jsonData = generator.GetDataFromJsonFile("wrong/path");
        
        Assert.Null(jsonData);
    }
}