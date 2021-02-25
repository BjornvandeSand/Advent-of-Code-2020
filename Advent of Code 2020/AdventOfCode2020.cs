using System;
using System.IO;

namespace Advent_of_Code_2020
{
	class AdventOfCode2020
	{
		static void Main(string[] args)
		{
			Console.WriteLine("Bjorn van de Sand - Advent of Code 2020." + Environment.NewLine);

			Console.WriteLine("Which day?");
			int input = Int32.Parse(Console.ReadLine());
			Console.WriteLine("");

			string[] puzzleInput = ParseInput(input);

			switch (input)
			{
				case 1:
					int[] puzzle1Input = Array.ConvertAll(puzzleInput, int.Parse);
					Console.WriteLine(Day01.Part1(puzzle1Input));
					Console.WriteLine(Day01.Part2(puzzle1Input) + Environment.NewLine);
					break;

				case 2:
					Console.WriteLine(Day02.Part1(puzzleInput));
					Console.WriteLine(Day02.Part2(puzzleInput) + Environment.NewLine);
					break;

				case 3:
					Console.WriteLine(Day03.Complete(puzzleInput, 3, 1));
					Console.WriteLine(Day03.Complete(puzzleInput, 1, 1) * Day03.Complete(puzzleInput, 3, 1) * Day03.Complete(puzzleInput, 5, 1) * Day03.Complete(puzzleInput, 7, 1) * Day03.Complete(puzzleInput, 1, 2) + Environment.NewLine);
					break;

				case 4:
					Console.WriteLine(Day04.Part1(puzzleInput));
					Console.WriteLine(Day04.Part2(puzzleInput) + Environment.NewLine);
					break;

				case 5:
					Console.WriteLine(Day05.Part1(puzzleInput));
					Console.WriteLine(Day05.Part2(puzzleInput) + Environment.NewLine);
					break;

				case 6:
					Console.WriteLine(Day06.Part1(puzzleInput));
					Console.WriteLine(Day06.Part2(puzzleInput) + Environment.NewLine);
					break;

				case 7:
					Console.WriteLine(Day07.Part1(puzzleInput));
					Console.WriteLine(Day07.Part2(puzzleInput) + Environment.NewLine);
					break;

				case 8:
					Console.WriteLine(Day08.Part1(puzzleInput));
					Console.WriteLine(Day08.Part2(puzzleInput) + Environment.NewLine);
					break;

				case 9:
					Console.WriteLine(Day09.Part1(puzzleInput));
					Console.WriteLine(Day09.Part2(puzzleInput) + Environment.NewLine);
					break;

				case 10:
					Console.WriteLine(Day10.Part1(puzzleInput));
					Console.WriteLine(Day10.Part2(puzzleInput) + Environment.NewLine);
					break;

				case 11:
					Console.WriteLine(Day11.Part1(puzzleInput));
					Console.WriteLine(Day11.Part2(puzzleInput) + Environment.NewLine);
					break;

				case 12:
					Console.WriteLine(Day12.Part1(puzzleInput));
					Console.WriteLine(Day12.Part2(puzzleInput) + Environment.NewLine);
					break;

				case 13:
					Console.WriteLine(Day13.Part1(puzzleInput));
					Console.WriteLine(Day13.Part2(puzzleInput) + Environment.NewLine);
					break;

				case 14:
					Console.WriteLine(Day14.Part1(puzzleInput));
					Console.WriteLine(Day14.Part2(puzzleInput) + Environment.NewLine);
					break;

				case 15:
					Console.WriteLine(Day15.Complete(puzzleInput,2020));
					Console.WriteLine(Day15.Complete(puzzleInput,30000000) + Environment.NewLine);
					break;

				case 16:
					Console.WriteLine(Day16.Part1(puzzleInput));
					Console.WriteLine(Day16.Part2(puzzleInput) + Environment.NewLine);
					break;

				case 17:
					//Console.WriteLine(Day17.Part1(puzzleInput));
					//Console.WriteLine(Day17.Part2(puzzleInput) + Environment.NewLine);
					break;

				case 18:
					//Console.WriteLine(Day18.Part1(puzzleInput));
					//Console.WriteLine(Day18.Part2(puzzleInput) + Environment.NewLine);
					break;

				case 19:
					//Console.WriteLine(Day19.Part1(puzzleInput));
					//Console.WriteLine(Day19.Part2(puzzleInput) + Environment.NewLine);
					break;

				case 20:
					//Console.WriteLine(Day20.Part1(puzzleInput));
					//Console.WriteLine(Day20.Part2(puzzleInput) + Environment.NewLine);
					break;

				case 21:
					//Console.WriteLine(Day21.Part1(puzzleInput));
					//Console.WriteLine(Day21.Part2(puzzleInput) + Environment.NewLine);
					break;

				case 22:
					//Console.WriteLine(Day22.Part1(puzzleInput));
					//Console.WriteLine(Day22.Part2(puzzleInput) + Environment.NewLine);
					break;

				case 23:
					//Console.WriteLine(Day23.Part1(puzzleInput));
					//Console.WriteLine(Day23.Part2(puzzleInput) + Environment.NewLine);
					break;

				case 24:
					//Console.WriteLine(Day24.Part1(puzzleInput));
					//Console.WriteLine(Day24.Part2(puzzleInput) + Environment.NewLine);
					break;

				case 25:
					//Console.WriteLine(Day25.Part1(puzzleInput));
					//Console.WriteLine(Day25.Part2(puzzleInput) + Environment.NewLine);
					break;

				default:
					Environment.Exit(1);
					break;
			}

			Console.WriteLine("We done here!");
			Console.ReadLine();

			Environment.Exit(0);
		}

		static string[] ParseInput(int input)
		{
			return File.ReadAllText(input + ".txt").Split(new[] { Environment.NewLine },StringSplitOptions.None);
		}
	}
}