using SpaceStationEscape.Challenges;

namespace SpaceStationEscape.Rooms
{
    public class PhysicalRoom : Room // A room that contains physical challenges (enemy encounters)
    {
        public PhysicalRoom(string name, string description) // Constructor
            : base(name, description) { }

        public override void AddChallenge(IChallenge challenge) // Override to add challenges
        {
            if (challenge is EnemyChallenge) // Only allow enemy challenges
            {
                base.AddChallenge(challenge); // Call base method to add the challenge
            }
            else
            {
                throw new InvalidOperationException("Physical rooms may only contain enemy challenges."); // Error if challenge type is invalid
            }
        }
    }
}
