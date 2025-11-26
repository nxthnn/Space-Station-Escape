using System;
using SpaceStationEscape.Game;

namespace SpaceStationEscape.Commands 
{
    public class QuitCommand : ICommand // Command to quit the game
    {
        public string Name => "quit"; // Command name
        public string Description => "Exit the game."; // Command description

        public void Execute(string[] args, GameContext context) // Execute method
        {
            Console.WriteLine("Exiting game..."); // Inform player that the game is exiting
            context.IsRunning = false; // Set the game running flag to false to exit the game loop
        }
    }
}
