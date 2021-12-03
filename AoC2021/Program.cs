// See https://aka.ms/new-console-template for more information
using AoC2021.Core;

Console.WriteLine("Advent of Code 2021");

var runner = new Runner();

foreach (var day in runner.Days)
{
    Console.WriteLine(day);
}

Console.ReadKey();
