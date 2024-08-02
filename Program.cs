using System;
using PokemonGameLib.Models;

// Create Pokémon
Pokemon squirtle = new Pokemon("Squirtle", PokemonType.Water, 15, 43, 24, 25);
Pokemon bulbasaur = new Pokemon("Bulbasaur", PokemonType.Grass, 15, 41, 24, 24);

// Create Moves
Move bubble = new Move("Bubble", PokemonType.Water, 20, 7);
Move vineWhip = new Move("Vine Whip", PokemonType.Grass, 45, 7);

// Add Moves to Pokémon
squirtle.AddMove(bubble);
bulbasaur.AddMove(vineWhip);

// Create Trainers
Trainer ash = new Trainer("Ash");
ash.AddPokemon(squirtle);

Trainer misty = new Trainer("Misty");
misty.AddPokemon(bulbasaur);

// Set up a Battle
Battle battle = new Battle(ash, misty);

Console.WriteLine("Battle begins!");
Console.WriteLine();

// Battle loop
while (squirtle.HP > 0 && bulbasaur.HP > 0)
{
    // Ash's Squirtle attacks Misty's Bulbasaur
    Console.WriteLine($"{ash.Name}'s {squirtle.Name} attacks!");
    battle.PerformAttack(ash, bubble);
    Console.WriteLine($"{squirtle.Name} HP: {squirtle.HP}, {bulbasaur.Name} HP: {bulbasaur.HP}");
    Console.WriteLine();

    if (bulbasaur.HP <= 0)
    {
        Console.WriteLine($"{bulbasaur.Name} has fainted!");
        break;
    }

    // Misty's Bulbasaur attacks Ash's Squirtle
    Console.WriteLine($"{misty.Name}'s {bulbasaur.Name} attacks!");
    battle.PerformAttack(misty, vineWhip);
    Console.WriteLine($"{squirtle.Name} HP: {squirtle.HP}, {bulbasaur.Name} HP: {bulbasaur.HP}");
    Console.WriteLine();

    if (squirtle.HP <= 0)
    {
        Console.WriteLine($"{squirtle.Name} has fainted!");
        break;
    }
}

// Determine the result of the battle
string result = battle.DetermineBattleResult();
Console.WriteLine(result);