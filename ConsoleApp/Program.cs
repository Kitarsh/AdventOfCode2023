// See https://aka.ms/new-console-template for more information
using Domain;

Console.WriteLine("Hello, World!");

var lines = File.ReadAllLines("input.txt");
var drawGame = new DrawGame(lines);

int result = drawGame.SumPowersOfGames();

Console.WriteLine("The power sum is : {0}", result);