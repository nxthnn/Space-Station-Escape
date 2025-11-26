using System;
using SpaceStationEscape.Challenges;

namespace SpaceStationEscape.Rooms 
{
    public class UltimateRoom : Room // A room that accepts all challenge types
    {
        public UltimateRoom(string name, string description) // Constructor
            : base(name, description)
        {
        }

        public override void AddChallenge(IChallenge challenge) // Adds a challenge to the ultimate room
        {
            base.AddChallenge(challenge); // Call base method to add the challenge
        }

        internal bool AllChallengesCompleted() // Checks if all challenges in the room are completed
        {
            throw new NotImplementedException(); // Implementation pending
        }
    }
}
