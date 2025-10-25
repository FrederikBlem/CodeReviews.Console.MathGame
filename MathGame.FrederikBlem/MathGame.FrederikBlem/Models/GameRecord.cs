namespace MathGame.FrederikBlem.Models;
internal class GameRecord
{
    public string NamePlayer { get; set; }
    public DateTime Date { get; set; }
    public int Score { get; set; }
    public GameType Type { get; set; }
    public GameDifficulty Difficulty { get; set; }
    public TimeSpan TimeTaken { get; set; }
}

internal enum GameType: int
{
    Addition = 0,
    Subtraction = 1,
    Multiplication = 2,
    Division = 3,
    Random = 4
}

internal enum GameDifficulty: int
{
    Easy = 0,
    Medium = 1,
    Hard = 2
}