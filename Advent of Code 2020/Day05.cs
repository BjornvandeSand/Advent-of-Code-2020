using System.Collections.Generic;

namespace Advent_of_Code_2020
{
	public class Day05
	{
		public static int Part1(string[] input)
		{
			int highestSeatID = 0;

			foreach (string passport in input)
			{
				int highEnd = 127;
				int lowEnd = 0;

				for (int i = 0; i < 7; i++)
				{
					if (passport[i] == 'B')
					{
						if ((lowEnd % 2) == 0) { lowEnd++; }
						lowEnd = (highEnd + lowEnd) / 2;
					}
					else if (passport[i] == 'F')
					{
						highEnd = (lowEnd + highEnd) / 2;
					}
				}

				int row = lowEnd;

				highEnd = 7;
				lowEnd = 0;

				for (int i = 6; i < 10; i++)
				{
					if (passport[i] == 'R')
					{
						if ((lowEnd % 2) == 0) { lowEnd++; }
						lowEnd = (highEnd + lowEnd) / 2;
					}
					else if (passport[i] == 'L')
					{
						highEnd = (lowEnd + highEnd) / 2;
					}
				}

				int column = lowEnd;

				int seatID = row * 8 + column;

				if (seatID > highestSeatID)
				{
					highestSeatID = seatID;
				}
			}

			return highestSeatID;
		}

		public static int Part2(string[] input)
		{
			int highestSeatID = 0;
			int lowestSeatID = 127 * 8 + 8;

			SortedSet<int> seatIDs = new SortedSet<int>();

			foreach (string passport in input)
			{
				int highEnd = 127;
				int lowEnd = 0;

				for (int i = 0; i < 7; i++)
				{
					if (passport[i] == 'B')
					{
						if ((lowEnd % 2) == 0) { lowEnd++; }
						lowEnd = (highEnd + lowEnd) / 2;
					}
					else if (passport[i] == 'F')
					{
						highEnd = (lowEnd + highEnd) / 2;
					}
				}

				int row = lowEnd;

				highEnd = 7;
				lowEnd = 0;

				for (int i = 6; i < 10; i++)
				{
					if (passport[i] == 'R')
					{
						if ((lowEnd % 2) == 0) { lowEnd++; }
						lowEnd = (highEnd + lowEnd) / 2;
					}
					else if (passport[i] == 'L')
					{
						highEnd = (lowEnd + highEnd) / 2;
					}
				}

				int column = lowEnd;

				int seatID = row * 8 + column;
				seatIDs.Add(seatID);

				if (seatID > highestSeatID)
				{
					highestSeatID = seatID;
				}
				if (seatID < lowestSeatID)
				{
					lowestSeatID = seatID;
				}
			}

			for (int i = lowestSeatID; i < highestSeatID; i++)
			{
				if (!seatIDs.Contains(i))
				{
					return (i);
				}
			}

			return 0;
		}
	}
}