// See https://aka.ms/new-console-template for more information
using Domain;

Console.WriteLine("Hello, World!");

var input = File.ReadAllText("input.txt");

var schematic = new Schematic(input);

Console.WriteLine("The result is : {0}", schematic.GetGearSum());