using System.Collections.Generic;

namespace Advent_of_Code_2020
{
	public class Day06
	{
		public static int Part1(string[] input)
		{
			int counter = 0;
			SortedSet<char> questions = new SortedSet<char>();

			foreach (string line in input)
			{
				if (line == "")
				{
					counter += questions.Count;
					questions.Clear();
				}
				else
				{
					foreach (char c in line)
					{
						questions.Add(c);
					}
				}
			}

			return counter;
		}

		public static int Part2(string[] input)
		{
			int counter = 0;
			bool start = true;
			string toBeRemoved = "";
			SortedSet<char> questions = new SortedSet<char>();

			foreach (string line in input)
			{
				if (line == "")
				{
					foreach (char c in toBeRemoved)
					{
						questions.Remove(c);
					}

					toBeRemoved = "";
					counter += questions.Count;
					questions.Clear();
					start = true;
				}
				else
				{
					if (start)
					{
						foreach (char c in line)
						{
							questions.Add(c);
						}
						start = false;
					}
					else
					{
						foreach (char c in questions)
						{
							if (!line.Contains("" + c))
							{
								toBeRemoved += c;
							}
						}
					}
				}
			}

			return counter;
		}
	}
}