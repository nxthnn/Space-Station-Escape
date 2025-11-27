using System;
using SpaceStationEscape.Core;
namespace SpaceStationEscape.Challenges

{
    public class EnemyChallenge : IChallenge //uses base of IChallenge
    {
        private static readonly Random _rng = new Random(); //random number is generated 
        public string Description { get; } //description of challenge
        public bool IsCompleted { get; private set; } //shows if challenge is completed

        private readonly Enemy _enemy; //enemy
        private readonly Player _player; //player

public EnemyChallenge(string description, Enemy enemy, Player player) 
{
    Description = description;
    _enemy = enemy;
    _player = player;
    IsCompleted = false;
} //constructor for enemy challenge



       public void Attempt() //method of enemy challenge
{
    if (IsCompleted)
    {
        Console.WriteLine("You have already defeated this enemy.");
        return;
    }

    if (!_player.IsAlive)
    {
        Console.WriteLine("You are too weak to continue fighting.");
        return;
    } //loop showing if player has won or died

    Console.WriteLine($"{Description}"); //shows description of enemy challenge
    Console.WriteLine($"{_enemy.Name} has {_enemy.Health} HP. You have {_player.Health} HP."); //shows health of enemy and player
    Console.WriteLine("Choose an action: light attack / attack / heavy attack / dodge / block"); //player options when attacking
    Console.Write("> ");
    var action = Console.ReadLine()?.Trim().ToLowerInvariant(); //reads player input

    if (string.IsNullOrWhiteSpace(action))
    {
        Console.WriteLine("You hesitate and do nothing...");
        action = "none";
    } //handles empty input

    // --- Player's turn ---
    const double playerHitChance = 0.75; // 75% chance to hit
    const int playerDamage = 10; // damage player does

    if (action == "attack")
    {
        if (_rng.NextDouble() < playerHitChance) //checks if player hits enemy
        {
            _enemy.TakeDamage(playerDamage);
            Console.WriteLine($"You strike {_enemy.Name} for {playerDamage} damage!"); //if player hits enemy this calculates damage
        }
        else
        {
            Console.WriteLine("You swing and miss!"); //if player misses
        }
    }
    else if (action == "light attack")
    {
        const double lightAttackHitChance = 1; // 100% chance to hit
        const int lightAttackDamage = 5; // light attack damage

        if (_rng.NextDouble() < lightAttackHitChance) //checks if player hits enemy
        {
            _enemy.TakeDamage(lightAttackDamage);
            Console.WriteLine($"You perform a light attack on {_enemy.Name} for {lightAttackDamage} damage!"); //if player hits enemy this calculates damage
        }
        else
        {
            Console.WriteLine("Your light attack misses!"); //if player misses
        }
    }
    else if (action == "heavy attack")
    {
        const double heavyAttackHitChance = 0.5; // 50% chance to hit
        const int heavyAttackDamage = 20; // heavy attack damage

        if (_rng.NextDouble() < heavyAttackHitChance) //checks if player hits enemy
        {
            _enemy.TakeDamage(heavyAttackDamage);
            Console.WriteLine($"You perform a heavy attack on {_enemy.Name} for {heavyAttackDamage} damage!"); //if player hits enemy this calculates damage
        }
        else
        {
            Console.WriteLine("Your heavy attack misses!"); //if player misses
        }
    }   
    else if (action == "dodge")
    {
        Console.WriteLine("You prepare to dodge the next attack..."); //dodging option
    }
    else if (action == "block")
    {
        Console.WriteLine("You raise your guard to block the next attack..."); //blocking option
    }
    else
    {
        Console.WriteLine("You do nothing..."); 
    }

    if (_enemy.Health <= 0)
    {
        Console.WriteLine($"You defeated {_enemy.Name}!");
        IsCompleted = true; //marks challenge as completed
        return;
    }

    // --- Enemy's turn ---
    const double enemyBaseHitChance = 0.7; // 70% base
    const int enemyDamage = 8; // enemy damage

    double enemyHitChance = enemyBaseHitChance; 
    int finalEnemyDamage = enemyDamage;

    if (action == "dodge") 
    {
        // Dodging: much lower chance to be hit
        enemyHitChance *= 0.3; // 70% * 0.3 ≈ 21%
    }
    else if (action == "block")
    {
        // Blocking: normal chance to be hit, but reduced damage
        finalEnemyDamage = enemyDamage / 2; // half damage
    }

    Console.WriteLine($"{_enemy.Name} prepares to strike..."); // enemy prepares to attack

    if (_rng.NextDouble() < enemyHitChance)
    {
        _player.TakeDamage(finalEnemyDamage);
        Console.WriteLine($"{_enemy.Name} hits you for {finalEnemyDamage} damage!"); // enemy hits player
        Console.WriteLine($"You now have {_player.Health} HP."); // shows player's remaining health
    }
    else
    {
        Console.WriteLine($"{_enemy.Name} misses!"); // enemy misses player
    }

    if (!_player.IsAlive)
    {
        Console.WriteLine("You have been defeated!"); // player defeated
    }
}


    }
}
