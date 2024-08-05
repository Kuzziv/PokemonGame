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
ash.SwitchPokemon(squirtle); // Set the active Pokémon

Trainer misty = new Trainer("Misty");
misty.AddPokemon(bulbasaur);
misty.SwitchPokemon(bulbasaur); // Set the active Pokémon

// Set up a Battle
Battle battle = new Battle(ash, misty);

Console.WriteLine("Welcome to the Pokémon Battle!");
Console.WriteLine($"{ash.Name} VS {misty.Name}");
Console.WriteLine($"Battle begins between {squirtle.Name} and {bulbasaur.Name}!");
Console.WriteLine();

// Battle loop
while (!squirtle.IsFainted() && !bulbasaur.IsFainted())
{
    // Current Attacking and Defending Trainers
    Trainer attackingTrainer = battle.AttackingTrainer;
    Trainer defendingTrainer = battle.DefendingTrainer;

    // Current Attacking and Defending Pokémon
    Pokemon attacker = attackingTrainer.CurrentPokemon;
    Pokemon defender = defendingTrainer.CurrentPokemon;

    // Select the move based on the attacking Pokémon
    Move selectedMove = attacker == squirtle ? bubble : vineWhip;

    Console.WriteLine($"{attackingTrainer.Name}'s {attacker.Name} attacks with {selectedMove.Name}!");

    // Perform the attack
    battle.PerformAttack(selectedMove);

    Console.WriteLine($"{attacker.Name} HP: {attacker.CurrentHP} | {defender.Name} HP: {defender.CurrentHP}");
    Console.WriteLine();
}

// Determine and display the result of the battle
string result = battle.DetermineBattleResult();
Console.WriteLine(result);