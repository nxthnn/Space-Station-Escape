using System;
using SpaceStationEscape.Game;
using SpaceStationEscape.Challenges;

namespace SpaceStationEscape.Commands
{
    public class AttackCommand : ICommand
    {
        public string Name => "attack"; // Command name
        public string Description => "Attack an enemy in the current room."; // Command description

        public void Execute(string[] args, GameContext context) // Execute method
        {
            var room = context.CurrentRoom; // Get the current room
            var challenge = room.GetFirstUnfinishedChallenge(); // Get the first unfinished challenge in the room

            if (challenge == null) // Check if there is no challenge to attack
            {
                Console.WriteLine("There is nothing to attack here.");
                return;
            }

            if (challenge is EnemyChallenge)
            {
                challenge.Attempt();
            }
            else
            {
                Console.WriteLine("This challenge cannot be attacked."); // Inform player that the challenge is not an enemy
            }
        }
    }
}
