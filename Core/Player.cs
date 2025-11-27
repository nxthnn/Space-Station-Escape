namespace SpaceStationEscape.Core
{
    public class Player // Represents the player character
    {
        public string Name { get; } // Player name

        public int Health { get; private set; } = 100; // Player health
        public int AttackPower { get; } = 10; // Player attack power
        public int LightAttackPower { get; } = 5; // Player light attack power
        public int HeavyAttackPower { get; } = 20; // Player heavy attack power

        public Player(string name) // Constructor to initialize the player
        {
            Name = name;
        }

        public void TakeDamage(int amount) // Method to reduce player health
        {
            Health -= amount;
            if (Health < 0)
                Health = 0;
        }

        public bool IsAlive => Health > 0; // Property to check if the player is alive
    }
}
