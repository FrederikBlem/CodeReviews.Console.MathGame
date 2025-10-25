namespace MathGame.FrederikBlem;
using MathGame.FrederikBlem.Models;
using System.Globalization;

internal class Menu
{
    GameEngine engine = new GameEngine();
    private bool keepGoing = true;

    public void ShowMenu(string? name, DateTime now)
    {
        Console.Clear();
        DisplayMessage(name, now); // Show seasonal message based on current date

        do
        {
            Console.WriteLine("---------------------------------------------");
            Console.WriteLine(@$"What game would you like to play? Choose from the options below:
A - Addition
S - Subtraction
M - Multiplication
D - Division
R - Random Game
G - View (G)ame History
H - View (H)igh Scores
Q - Quit the program");
            Console.WriteLine("---------------------------------------------");

            var gameSelected = Console.ReadLine();

            switch (gameSelected.Trim().ToLower())
            {
                case "a":
                    engine.RunGame("Addition selected", name, GameType.Addition);
                    break;
                case "s":
                    engine.RunGame("Subtraction selected", name, GameType.Subtraction);
                    break;
                case "m":
                    engine.RunGame("Multiplication selected", name, GameType.Multiplication);
                    break;
                case "d":
                    engine.RunGame("Division selected", name, GameType.Division);
                    break;
                case "r":
                    engine.RunGame("Random Game selected", name, GameType.Random);
                    break;
                case "q":
                    Console.WriteLine("Goodbye. Press enter to exit.");
                    Console.ReadLine();
                    keepGoing = false;
                    break;
                case "g":
                    Helpers.ViewGameHistory();
                    break;
                case "h":
                    Helpers.ViewHighScores();
                    break;
                default:
                    Console.WriteLine("Invalid Input. Please choose a valid option.");
                    break;
            }

            if (keepGoing)
            {
                ReturnToMenuPrompt();
            }

        } while (keepGoing);

    }

    internal void ReturnToMenuPrompt()
    {
        string playAgain = "";
        while (playAgain != "y" && playAgain != "n")
        {
            Console.WriteLine("Return to menu? Y/N:");
            playAgain = Console.ReadLine();
            playAgain = playAgain.Trim().ToLower();
            switch (playAgain)
            {
                case "y":
                    keepGoing = true;
                    Console.Clear();
                    break;
                case "n":
                    keepGoing = false;
                    Console.Clear();
                    Console.WriteLine("Goodbye. Press enter to exit.");
                    Console.ReadLine();
                    break;
                default:
                    Console.WriteLine("Invalid input. Please enter Y or N.");
                    break;
            }
        }
    }

    internal void DisplayMessage(string name, DateTime now) // Display seasonal message based on current date
    {
        var currentTime = now.ToString("F", CultureInfo.CurrentCulture); // Full date/time pattern using user's culture info
        
        if (now.Month == 2 && 7 < now.Day && now.Day <= 14) // Valentine's message between Feb 8 and Feb 14
        {
            Helpers.DisplayValentinesMessage(name, currentTime);
        }        
        else if(now.Month == 10 && 16 < now.Day && now.Day <= 31) // Halloween message between Oct 17 and Oct 31
        {
            Helpers.DisplayHalloweenMessage(name, currentTime);
        }
        else if (now.Month == 12 && now.Day < 26) // Christmas message between Dec 1 and Dec 25
        {
            Helpers.DisplayChristmasMessage(name, currentTime);
        }
        else if ((now.Month == 12 && 25 < now.Day) || (now.Month == 1 && now.Day == 1)) // New Year message between Dec 26 and Jan 1
                {
            Helpers.DisplayNewYearMessage(name, currentTime);
        }
        else // Default message
        {
            Console.WriteLine($"Hello {name}. It's {currentTime}. This is your math game. \nIt's great that you're working on improving yourself!\n");
        }
        Console.WriteLine("Press enter to continue to the menu.");
        Console.ReadLine();
    }
}
