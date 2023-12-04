// See https://aka.ms/new-console-template for more information
using Domain;

Console.WriteLine("Hello, World!");

var lines = File.ReadAllLines("input.txt");

var cardGame = new CardGame(lines);

Console.WriteLine("Result is : {0}", cardGame.ProcessCards());