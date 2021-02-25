using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace Advent_of_Code_2020
{
	public class Day15
	{
		public static int Complete(string[] input, int target)
		{
			int[] spokenNumbers = new int[target];
			Dictionary<int, int> latestEntry = new Dictionary<int, int>();

			string[] numbers = input[0].Split(',');

			spokenNumbers[0] = Int32.Parse(numbers[0]);
			for (int i = 1; i < numbers.Length; i++)
			{
				int value = Int32.Parse(numbers[i]);
				spokenNumbers[i] = value;
				latestEntry[spokenNumbers[i - 1]] = i - 1;
			}

			for (int currentIndex = numbers.Length; currentIndex < target; currentIndex++)
			{
				int search = spokenNumbers[currentIndex - 1];

				//Console.WriteLine("***INDEX: " + currentIndex + " ***");
				//Console.WriteLine("Value saught: " + spokenNumbers[currentIndex - 1]);

				if (latestEntry.ContainsKey(spokenNumbers[currentIndex - 1]))
				{
					int distance = currentIndex - 1 - latestEntry[search];
					spokenNumbers[currentIndex] = distance;
					
					//Console.WriteLine("FOUND: " + distance);
				} else
				{
					spokenNumbers[currentIndex] = 0;

					//Console.WriteLine("NOT FOUND: " + 0);
				}

				latestEntry[spokenNumbers[currentIndex - 1]] = currentIndex - 1;
				//Console.WriteLine();
			}

			return spokenNumbers[target - 1]; //Correction for index
		}
	}

	/*public static int Complete(string[] input, int target)
		{
			int[] spokenNumbers = new int[target];
			Dictionary<int, int> latestEntry = new Dictionary<int, int>();

			string[] numbers = input[0].Split(',');

			for(int i = 0; i < numbers.Length; i++)
			{
				int value = Int32.Parse(numbers[i]);
				spokenNumbers[i] = value;
				latestEntry[value] = i;

				Console.WriteLine("***INDEX: " + i + " ***");
				Console.WriteLine("Value read: " + value);
			}

			for (int currentIndex = 3; currentIndex < 5; currentIndex++)
			{
				
				int search = spokenNumbers[currentIndex - 1];

				Console.WriteLine("***INDEX: " + currentIndex + " ***");
				Console.WriteLine("Value saught: " + spokenNumbers[currentIndex - 1]);

				if (latestEntry.ContainsKey(spokenNumbers[currentIndex - 1]))
				{
					int distance = currentIndex - 1 - latestEntry[search];
					spokenNumbers[currentIndex] = distance;
					
					Console.WriteLine("Value determined: " + distance);
					Console.WriteLine(search);
				} else
				{
					spokenNumbers[currentIndex] = 0;

					Console.WriteLine("Value determined: " + 0);
					Console.WriteLine(search);
				}

				latestEntry[spokenNumbers[currentIndex - 1]] = currentIndex - 1;
			}

			return spokenNumbers[target - 1]; //Correction for index
		}
	}*/
}