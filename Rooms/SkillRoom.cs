using SpaceStationEscape.Challenges;

namespace SpaceStationEscape.Rooms
{
    public class SkillRoom : Room // Represents a room that only accepts puzzle challenges
    {
        public SkillRoom(string name, string description) // Constructor
            : base(name, description) { }

        public override void AddChallenge(IChallenge challenge) // Adds a challenge to the skill room
        {
            if (challenge is PuzzleChallenge) // Only allow puzzle challenges
            {
                base.AddChallenge(challenge); // Call base method to add the challenge
            }
            else
            {
                throw new InvalidOperationException("Skill rooms may only contain puzzle challenges."); // Error if challenge type is invalid
            }
        }
    }
}
