namespace SpaceStationEscape.Challenges
{
    public interface IChallenge // Interface for challenges
    {
        string Description { get; } // Description of the challenge

        bool IsCompleted { get; } // Indicates if the challenge is completed

        void Attempt(); // Method to attempt the challenge
    }
}
