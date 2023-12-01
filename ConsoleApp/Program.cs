// See https://aka.ms/new-console-template for more information
using Domain;

Console.WriteLine("Hello, World!");

var result = new Calibration("input.txt").GetTotal();
Console.WriteLine("Result is {0}", result.ToString());