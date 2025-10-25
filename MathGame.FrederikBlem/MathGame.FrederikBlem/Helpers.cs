using MathGame.FrederikBlem.Models;
namespace MathGame.FrederikBlem;

internal class Helpers
{
    #region Mock Game Records
    static List<GameRecord> gameRecords = new List<GameRecord>
{
    new GameRecord { NamePlayer = "DENDE", Date = DateTime.Now.AddDays(-4), Score = 5, Type = GameType.Addition, Difficulty = GameDifficulty.Easy, TimeTaken = new TimeSpan(0, 0, 14) },
    new GameRecord { NamePlayer = "WOK", Date = DateTime.Now.AddDays(-6), Score = 3, Type = GameType.Addition, Difficulty = GameDifficulty.Medium, TimeTaken = new TimeSpan(0, 0, 17) },
    new GameRecord { NamePlayer = "DENDE", Date = DateTime.Now.AddHours(-3), Score = 0, Type = GameType.Addition, Difficulty = GameDifficulty.Hard, TimeTaken = new TimeSpan(0, 1, 3) },
    new GameRecord { NamePlayer = "DENDE", Date = DateTime.Now.AddHours(-3).AddMinutes(2), Score = 0, Type = GameType.Addition, Difficulty = GameDifficulty.Hard, TimeTaken = new TimeSpan(0, 1, 3) }, // Duplicate entry for testing sorting by date

    new GameRecord { NamePlayer = "DENDE", Date = DateTime.Now.AddMinutes(-23), Score = 1, Type = GameType.Subtraction, Difficulty = GameDifficulty.Easy, TimeTaken = new TimeSpan(0, 0, 12) },
    new GameRecord { NamePlayer = "WOK", Date = DateTime.Now.AddDays(-3), Score = 5, Type = GameType.Subtraction, Difficulty = GameDifficulty.Medium, TimeTaken = new TimeSpan(0, 0, 20) },
    new GameRecord { NamePlayer = "DENDE", Date = DateTime.Now.AddDays(-20), Score = 3, Type = GameType.Subtraction, Difficulty = GameDifficulty.Hard, TimeTaken = new TimeSpan(0, 1, 14) },
    new GameRecord { NamePlayer = "DENDE", Date = DateTime.Now.AddDays(-20).AddMinutes(2), Score = 3, Type = GameType.Subtraction, Difficulty = GameDifficulty.Hard, TimeTaken = new TimeSpan(0, 1, 12) }, // Duplicate entry for testing sorting by time taken

    new GameRecord { NamePlayer = "WOK", Date = DateTime.Now.AddDays(-1), Score = 1, Type = GameType.Multiplication, Difficulty = GameDifficulty.Easy, TimeTaken = new TimeSpan(0, 0, 11) },
    new GameRecord { NamePlayer = "DENDE", Date = DateTime.Now.AddDays(-2), Score = 4, Type = GameType.Multiplication, Difficulty = GameDifficulty.Hard, TimeTaken = new TimeSpan(0, 1, 1) },
    new GameRecord { NamePlayer = "WOK", Date = DateTime.Now.AddMinutes(-15), Score = 2, Type = GameType.Multiplication, Difficulty = GameDifficulty.Medium, TimeTaken = new TimeSpan(0, 0, 29) },
    new GameRecord { NamePlayer = "WOK", Date = DateTime.Now.AddMinutes(-15).AddMinutes(2), Score = 3, Type = GameType.Multiplication, Difficulty = GameDifficulty.Medium, TimeTaken = new TimeSpan(0, 0, 29) }, // Duplicate entry for testing sorting by score

    new GameRecord { NamePlayer = "WOK", Date = DateTime.Now.AddDays(-5), Score = 4, Type = GameType.Division, Difficulty = GameDifficulty.Easy, TimeTaken = new TimeSpan(0, 0, 12) }, 
    new GameRecord { NamePlayer = "DENDE", Date = DateTime.Now.AddDays(-3), Score = 2, Type = GameType.Division, Difficulty = GameDifficulty.Medium, TimeTaken = new TimeSpan(0, 0, 24) },
    new GameRecord { NamePlayer = "WOK", Date = DateTime.Now.AddMinutes(-2), Score = 3, Type = GameType.Division, Difficulty = GameDifficulty.Hard, TimeTaken = new TimeSpan(0, 1, 7) },
    new GameRecord { NamePlayer = "WOK", Date = DateTime.Now.AddMinutes(-2).AddMinutes(2), Score = 3, Type = GameType.Division, Difficulty = GameDifficulty.Easy, TimeTaken = new TimeSpan(0, 1, 7) }, // Duplicate entry for testing sorting by difficulty

    // Duplicate entries for testing sorting by type
    new GameRecord { NamePlayer = "WOK", Date = DateTime.Now.AddMinutes(-2), Score = 3, Type = GameType.Subtraction, Difficulty = GameDifficulty.Hard, TimeTaken = new TimeSpan(0, 2, 7) },
    new GameRecord { NamePlayer = "WOK", Date = DateTime.Now.AddMinutes(-2), Score = 3, Type = GameType.Addition, Difficulty = GameDifficulty.Hard, TimeTaken = new TimeSpan(0, 2, 7) },    
    new GameRecord { NamePlayer = "WOK", Date = DateTime.Now.AddMinutes(-2), Score = 3, Type = GameType.Multiplication, Difficulty = GameDifficulty.Hard, TimeTaken = new TimeSpan(0, 2, 7) },
    new GameRecord { NamePlayer = "WOK", Date = DateTime.Now.AddMinutes(-2), Score = 3, Type = GameType.Division, Difficulty = GameDifficulty.Hard, TimeTaken = new TimeSpan(0, 2, 7) },
    new GameRecord { NamePlayer = "WOK", Date = DateTime.Now.AddMinutes(-2), Score = 3, Type = GameType.Random, Difficulty = GameDifficulty.Hard, TimeTaken = new TimeSpan(0, 2, 7) },
};
    #endregion Mock Game Records

