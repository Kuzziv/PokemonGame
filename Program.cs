using System;
using System.IO;
using PokemonGameLib.Utilities;
using PokemonGameLib.Interfaces;
using PokemonGameLib.Models.Battles;
using PokemonGameLib.Models.Pokemons;
using PokemonGameLib.Models.Pokemons.Evolutions;
using PokemonGameLib.Models.Pokemons.Moves;
using PokemonGameLib.Models.Trainers;
using PokemonGameLib.Models.Items;

namespace PokemonGame
{
    class Program
    {
        static void Main(string[] args)
        {
            string logDirectory = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.Desktop), "tmp_logs");
            string logFilePath = Path.Combine(logDirectory, "Logs.yml");

            if (!Directory.Exists(logDirectory))
            {
                Directory.CreateDirectory(logDirectory);
            }

            LoggingService.ResetConfiguration();
            LoggingService.Configure(logFilePath);

            Console.WriteLine($"Log file path: {logFilePath}");

            StartGame();
        }

        static void StartGame()
        {
            Console.WriteLine("Welcome to the Pokémon Battle Game!");

            try 
            {
                ITrainer playerTrainer = InitializePlayerTrainer();
                ITrainer aiTrainer = InitializeAITrainer();

                Console.WriteLine($"{playerTrainer.Name} has {playerTrainer.CurrentPokemon.Name} as their current Pokémon.");
                Console.WriteLine($"{aiTrainer.Name} has {aiTrainer.CurrentPokemon.Name} as their current Pokémon.");

                var battle = new Battle(playerTrainer, aiTrainer);

                Console.WriteLine($"The trainer {aiTrainer.Name} appeared, and started a fight with {playerTrainer.Name}!");
                Console.WriteLine($"{aiTrainer.Name} sent out {aiTrainer.CurrentPokemon.Name}!");

                battle.StartBattle();

                Console.WriteLine("The battle has ended!");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"An error occurred: {ex.Message}");
                Console.WriteLine(ex.StackTrace);
            }
        }

        static ITrainer InitializePlayerTrainer()
        {
            var charmander = new Pokemon(
                name: "Charmander",
                type: PokemonType.Fire,
                level: 10,
                maxHp: 50,
                attack: 15,
                defense: 10,
                evolutions: new List<IEvolution> { new Evolution("Charmeleon", 16) }
            );

            charmander.AddMove(new Move("Scratch", PokemonType.Normal, 40, 1));
            charmander.AddMove(new Move("Ember", PokemonType.Fire, 40, 7));

            var bulbasaur = new Pokemon(
                name: "Bulbasaur",
                type: PokemonType.Grass,
                level: 10,
                maxHp: 45,
                attack: 12,
                defense: 14,
                evolutions: new List<IEvolution> { new Evolution("Ivysaur", 16) }
            );

            bulbasaur.AddMove(new Move("Tackle", PokemonType.Normal, 40, 1));
            bulbasaur.AddMove(new Move("Vine Whip", PokemonType.Grass, 40, 7));

            var rattata = new Pokemon(
                name: "Rattata",
                type: PokemonType.Normal,
                level: 3,
                maxHp: 14,
                attack: 7,
                defense: 3,
                evolutions: new List<IEvolution> { new Evolution("Raticate", 16) }
            );

            rattata.AddMove(new Move("Tackle", PokemonType.Normal, 40, 1));

            var potion = new Potion("Potion", "Restores 20 HP", 20);
            var revive = new Revive("Revive", "Revives a fainted Pokémon with 50% of its maximum HP.", 50);

            var logger = LoggingService.GetLogger();
            var playerTrainer = new PlayerTrainer("Ash");
            playerTrainer.AddPokemon(charmander);
            playerTrainer.AddPokemon(bulbasaur);
            playerTrainer.AddPokemon(rattata);
            playerTrainer.CurrentPokemon = bulbasaur;
            playerTrainer.AddItem(potion);
            playerTrainer.AddItem(revive);

            logger.LogInfo($"{playerTrainer.Name} initialized with Pokémon: {charmander.Name}.");

            return playerTrainer;
        }

        static ITrainer InitializeAITrainer()
        {
            var squirtle = new Pokemon(
                name: "Squirtle",
                type: PokemonType.Water,
                level: 10,
                maxHp: 55,
                attack: 14,
                defense: 12,
                evolutions: new List<IEvolution> { new Evolution("Wartortle", 16) }
            );

            squirtle.AddMove(new Move("Tackle", PokemonType.Normal, 40, 1));
            squirtle.AddMove(new Move("Water Gun", PokemonType.Water, 40, 7));

            var rattata = new Pokemon(
                name: "Rattata",
                type: PokemonType.Normal,
                level: 10,
                maxHp: 30,
                attack: 20,
                defense: 10,
                evolutions: new List<IEvolution> { new Evolution("Raticate", 16) }
            );

            rattata.AddMove(new Move("Tackle", PokemonType.Normal, 40, 1));
            rattata.AddMove(new Move("Quick Attack", PokemonType.Normal, 40, 7));

            var logger = LoggingService.GetLogger();
            var aiTrainer = new AITrainer("Gary");
            aiTrainer.AddPokemon(squirtle);
            aiTrainer.AddPokemon(rattata);
            aiTrainer.CurrentPokemon = squirtle;

            logger.LogInfo($"{aiTrainer.Name} initialized with Pokémon: {squirtle.Name}.");

            return aiTrainer;
        }
    }
}
