using System;
using System.Collections.Generic;

namespace Advent_of_Code_2020
{
	public class Day10
	{
		public static int Part1(string[] input)
		{
			SortedSet<int> adapters = new SortedSet<int>();

			foreach (string line in input)
			{
				adapters.Add(Int32.Parse(line));
			}

			int oneJolts = 0;
			int threeJolts = 0;

			int counter = 0;

			foreach (int adapter in adapters)
			{
				int difference = adapter - counter;

				switch (difference)
				{
					case 1:
						oneJolts++;
						break;

					case 3:
						threeJolts++;
						break;

					default:
						break;
				}

				counter = adapter;
			}

			return oneJolts * (threeJolts + 1);
		}

		public static long Part2(string[] input)
		{
			//FIRST WE PREP ALL THE CONNECTIONS
			//List of all the adapters in ascending numerical order
			SortedSet<int> adapters = new SortedSet<int>();

			adapters.Add(0);
			foreach (string line in input)
			{
				adapters.Add(Int32.Parse(line));
			}

			//Array of all the adapters an indexed adapter can be referred to from
			List<int>[] connections = new List<int>[adapters.Max + 1];

			//Initialize it
			for (int i = 0; i < connections.Length; i++)
			{
				connections[i] = new List<int>();
			}

			//Create a list for each adapter which lower joltage adapters can connect to it
			foreach (int adapter in adapters)
			{
				for (int i = 1; i <= 3; i++)
				{
					int calc = adapter + i;

					if (adapters.Contains(calc))
					{
						connections[calc].Add(adapter);
					}
				}
			}

			//Represents the amount of ways an adapter of the indexed joltage can be reached
			long[] waysToReach = new long[adapters.Max + 1];

			//NOW WE GET TO WORK
			//Walk through all jolts, ascendingly, until maximum joltage adapter
			foreach (int jolt in adapters)
			{
				//There is an adapter for this joltage, so we should evaluate it
				if (adapters.Contains(jolt))
				{
					//Represents the total number of ways to get to this adapter
					long sum = 0;

					foreach (int j in connections[jolt])
					{
						sum += waysToReach[j];
					}

					waysToReach[jolt] = Math.Max(1, sum);
				}
			}

			/*
			Console.WriteLine("*TEST*");
			foreach(int jolt in adapters)
			{
				string output = "";
				
				if (adapters.Contains(jolt))
				{
					foreach (int connection in connections[jolt])
					{
						output += connection + " ";
					}
					
					Console.WriteLine(jolt + " joltage adapter is connected from " + output + "and can be reached in " + waysToReach[jolt] + " ways.");
				}
			}
			*/

			return waysToReach[adapters.Max];
		}
	}
}