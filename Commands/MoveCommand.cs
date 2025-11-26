using System;
using SpaceStationEscape.Game;
using SpaceStationEscape.Rooms;

namespace SpaceStationEscape.Commands
{
    public class MoveCommand : ICommand // Command to move between rooms
    {
        public string Name => "move"; // Command name
        public string Description => "Move to another room. Usage: move <direction>"; // Command description

        public void Execute(string[] args, GameContext context) // Execute method
        {
            if (args.Length < 1)
            {
                Console.WriteLine("Move where? Usage: move <direction>"); // Prompt for direction if not provided
                return;
            }

            var currentRoom = context.CurrentRoom; // Get the current room

            var unfinished = currentRoom.UnfinishedChallengeCount();
            if (unfinished > 0) // Check for unfinished challenges
            {
                var first = currentRoom.GetFirstUnfinishedChallenge();
                if (unfinished == 1) // Check if there is exactly one unfinished challenge
                {
                    Console.WriteLine($"You cannot leave yet. Please solve the challenge: {first?.Description}");
                } // Inform player about the single unfinished challenge
                else
                {
                    Console.WriteLine($"You cannot leave yet. Please solve {unfinished} challenges. First: {first?.Description}");
                } // Inform player about multiple unfinished challenges
                return;
            }

            var direction = args[0]; // Get the direction to move
            var nextRoom = currentRoom.GetExit(direction); // Get the next room in that direction

            if (nextRoom == null)
            {
                Console.WriteLine($"You can't go '{direction}' from here."); // Inform player that the direction is invalid
            }
            else
            {
                context.CurrentRoom = nextRoom; // Update the current room
                Console.Clear(); // Clear the console for the new room display
            }
        }
    }
}
