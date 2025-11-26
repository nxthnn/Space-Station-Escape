using SpaceStationEscape.Challenges;
using Xunit;

namespace SpaceStationEscape.Tests
{
    public class PuzzleTests
    {
        [Fact]
        public void CheckAnswer_ReturnsTrue_WhenAnswerIsCorrect()
        {
            // Arrange
            var puzzle = new PuzzleChallenge(
                "Test Puzzle",
                "What is 2+2?",
                "4"
            );

            // Act
            var result = puzzle.CheckAnswer("4");

            // Assert
            Assert.True(result);
        }

        [Fact]
        public void CheckAnswer_ReturnsFalse_WhenAnswerIsIncorrect()
        {
            // Arrange
            var puzzle = new PuzzleChallenge(
                "Test Puzzle",
                "What is 2+2?",
                "4"
            );

            // Act
            var result = puzzle.CheckAnswer("5");

            // Assert
            Assert.False(result);
        }
    }
}
