using SpaceStationEscape.Rooms;
using SpaceStationEscape.Challenges;
using Xunit;

namespace SpaceStationEscape.Tests
{
    public class MovementTests
    {
        [Fact]
        public void GetExit_ConnectedRoom_ReturnsRoom() // Test for Room.GetExit method with connected room
        {
            // Arrange
            var room1 = new Room("Room 1", "First Room");
            var room2 = new Room("Room 2", "Second Room");

            room1.AddExit("corridor", room2);

            // Act
            var exit = room1.GetExit("corridor");

            // Assert
            Assert.NotNull(exit);
            Assert.Equal(room2, exit);
        }

        [Fact]
        public void GetExit_NonConnectedRoom_ReturnsNull() // Test for Room.GetExit method with no connection
        {
            // Arrange
            var room1 = new Room("Room 1", "First Room");

            // Act
            var exit = room1.GetExit("corridor");

            // Assert
            Assert.Null(exit);
        }
    }
}