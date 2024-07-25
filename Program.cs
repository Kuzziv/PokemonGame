using System;
using PokemonGameLib.Models;

// Create Pokémons
Pokemon pikachu = new Pokemon("Pikachu", PokemonType.Electric, 100, 55, 40, 35);
Pokemon charizard = new Pokemon("Charizard", PokemonType.Fire, 120, 70, 50, 45);

// Create Moves
Move thunderbolt = new Move("Thunderbolt", PokemonType.Electric, 90, 10);
Move flamethrower = new Move("Flamethrower", PokemonType.Fire, 90, 10);

// Add Moves to Pokémon
pikachu.AddMove(thunderbolt);
charizard.AddMove(flamethrower);

// Create Trainers
var ash = new Trainer("Ash");
var gary = new Trainer("Gary");

// Add Pokémons to Trainers
ash.AddPokemon(pikachu);
gary.AddPokemon(charizard);

// Initialize Battle
var battle = new Battle(ash, gary);

// Battle Simulation
while (!pikachu.IsFainted() && !charizard.IsFainted())
{
    Console.WriteLine($"{pikachu.Name} HP: {pikachu.HP}");
    Console.WriteLine($"{charizard.Name} HP: {charizard.HP}");

    // Ash's Pikachu attacks Gary's Charizard
    battle.PerformAttack(ash, thunderbolt);

    // Check if Charizard has fainted
    if (charizard.IsFainted())
    {
        Console.WriteLine($"{charizard.Name} has fainted!");
        break; // End battle if Charizard is fainted
    }

    // Gary's Charizard attacks Ash's Pikachu
    battle.PerformAttack(gary, flamethrower);

    // Check if Pikachu has fainted
    if (pikachu.IsFainted())
    {
        Console.WriteLine($"{pikachu.Name} has fainted!");
        break; // End battle if Pikachu is fainted
    }

    Console.WriteLine(); // New line for readability
}

// Display the result of the battle
Console.WriteLine(battle.DetermineBattleResult());