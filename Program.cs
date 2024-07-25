// Create Pokémon
var pikachu = new Pokemon("Pikachu", PokemonType.Electric, 100, 55, 40, 35);
var charizard = new Pokemon("Charizard", PokemonType.Fire, 120, 70, 50, 45);

// Create Moves
var thunderbolt = new Move("Thunderbolt", PokemonType.Electric, 90, 10);
var flamethrower = new Move("Flamethrower", PokemonType.Fire, 90, 10);

// Add Moves to Pokémon
pikachu.AddMove(thunderbolt);
charizard.AddMove(flamethrower);

// Initialize Battle
var battle = new Battle(pikachu, pikachu);

// Battle Simulation
while (!pikachu.IsFainted() && !charizard.IsFainted())
{
    Console.WriteLine($"{pikachu.Name} HP: {pikachu.HP}");
    Console.WriteLine($"{charizard.Name} HP: {charizard.HP}");

    // Pikachu attacks
    battle.PerformAttack(thunderbolt);

    if (charizard.IsFainted()) break; // Break if charizard is fainted

    Console.WriteLine();
}

// Display the result
Console.WriteLine(battle.DetermineBattleResult());
