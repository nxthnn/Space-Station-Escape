using SpaceStationEscape.Core;
using Xunit;

namespace SpaceStationEscape.Tests 
{
    public class PlayerTests 
    {
        [Fact]
        public void TakeDamage_ReducesHealth() // Test for Player.TakeDamage method
        {
            // Arrange
            var player = new Player("Test Player"); // Player constructor takes only name
            
            // Act
            player.TakeDamage(20); // Deal 20 damage
            
            // Assert
            Assert.Equal(80, player.Health); // Health should be reduced to 80 (100 - 20)
        }
    }
}
