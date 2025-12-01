using System;
using SpaceStationEscape.Core;
using SpaceStationEscape.Rooms;
using SpaceStationEscape.Challenges;
using SpaceStationEscape.Commands;
using SpaceStationEscape.Game;

namespace SpaceStationEscape
{
    internal class Program // Main program class
    {
        static void Main(string[] args) // Main method - entry point of the program
        {
            var player = new Player("Astronaut"); // Create a player with the name "Astronaut"

            // A list of rooms, type of room, name and description
            var airlock = new SkillRoom(
                "Airlock",
                "You stand in the airlock of the ISS Perseus. The station is silent..."
            );

            var corridor = new PhysicalRoom(
                "Main Corridor",
                "A long corridor lit by flickering emergency lights."
            );

            var reactorCore = new UltimateRoom(
            "Reactor Core",
            "The core of the station hums with unstable energy. Both a corrupted AI terminal and a hostile creature await."
            );


            // Adds puzzle to skill room
            var airlockPuzzle = new PuzzleChallenge(
                "Airlock keypad",
                "A flickering keypad asks: 'Enter the emergency override code (hint: Modual Number)'",
                "2115"
            );
            airlock.AddChallenge(airlockPuzzle);

            // Adds enemy to physical room
            var alien = new Enemy("Mutated Astronaut", 20);
            var corridorEnemyChallenge = new EnemyChallenge(
                "A hostile figure blocks your path.",
                alien,
                player
            );

            // Adds puzzle to ultimate room
            var reactorPuzzle = new PuzzleChallenge(
                "Reactor Code Cipher",
                "A glowing panel asks: 'Decrypt the stabilisation code (8 ÷ 2(2+2))'",
                "16"
            );
            // Adds enemy to ultimate room
            var reactorBeast = new EnemyChallenge(
                "Mutated Reactor Beast",
                new Enemy("Reactor Beast", 100, attackPower: 10),
                player
            );

            reactorCore.AddChallenge(reactorPuzzle);
            reactorCore.AddChallenge(reactorBeast);

            corridor.AddChallenge(corridorEnemyChallenge);

            // Connect rooms
            airlock.AddExit("corridor", corridor);
            corridor.AddExit("airlock", airlock);
            corridor.AddExit("reactorCore", reactorCore);
            reactorCore.AddExit("corridor", corridor);

            // Start game in the airlock
            var context = new GameContext(player, airlock);

            // Set up commands
            var parser = new CommandParser();
            parser.Register(new MoveCommand());
            parser.Register(new SolveCommand());
            parser.Register(new AttackCommand());
            parser.Register(new QuitCommand());
            parser.Register(new HelpCommand(parser));

            Console.WriteLine("Welcome to Space Station Escape!"); // Welcome message
            Console.WriteLine($"Good luck, {player.Name}."); // Greet the player
            if (!player.IsAlive)
            {
                Console.WriteLine("You collapse... darkness takes you.");
                context.IsRunning = false; // End the game if the player is not alive
            }

            bool hasWon = false; // Flag to track if the player has won


            Console.WriteLine(); 

            while (context.IsRunning) // Main game loop
            {
                context.CurrentRoom.Show();
                Console.WriteLine("Commands: move <location>, solve, attack, help, quit"); // Display available commands
                Console.WriteLine();

                Console.Write("> ");
                var input = Console.ReadLine(); // Read player input
                if (string.IsNullOrWhiteSpace(input)) // Handle empty input
                {
                    Console.WriteLine("Please type a command (e.g. 'move corridor' or 'quit')."); // Prompt for command
                    continue;
                }

                var parts = input.Split(' ', StringSplitOptions.RemoveEmptyEntries); // Split input into command and arguments
                var commandName = parts[0].ToLowerInvariant(); // Extract command name
                var cmdArgs = parts.Length > 1 // Check if there are command arguments
                    ? parts[1..]   // C# range operator, from index 1 to end
                    : Array.Empty<string>(); // Empty array if no arguments

                var command = parser.GetCommand(commandName); // Retrieve the command from the parser
                if (command == null) // Handle unknown command
                {
                    Console.WriteLine("I don't understand that command."); // Prompt for valid command
                }
                else
                {
                    command.Execute(cmdArgs, context); // Execute the command
                }
                if (context.CurrentRoom is UltimateRoom ultimate && ultimate.IsCompleted && !hasWon) // Check for game completion
                {
                    Console.WriteLine("Congratulations! You have stabilized the reactor and escaped the space station!"); // Victory message
                    hasWon = true; // Set hasWon to true
                    context.IsRunning = false; // Stop the game loop
                }

                Console.WriteLine();
            }


                Console.WriteLine("Game over. Thanks for playing!"); // End of game message
        }
    }
}
