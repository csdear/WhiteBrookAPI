using System.Net.Http;
using Xunit;

namespace WhiteBrookAPI.Tests;


public class UnitTest1
{
    [Fact]
    public void Test1()
    {
        // Arrange
        var expected = 2 + 2;
        
        // Act
        var result = 4;

        // Assert
        Assert.Equal(expected, result);
    }
}