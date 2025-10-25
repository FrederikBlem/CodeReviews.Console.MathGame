using MathGame.FrederikBlem.Models;
using System.Diagnostics;
namespace MathGame.FrederikBlem;
internal class GameEngine
{
    #region Fields
    // Fields to hold operator string and number ranges
    string operatorString = "";
    int easyMin = 0;
    int easyMax = 0;
    int mediumMin = 0;
    int mediumMax = 0;
    int hardMin = 0;
    int hardMax = 0;
    #endregion // Fields

    #region Main Game Loop
    internal void RunGame(string message, string name, GameType chosenGameType)
    {
        Console.WriteLine(message);

        Random random = new Random(); // For generating random numbers
        int score = 0;
        int firstNumber;
        int secondNumber;
        GameType currentGameType = chosenGameType; // To keep track of current game type in case of random

        if (chosenGameType != GameType.Random) // Only need to setup game type once if not random
        {
            SetupGameType(chosenGameType);
        }
        else
        {
            currentGameType = Helpers.GetRandomGameType();
            SetupGameType(currentGameType); // Setup for the first round of random game
        }


            GameDifficulty difficulty = GameDifficulty.Easy;
        bool hasChosenDifficulty = false;
        do
        {
            Console.WriteLine("---------------------------------------------");
            Console.WriteLine(@$"What difficulty would you like to play on? Choose from the options below:
1 - Easy   (Numbers between {easyMin}-{easyMax})
2 - Medium (Numbers between {mediumMin}-{mediumMax})
3 - Hard   (Numbers between {hardMin}-{hardMax})");
            Console.WriteLine("---------------------------------------------");

            var difficultySelected = Console.ReadLine();

            switch (difficultySelected.Trim().ToLower())
            {
                case "1":
                    difficulty = GameDifficulty.Easy;
                    hasChosenDifficulty = true;
                    break;
                case "2":
                    difficulty = GameDifficulty.Medium;
                    hasChosenDifficulty = true;
                    break;
                case "3":
                    difficulty = GameDifficulty.Hard;
                    hasChosenDifficulty = true;
                    break;
                default:
                    Console.WriteLine("Invalid Input. Please choose a valid option.");
                    break;
            }
        } while (!hasChosenDifficulty);

        var watch = Stopwatch.StartNew();
        for (int i = 0; i < 5; i++)
        {
            if (chosenGameType == GameType.Random && i > 0) // Need to setup game type each round after the first one if random
            {
                currentGameType = Helpers.GetRandomGameType();
                SetupGameType(currentGameType);
            }

            int[] randomNumbers = Helpers.GetRandomNumbers(difficulty, currentGameType);
            firstNumber = randomNumbers[0];
            secondNumber = randomNumbers[1];

            Console.Clear();
            Console.WriteLine($"{firstNumber} {operatorString} {secondNumber}");
            var resultGuess = Console.ReadLine();
            bool isValidNumberInput = false;

            while (!isValidNumberInput)
            {
                if (int.TryParse(resultGuess, out int result))
                {
                    isValidNumberInput = true;
                    switch (currentGameType)
                    {
                        case GameType.Addition:
                            if (result == firstNumber + secondNumber)
                            {
                                Console.WriteLine("Correct!");
                                score++;
                            }
                            else
                            {
                                Console.WriteLine($"Incorrect. The correct answer is {firstNumber + secondNumber}");
                            }
                            break;
                        case GameType.Subtraction:
                            if (result == firstNumber - secondNumber)
                            {
                                Console.WriteLine("Correct!");
                                score++;
                            }
                            else
                            {
                                Console.WriteLine($"Incorrect. The correct answer is {firstNumber - secondNumber}");
                            }
                            break;
                        case GameType.Multiplication:
                          if (result == firstNumber * secondNumber)
                            {
                                Console.WriteLine("Correct!");
                                score++;
                            }
                            else
                            {
                                Console.WriteLine($"Incorrect. The correct answer is {firstNumber * secondNumber}");
                            }
                            break;
                        case GameType.Division:
                            if (result == firstNumber / secondNumber)
                            {
                                Console.WriteLine("Correct!");
                                score++;
                            }
                            else
                            {
                                Console.WriteLine($"Incorrect. The correct answer is {firstNumber / secondNumber}");
                            }
                            break;
                    }
                }
                else
                {
                    Console.WriteLine("Invalid input. Please enter a whole number.");
                    resultGuess = Console.ReadLine();
                }
            }
        }
        watch.Stop();
        TimeSpan elapsedTime = watch.Elapsed;
        string timeTaken = String.Format("{0:00}:{1:00}:{2:00}", elapsedTime.Hours, elapsedTime.Minutes, elapsedTime.Seconds);
        Console.WriteLine($"{chosenGameType} game over! Your score is {score}.");
        Console.WriteLine($"Time taken: {timeTaken}");
        Helpers.AddGameToHistory(name, score, chosenGameType, difficulty, elapsedTime);
    }
    #endregion // Main Game Loop

    #region Helpers
    private void SetupGameType(GameType givenGameType) // Sets up the operator string and number ranges based on game type
    {
        switch (givenGameType)
        {
            case GameType.Addition:
                operatorString = "+";
                easyMin = 1;
                easyMax = 50;
                mediumMin = 2;
                mediumMax = 75;
                hardMin = 2;
                hardMax = 149;
                break;
            case GameType.Subtraction:
                operatorString = "-";
                easyMin = 1;
                easyMax = 50;
                mediumMin = 2;
                mediumMax = 75;
                hardMin = 2;
                hardMax = 149;
                break;
            case GameType.Multiplication:
                operatorString = "*";
                easyMin = 2;
                easyMax = 10;
                mediumMin = 2;
                mediumMax = 15;
                hardMin = 2;
                hardMax = 25;
                break;
            case GameType.Division:
                operatorString = "/";
                easyMin = 1;
                easyMax = 50;
                mediumMin = 2;
                mediumMax = 75;
                hardMin = 2;
                hardMax = 149;
                break;
            default:
                break;
        }
    }
    #endregion // Helpers
}
