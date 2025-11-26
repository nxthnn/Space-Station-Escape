using System;
using SpaceStationEscape.Game;
using SpaceStationEscape.Challenges;

namespace SpaceStationEscape.Commands
{
    public class SolveCommand : ICommand // Command to attempt solving a puzzle
    {
        public string Name => "solve"; // Command name
        public string Description => "Attempt to solve a puzzle in the current room."; // Command description

        public void Execute(string[] args, GameContext context) // Execute method
        {
            var room = context.CurrentRoom;
            var challenge = room.GetFirstUnfinishedChallenge(); // Get the first unfinished challenge in the current room

            if (challenge == null)
            {
                Console.WriteLine("There are no unfinished challenges here."); // Inform player that there are no unfinished challenges
                return;
            }

            if (challenge is PuzzleChallenge)
            {
                challenge.Attempt(); // Attempt to solve the puzzle challenge
            }
            else
            {
                Console.WriteLine("There is no puzzle to solve here."); // Inform player that there is no puzzle challenge
            }
        }
    }
}
