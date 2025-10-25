using MathGame.FrederikBlem;

var now = DateTime.Now;
string? name = Helpers.GetName();

Menu menu = new Menu();
menu.ShowMenu(name, now);