    #region Main Game Helper Methods
    internal static int[] GetRandomNumbers(GameDifficulty gameDifficulty, GameType gameType)
    {
        int minimum = 1;
        int maximum = 99;

        switch (gameType)
        {
            case GameType.Addition:
                switch (gameDifficulty)
                {
                    case GameDifficulty.Easy:
                        minimum = 1;
                        maximum = 50;
                        break;
                    case GameDifficulty.Medium:
                        minimum = 2;
                        maximum = 75;
                        break;
                    case GameDifficulty.Hard:
                        minimum = 2;
                        maximum = 149;
                        break;
                }
                break;
            case GameType.Subtraction:
                switch (gameDifficulty)
                {
                    case GameDifficulty.Easy:
                        minimum = 1;
                        maximum = 50;
                        break;
                    case GameDifficulty.Medium:
                        minimum = 2;
                        maximum = 75;
                        break;
                    case GameDifficulty.Hard:
                        minimum = 2;
                        maximum = 149;
                        break;
                }
                break;
            case GameType.Multiplication:
                switch (gameDifficulty)
                {
                    case GameDifficulty.Easy:
                        minimum = 2;
                        maximum = 10;
                        break;
                    case GameDifficulty.Medium:
                        minimum = 2;
                        maximum = 15;
                        break;
                    case GameDifficulty.Hard:
                        minimum = 2;
                        maximum = 25;
                        break;
                }
                break;
            case GameType.Division:
                switch (gameDifficulty)
                {
                    case GameDifficulty.Easy:
                        minimum = 1;
                        maximum = 50;
                        break;
                    case GameDifficulty.Medium:
                        minimum = 2;
                        maximum = 75;
                        break;
                    case GameDifficulty.Hard:
                        minimum = 2;
                        maximum = 149;
                        break;
                }
                break;
        }

        Random random = new Random();
        int firstNumber = random.Next(minimum, maximum);
        int secondNumber = random.Next(minimum, maximum);
        if (gameType == GameType.Division)
        {
            while (firstNumber % secondNumber != 0)
            {
                firstNumber = random.Next(2, 99);
                secondNumber = random.Next(2, 99);
            }
        }
        if (gameType == GameType.Subtraction && gameDifficulty == GameDifficulty.Easy)
        {
            while (firstNumber < secondNumber) // Ensure no negative results on easy subtraction
            {
                firstNumber = random.Next(minimum, maximum);
                secondNumber = random.Next(minimum, maximum);
            }
        }
        return new int[] { firstNumber, secondNumber };
    }

