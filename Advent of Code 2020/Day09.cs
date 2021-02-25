using System;
using System.Collections.Generic;
using System.Linq;

namespace Advent_of_Code_2020
{
	public class Day09
	{
		public static long Part1(string[] input)
		{
			long[] inputParsed = new long[input.Length - 1];

			for (int i = 0; i < input.Length - 1; i++)
			{
				inputParsed[i] = Convert.ToInt64(input[i]);
			}

			for (int i = 25; i < inputParsed.Length; i++)
			{
				bool found = false;

				for (int j = i - 25; j < i; j++)
				{
					for (int k = i - 24; k < i; k++)
					{
						if (j != k && inputParsed[j] + inputParsed[k] == inputParsed[i])
						{
							found = true;
							break;
						}
					}
				}

				if (!found)
				{
					return inputParsed[i];
				}
			}

			return 0;
		}

		public static long Part2(string[] input)
		{
			long goal = Part1(input);

			long[] inputParsed = new long[input.Length - 1];

			for (int i = 0; i < input.Length - 1; i++)
			{
				inputParsed[i] = Convert.ToInt64(input[i]);
			}

			for (int i = 0; i < inputParsed.Length; i++)
			{
				long counter = inputParsed[i];
				int index = i + 1;

				while (counter < goal)
				{
					counter += inputParsed[index];

					if (counter == goal)
					{
						SortedSet<long> range = new SortedSet<long>();
						for (int j = i; j < index; j++)
						{
							range.Add(inputParsed[j]);
						}

						return range.First() + range.Last();
					}

					index++;
				}
			}

			return 0;
		}
	}
}