using SpaceStationEscape.Core;
using Xunit;

namespace SpaceStationEscape.Tests
{
    public class EnemyTests
    {
        [Fact]
        public void TakeDamage_ReducesHealth()
        {
            // Arrange
            var enemy = new Enemy("Test Enemy", 50, attackPower: 5);
            
            // Act
            enemy.TakeDamage(20);
            
            // Assert
            Assert.Equal(30, enemy.Health);
        }
    }
}