    internal static string GetName()
    {
        Console.WriteLine("Please type your name");
        var name = Console.ReadLine();

        while (string.IsNullOrWhiteSpace(name) || name.Length > 15) // Validate name input. Max 15 characters for formatting purposes
        {
            Console.WriteLine("Name cannot be empty or longer than 15 characters. Please type your name.");
            name = Console.ReadLine();
        }
        return name.Trim().ToUpper();
    }

    internal static GameType GetRandomGameType()
    {
        Random random = new Random();
        Array gameTypes = Enum.GetValues(typeof(GameType));
        return (GameType)gameTypes.GetValue(random.Next(gameTypes.Length - 1))!; // Exclude Random type
    }
    #endregion // Main Game Helper Methods

    #region History and High Score Methods
    internal static void AddGameToHistory(string name, int gameScore, GameType gameType, GameDifficulty gameDifficulty, TimeSpan timeTaken)
    {
        gameRecords.Add(new GameRecord
        {
            NamePlayer = name,
            Date = DateTime.Now,
            Score = gameScore,
            Type = gameType,
            Difficulty = gameDifficulty,
            TimeTaken = timeTaken
        });
    }
    internal static void ViewGameHistory()
    {
        // TODO: Format the output nicely in a table
        Console.Clear();
        Console.WriteLine("Game History:");
        var gameRecordsByDate = gameRecords.OrderBy(x => x.Date); // Sort by date ascending in case of duplicates or unsorted entries to display oldest first
        PrintGameRecords(gameRecordsByDate.ToList<GameRecord>());
    }

    internal static void ViewHighScores()
    {
        Console.Clear();
        bool keepGoing = true;
        do
        {
            DisplayHighScoreOptions();

            var gameSelected = Console.ReadLine();
            List<GameRecord> gamesToPrint = new List<GameRecord>();
            GameType gameType = GameType.Addition;
            bool viewAll = false;
            bool isValidInput = false;

            while (!isValidInput)
            {
                switch (gameSelected.Trim().ToLower())
                {
                    case "a":
                        Console.Clear();
                        Console.WriteLine("All Addition Game High Scores:");
                        gameType = GameType.Addition;
                        isValidInput = true;
                        break;
                    case "s":
                        Console.Clear();
                        Console.WriteLine("All Subtraction Game High Scores:");
                        gameType = GameType.Subtraction;
                        isValidInput = true;
                        break;
                    case "m":
                        Console.Clear();
                        Console.WriteLine("All Multiplication Game High Scores:");
                        gameType = GameType.Multiplication;
                        isValidInput = true;
                        break;
                    case "d":
                        Console.Clear();
                        Console.WriteLine("All Division Game High Scores:");
                        gameType = GameType.Division;
                        isValidInput = true;
                        break;
                    case "q":
                        Console.Clear();
                        Console.WriteLine("Exiting High Scores View.");
                        keepGoing = false;
                        isValidInput = true;
                        break;
                    case "v":
                        Console.Clear();
                        Console.WriteLine("All Game High Scores:");
                        viewAll = true;
                        isValidInput = true;
                        break;
                    default:
                        Console.Clear();
                        Console.WriteLine("Invalid Input. Please choose a valid option.");
                        DisplayHighScoreOptions();
                        isValidInput = false;
                        gameSelected = Console.ReadLine();                        
                        continue;
                }

                if (!keepGoing) // User chose to quit
                {
                    break;
                }

                if (viewAll && isValidInput) // View all high scores
                {

                    var gamesToViewAll = gameRecords.OrderByDescending(x => x.Difficulty).ThenByDescending(x => x.Score).ThenBy(x => x.TimeTaken).ThenBy(x => x.Date).ThenByDescending(x => x.Type).ToList();
                    //var gamesToViewAll = gameRecords.OrderByDescending(x => x.Type).ToList(); // For testing sorting by type since the above doesn't show type sorting well. Maybe too many other factors in the sort?
                    PrintGameRecords(gamesToViewAll);
                }
                else if (isValidInput) // View specific game type high scores
                {
                    var gamesToViewSpecific = gameRecords.Where(x => x.Type == gameType).OrderByDescending(x => x.Difficulty).ThenByDescending(x => x.Score).ThenBy(x => x.TimeTaken).ThenBy(x => x.Date);
                    foreach (var game in gamesToViewSpecific)
                    {
                        gamesToPrint.Add(game);
                    }
                    PrintGameRecords(gamesToPrint);
                }
            }

        } while (keepGoing);
    }

