using System;

namespace SpaceStationEscape.Challenges
{
    public class PuzzleChallenge : IChallenge
    {
        public string Description { get; } // Description of the puzzle

        public bool IsCompleted { get; private set; } // Indicates if the puzzle is solved

        private readonly string _question; // The puzzle question
        private readonly string _answer; // The correct answer to the puzzle

        public PuzzleChallenge(string description, string question, string answer) // Constructor for puzzle challenge
        {
            Description = description;
            _question = question;
            _answer = answer;
            IsCompleted = false;
        }

        public bool CheckAnswer(string attempt) // Method to check the answer
        {
            return string.Equals(attempt?.Trim(), _answer, StringComparison.OrdinalIgnoreCase); // Compare attempt with the correct answer
        }

        public void Attempt() // Method to attempt the puzzle
        {
            if (IsCompleted)
            {
                Console.WriteLine("You have already solved this puzzle.");
                return;
            } // Check if puzzle is already solved

            Console.WriteLine(Description); // Display the puzzle description
            Console.WriteLine(_question); // Display the puzzle question
            Console.Write("> ");
            var input = Console.ReadLine(); // Read player input

            if (CheckAnswer(input)) // Check if the answer is correct
            {
                Console.WriteLine("Correct! Puzzle solved.");
                IsCompleted = true;
            } // Mark puzzle as solved
            else
            {
                Console.WriteLine("Incorrect. Try again later."); // Inform player of incorrect answer
            }
        }
    }
}
