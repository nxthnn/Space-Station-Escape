using SpaceStationEscape.Rooms;
using SpaceStationEscape.Challenges;
using Xunit;

namespace SpaceStationEscape.Tests
{
    // Simple fake challenge for testing purposes
    public class FakeChallenge : IChallenge
    {
        public string Description { get; set; } = "Fake"; 
        public bool IsCompleted { get; set; }

        public void Attempt()
        {
            // Not needed for these tests
        }
    }

    public class RoomTests
    {
        [Fact]
        public void Room_IsNotCompleted_WhenAnyChallengeIncomplete() // Test for Room.IsCompleted property
        {
            // Arrange
            var room = new Room("Test Room", "Description");
            var c1 = new FakeChallenge { IsCompleted = true };
            var c2 = new FakeChallenge { IsCompleted = false };

            room.AddChallenge(c1);
            room.AddChallenge(c2);

            // Act + Assert
            Assert.False(room.IsCompleted);
        }

        [Fact]
        public void Room_IsCompleted_WhenAllChallengesComplete()
        {
            // Arrange
            var room = new Room("Test Room", "Description");
            var c1 = new FakeChallenge { IsCompleted = true };
            var c2 = new FakeChallenge { IsCompleted = true };

            room.AddChallenge(c1);
            room.AddChallenge(c2);

            // Act + Assert
            Assert.True(room.IsCompleted);
        }
    }
}
