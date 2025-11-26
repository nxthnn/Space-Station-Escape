namespace SpaceStationEscape.Commands
{
    public interface ICommand
    {
        string Name { get; }          // Command name, e.g. "move"
        string Description { get; }   // Command description, e.g. "Move to another room"

        void Execute(string[] args, Game.GameContext context); // Execute the command with arguments and game context
    }
}
