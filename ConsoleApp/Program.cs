// See https://aka.ms/new-console-template for more information
using Domain;

Console.WriteLine("Hello, World!");

var lines = File.ReadAllLines("input.txt");
var drawGame = new DrawGame(lines);

var redCubeLimit = 12;
var greenCubeLimit = 13;
var blueCubeLimit = 14;

int result = drawGame.SumGameIdWithLimit(redCubeLimit, greenCubeLimit, blueCubeLimit);

Console.WriteLine("The id sum is : {0}", result);