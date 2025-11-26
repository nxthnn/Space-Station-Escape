using System;
using System.Collections.Generic;
using System.Linq;
using SpaceStationEscape.Challenges;


namespace SpaceStationEscape.Rooms
{
    public class Room // Base class for all room types
    {
        public string Name { get; } // The name of the room
        public string Description { get; } // The description of the room


        private readonly Dictionary<string, Room> _exits =
            new Dictionary<string, Room>(StringComparer.OrdinalIgnoreCase); // Exits mapping directions to rooms

        public Room(string name, string description) // Constructor
        {
            Name = name;
            Description = description;
        }

        public void AddExit(string direction, Room targetRoom) // Adds an exit to another room in a given direction
        {
            _exits[direction] = targetRoom;
        }
        public virtual void AddChallenge(IChallenge challenge) // Adds a challenge to the room
        {
        _challenges.Add(challenge);
        }


        public IChallenge? GetFirstUnfinishedChallenge() // Gets the first unfinished challenge in the room
        {
            foreach (var c in _challenges)
            {
                if (!c.IsCompleted)
                {
                    return c;
                }
            }
            return null;
        }

        public int UnfinishedChallengeCount() // Gets the count of unfinished challenges in the room
        {
            return _challenges.Count(c => !c.IsCompleted); 
        }

        public Room? GetExit(string direction) // Gets the room in the given exit direction, if any
        {
            return _exits.TryGetValue(direction, out var room) ? room : null; // Return the room if found, otherwise null
        }

        public void Show() // Displays room information
        {
            Console.WriteLine($"== {Name} ==");
            Console.WriteLine(Description);
            Console.WriteLine();

            if (_exits.Count > 0)
            {
                Console.WriteLine("Exits:"); // List available exits
                foreach (var kvp in _exits)
                {
                    Console.WriteLine($" - {kvp.Key}");
                }
            }
            else
            {
                Console.WriteLine("There are no exits."); // Inform player that there are no exits
            }
            Console.WriteLine();
            Console.WriteLine("Challenges:"); // List challenges in the room
            if (_challenges.Count == 0)
            {
                Console.WriteLine(" - None"); // Inform player that there are no challenges
            }
            else
            {
                foreach (var c in _challenges) 
                {
                    var status = c.IsCompleted ? "✔ completed" : "✖ not completed"; // Determine challenge completion status
                    Console.WriteLine($" - {c.Description} ({status})"); 
                }
            }
            Console.WriteLine();
        }

        private readonly List<IChallenge> _challenges = new List<IChallenge>(); // List of challenges in the room

        public bool IsCompleted => _challenges.TrueForAll(c => c.IsCompleted); // Indicates if all challenges in the room are completed


    }
}
