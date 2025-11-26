namespace SpaceStationEscape.Core
{
    public class Enemy // Represents an enemy in the game
    {
        public string Name { get; } // Enemy name
        public int Health { get; private set; } // Enemy health
        public int AttackPower { get; } // Enemy attack power

        public Enemy(string name, int health, int attackPower = 5) // Constructor to initialize an enemy
        {
            Name = name;
            Health = health;
            AttackPower = attackPower;
        }

        public void TakeDamage(int amount) // Method to reduce enemy health
        {
            Health -= amount;
            if (Health < 0)
                Health = 0;
        }

        public void Attack(Player player) // Method for enemy to attack the player
        {
            player.TakeDamage(AttackPower);
        }
    }
}
