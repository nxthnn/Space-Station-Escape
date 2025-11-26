using System;
using SpaceStationEscape.Game;

namespace SpaceStationEscape.Commands
{
    public class HelpCommand : ICommand // HelpCommand class to display available commands
    {
        private readonly CommandParser _parser; // Reference to CommandParser

        public HelpCommand(CommandParser parser) // Constructor for HelpCommand
        {
            _parser = parser;
        }

        public string Name => "help"; // Command name

        public string Description => "Show a list of available commands."; // Command description

        public void Execute(string[] args, GameContext context) // Execute method
        {
            Console.WriteLine("Available commands:"); // Display header

            foreach (var command in _parser.Commands) // Iterate through registered commands
            {
                Console.WriteLine($" - {command.Name} : {command.Description}"); // Display command name and description
            }
        }
    }
}
