using System.Threading.Tasks;
using WhiteBrookAPI.Services.InmateService;
using WhiteBrookAPI.Models;
using Xunit;

namespace WhiteBrookAPI.Tests
{
    public class InmateServiceTests
    {
        [Fact]
        public async Task GetSingleInmate_ValidId_ReturnsInmate()
        {
            // Arrange
            var inmateService = new InmateService();

            // Add a test inmate to the list
            var testInmate = new Inmate
            {
                Id = 3,
                Name = "John Doe",
                FirstName = "John",
                LastName = "Doe",
                Place = "Test Place"
            };

            await inmateService.AddInmate(testInmate);

            // Act
            var result = await inmateService.GetSingleInmate(3); // Use the ID of the added inmate

            // Assert
            Assert.NotNull(result);
            Assert.Equal(testInmate.Id, result?.Id);
            Assert.Equal(testInmate.Name, result?.Name);
            Assert.Equal(testInmate.FirstName, result?.FirstName);
            Assert.Equal(testInmate.LastName, result?.LastName);
            Assert.Equal(testInmate.Place, result?.Place);
        }

        // [Fact]
        // public async Task GetSingleInmate_InvalidId_ReturnsNull()
        // {
        //     // Arrange
        //     var inmateService = new InmateService();

        //     // Act
        //     var result = await inmateService.GetSingleInmate(999); // An ID that does not exist

        //     // Assert
        //     Assert.Null(result); // Should return null for a non-existing ID
        // }
    }
}
