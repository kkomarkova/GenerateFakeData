using System.Diagnostics.CodeAnalysis;
using GenerateFakeData.Model;
using Xunit;

namespace TestingProjectGenerateFakeData.unit;

[ExcludeFromCodeCoverage]
public class NameAndGenderTests
{
    [Fact]
    public void TestWrongJsonFails()
    {
        var generator = new NameGenderGenerator();
        
        var jsonData = generator.GetDataFromJsonString("wrong/path");
        
        Assert.Null(jsonData);
    }
    [Fact]
    public void TestCorrectJson_ReturnsTrue()
    {
        var generator = new NameGenderGenerator();
        var validJson =
            "{\n\"persons\": [\n{\n\"name\": \"Anne\",\n\"surname\": \"Nilsson\",\n\"gender\": \"female\"\n}\n] \n}";
        
        var jsonData = generator.GetDataFromJsonString(validJson);
        
        Assert.NotNull(jsonData);
        Assert.Single(jsonData);
    }
}