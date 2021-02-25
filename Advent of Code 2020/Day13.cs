using System;
using System.Collections.Generic;

namespace Advent_of_Code_2020
{
	public class Day13
	{
		public static int Part1(string[] input)
		{
			int goal = Int32.Parse(input[0]);
			SortedSet<int> busses = new SortedSet<int>();

			foreach (string bus in input[1].Split(','))
			{
				if (bus != "x")
				{
					busses.Add(Int32.Parse(bus));
				}
			}

			int currentShortestWait = int.MaxValue;
			int currentBestBus = 0;

			foreach (int i in busses)
			{
				int timeLeft = i - (goal % i);

				if (timeLeft < currentShortestWait)
				{
					currentShortestWait = timeLeft;
					currentBestBus = i;
				}
			}

			return currentBestBus * currentShortestWait;
		}

		public static ulong Part2(string[] input)
		{
			string[] bussesInput = input[1].Split(',');
			List<ulong> busIndexes = new List<ulong>();
			List<ulong> busses = new List<ulong>();

			for (ulong i = 0; i < (ulong)bussesInput.Length; i++)
			{
				if (bussesInput[i] != "x")
				{
					busIndexes.Add(i);
					busses.Add(UInt64.Parse(bussesInput[i]));
				}
			}

			ulong sum = 0;
			ulong stepsize = 0;
			ulong currentStep;

			for (int i = 0; i < busses.Count - 1; i++)
			{
				stepsize = lcm(busses[i], Math.Max(1, stepsize));
				for (ulong multitude = 1; true; multitude++)
				{
					currentStep = stepsize * multitude;

					if ((sum + currentStep + busIndexes[i + 1]) % busses[i + 1] == 0)
					{
						sum += currentStep;
						break;
					}
				}
			}

			return sum;
		}

		//https://stackoverflow.com/questions/13569810/least-common-multiple
		static ulong gcf(ulong a, ulong b)
		{
			while (b != 0)
			{
				ulong temp = b;
				b = a % b;
				a = temp;
			}
			return a;
		}

		//https://stackoverflow.com/questions/13569810/least-common-multiple
		static ulong lcm(ulong a, ulong b)
		{
			return (a / gcf(a, b)) * b;
		}
	}
}