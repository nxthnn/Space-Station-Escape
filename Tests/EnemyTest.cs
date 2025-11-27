using SpaceStationEscape.Core;
using Xunit;

namespace SpaceStationEscape.Tests 
{
    public class EnemyTests 
    {
        [Fact]
        public void TakeDamage_ReducesHealth() // Test for Enemy.TakeDamage method
        {
            // Arrange
            var enemy = new Enemy("Test Enemy", 50, attackPower: 5); // Initial health is 50 
            
            // Act
            enemy.TakeDamage(20); // Deal 20 damage
            
            // Assert
            Assert.Equal(30, enemy.Health); // Health should be reduced to 30
        }
    }
}
