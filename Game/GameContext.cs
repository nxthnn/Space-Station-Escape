using SpaceStationEscape.Core;
using SpaceStationEscape.Rooms;

namespace SpaceStationEscape.Game 
{
    public class GameContext // Represents the current state of the game
    {
        public Player Player { get; } // The player character
        public Room CurrentRoom { get; set; } // The current room the player is in
        public bool IsRunning { get; set; } = true; // Indicates if the game is running

        public GameContext(Player player, Room startingRoom) // Constructor to initialize the game context
        {
            Player = player; 
            CurrentRoom = startingRoom;
        }
    }
}
