using System.Diagnostics.CodeAnalysis;
using GenerateFakeData.Model;
using Xunit;

namespace TestingProjectGenerateFakeData.integration;
[ExcludeFromCodeCoverage]
public class NameAndGenderTests
{
    [Fact]
    public void TestRandomNameAndGenderGeneration()
    {
        //Arrange
        NameGenderGenerator generator = new();
        
        //Act
        bool successfulGeneration = generator.GetRandomPerson(out string firstName,
            out string lastName, out Gender gender);

        //Assert
        Assert.True(successfulGeneration);
        Assert.NotNull(firstName);
        Assert.NotNull(lastName);
    }
}