    internal static void DisplayHighScoreOptions()
    {
        Console.WriteLine("---------------------------------------------");
        Console.WriteLine(@$"What game would you like to view highscores for? Choose from the options below:
A - Addition
S - Subtraction
M - Multiplication
D - Division
V - View All High Scores
Q - Quit Viewing High Scores");
        Console.WriteLine("---------------------------------------------");
    }

    internal static void PrintGameRecords(List<GameRecord> givenRecords)
    {
        Console.WriteLine("---------------------------------------------");
        foreach (var gameRecord in givenRecords)
        {
            string paddedName = gameRecord.NamePlayer.PadRight(15);
            string paddedType = gameRecord.Type.ToString().PadRight(14);
            string paddedScore = gameRecord.Score.ToString().PadLeft(2);
            string paddedDifficulty = gameRecord.Difficulty.ToString().PadRight(6);
            string timeTaken = String.Format("{0:00}:{1:00}:{2:00}", gameRecord.TimeTaken.Hours, gameRecord.TimeTaken.Minutes, gameRecord.TimeTaken.Seconds);
            Console.WriteLine($"{paddedName} | {gameRecord.Date} - {paddedType}: {gameRecord.Score} points on {paddedDifficulty} | {timeTaken}");
        }
        Console.WriteLine("---------------------------------------------");
        Console.WriteLine("Press enter to continue.");
        Console.ReadLine();
    }
    #endregion // History and High Score Methods

    #region Ascii art for Special Occasions
    internal static void DisplayValentinesMessage(string name, string currentTime)
    {
        Console.WriteLine(@$"Art from https://www.asciiart.eu/
   _______________                        |*\_/*|________
  |  ___________  |     .-.     .-.      ||_/-\_|______  |
  | |           | |    .****. .****.     | |           | |
  | |   0   0   | |    .*****.*****.     | |   0   0   | |
  | |     -     | |     .*********.      | |     -     | |
  | |   \___/   | |      .*******.       | |   \___/   | |
  | |___     ___| |       .*****.        | |___________| |
  |_____|\_/|_____|        .***.         |_______________|
    _|__|/ \|_|_.............*.............._|________|_
   / ********** \                          / ********** \
 /  ************  \                      /  ************  \
--------------------                    --------------------");
        Console.WriteLine($"Happy Valentines Day, {name} and welcome to the math game. \nIt's {currentTime}. It's great that you're working on yourself.");
    }

    internal static void DisplayHalloweenMessage(string name, string currentTime)
    {
        Console.WriteLine(@$"Art from https://www.asciiart.eu/
                           Jgy__
                         jWW  `""""9Wf
                       _#WWW     IW
                      jWWWWW     IW
              __,yyyyyWWWWW     IWyyyy___
         _jyWWP""^``""`.C""9*,J _.mqD:^^""WWWWWWQg__
       jgW""^.C/""    .C'     I    `D.     'D._""WQg_
     jWP` .C""       C'      I     `D._     `D._ ""Qg_
   jQP`  .C    ,d^^b._      I      _.d^^b.   `D._ ""Qg
  jQ^  .C""   /`   .+"" \     I     / ""+.   `\   `D.  XQ
 jQ'  .C'   |`  .""    )    _I    (     "".  |    `D.  4#
 Qf  .C     (   (    /    / /\    \     )  )     `D.  Qg
jW   C'      \__\_.+'    / /  \    `+._/__/       `D  jQ
Qf   C         C        /_/    \         D         D   Qk
Qf   C      _  C        \_\____/         D  _      D   QF
QL   C      \`+.__     _______     ______.+'/      D   QF
B&   C.      \   \|    ||     |    ||      /       D   Qf
jQ   `C.      \   |____|/     |____|/__   /      .D'   jW
 TQ   `C.      \._   `+.__________/___/|_/      .D'   jQ`
  9Q   `C.      C.`+._           |   |/.D'     .D'   jQ'
   ""Qg  `C.     `C.   `""+-------'   ' .D'     .D'   pW`
    ^WQy `C.     `C.        I        .D'    _.D' yW""
      ^9Qy_`C.    `C.       I       .D'   _.D jgW""
         `9WQgC.__ `C.      I      .D'  _.Dp@@""`
        ilmk `""""9WQQggyyyyyygyyyyyQggQWQH""""");
        Console.WriteLine($"Happy Halloween, {name}! It's {currentTime}. Don't be spooked by the math questions!");
    }
    internal static void DisplayChristmasMessage(string name, string currentTime)
    {
        Console.WriteLine(@$"Art by Joan Stark on https://www.asciiart.eu/

       _____________,--,
      | | | | | | |/ .-.\   HANG IN THERE
      |_|_|_|_|_|_/ /   `.      SANTA
       |_|__|__|_; |      \
       |___|__|_/| |     .'`}}
       |_|__|__/ | |   .'.'`\
       |__|__|/  ; ;  / /    \.-""-.
       ||__|_;   \ \  ||    /`___. \
       |_|___/\  /;.`,\\   {{_'___.;{{}}
       |__|_/ `;`__|`-.;|  |C` e e`\
       |___`L  \__|__|__|  | `'-o-' }}
       ||___|\__)___|__||__|\   ^  /`\
       |__|__|__|__|__|_{{___}}'.__.`\_.'}}
       ||___|__|__|__|__;\_)-'`\   {{_.-;
       |__|__|__|__|__|/` (`\__/     '-'
       |_|___|__|__/`      |
-jgs---|__|___|__/`         \-------------------
-.__.-.|___|___;`            |.__.-.__.-.__.-.__
  |     |     ||             |  |     |     |
-' '---' '---' \             /-' '---' '---' '--
     |     |    '.        .' |     |     |     |
'---' '---' '---' `-===-'`--' '---' '---' '---'
  |     |     |     |     |     |     |     |
-' '---' '---' '---' '---' '---' '---' '---' '--
     |     |     |     |     |     |     |     |
'---' '---' '---' '---' '---' '---' '---' '---'
");
        Console.WriteLine($"Merry Christmas, {name}! It's {currentTime}. Hope you get all the math questions right as a gift!");
    }

    internal static void DisplayNewYearMessage(string name, string currentTime)
    {
        // Next line's art was generated with https://patorjk.com/software/taag/#p=display&f=Big&t=Happy%20New%20Year
        Console.WriteLine($@"  _   _                           _   _                __   __              _ 
 | | | | __ _ _ __  _ __  _   _  | \ | | _____      __ \ \ / /__  __ _ _ __| |
 | |_| |/ _` | '_ \| '_ \| | | | |  \| |/ _ \ \ /\ / /  \ V / _ \/ _` | '__| |
 |  _  | (_| | |_) | |_) | |_| | | |\  |  __/\ V  V /    | |  __/ (_| | |  |_|
 |_| |_|\__,_| .__/| .__/ \__, | |_| \_|\___| \_/\_/     |_|\___|\__,_|_|  (_)
             |_|   |_|    |___/                                               ");
        Console.WriteLine(@"                                 .''.
       .''.             *''*    :_\/_:     . 
      :_\/_:   .    .:.*_\/_*   : /\ :  .'.:.'.
  .''.: /\ : _\(/_  ':'* /\ *  : '..'.  -=:o:=-
 :_\/_:'.:::. /)\*''*  .|.* '.\'/.'_\(/_'.':'.'
 : /\ : :::::  '*_\/_* | |  -= o =- /)\    '  *
  '..'  ':::'   * /\ * |'|  .'/.\'.  '._____
      *        __*..* |  |     :      |.   |' .---""|
       _*   .-'   '-. |  |     .--'|  ||   | _|    |
    .-'|  _.|  |    ||   '-__  |   |  |    ||      |
    |' | |.    |    ||       | |   |  |    ||      |
 ___|  '-'     '    """"       '-'   '-.'    '`      |____
jgs~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~
Art by Joan Stark on https://www.asciiart.eu/
~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~");

        Console.WriteLine($"Happy New Year, {name}! It's {currentTime}. \nWishing you a year full of correct answers and fun!");
    }
    #endregion // ascii art for Special Occasions
}
