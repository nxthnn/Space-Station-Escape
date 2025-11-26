using System;
using System.Collections.Generic;


namespace SpaceStationEscape.Commands // CommandParser class to manage commands
{
    public class CommandParser // CommandParser class
    {
        private readonly Dictionary<string, ICommand> _commands =
            new Dictionary<string, ICommand>(StringComparer.OrdinalIgnoreCase); // Case-insensitive command storage

        public void Register(ICommand command)
        {
            _commands[command.Name] = command; // Register command by name
        }

        public ICommand? GetCommand(string name)
        {
            return _commands.TryGetValue(name, out var command) ? command : null; // Retrieve command by name
        }

        public IEnumerable<ICommand> Commands => _commands.Values; // Get all registered commands

    }
}
