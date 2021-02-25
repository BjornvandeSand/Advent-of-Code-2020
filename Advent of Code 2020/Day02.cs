using System;

namespace Advent_of_Code_2020
{
	public class Day02
	{
		public static int Part1(string[] input)
		{
			int validPasswords = 0;

			foreach (string inputLine in input)
			{
				string[] breakDown = inputLine.Split(':');
				string requirements = breakDown[0];
				string password = breakDown[1];
				int occurences = 0;

				foreach (char c in password)
				{
					if (c == breakDown[0][breakDown[0].Length - 1])
					{
						occurences++;
					}
				}

				string[] requiredValues = breakDown[0].Split('-');

				requiredValues[1] = requiredValues[1].Substring(0, requiredValues[1].Length - 2);

				if (occurences >= Int32.Parse(requiredValues[0]) && occurences <= Int32.Parse(requiredValues[1]))
				{
					validPasswords++;
				}
			}

			return validPasswords;
		}

		public static int Part2(string[] input)
		{
			int validPasswords = 0;

			foreach (string inputLine in input)
			{
				string[] breakDown = inputLine.Split(':');
				string requirements = breakDown[0];
				string password = breakDown[1];

				string[] requiredValues = breakDown[0].Split('-');
				requiredValues[1] = requiredValues[1].Substring(0, requiredValues[1].Length - 2);

				if (password[Int32.Parse(requiredValues[0])] == breakDown[0][breakDown[0].Length - 1] ^ password[Int32.Parse(requiredValues[1])] == breakDown[0][breakDown[0].Length - 1])
				{
					validPasswords++;
				}
			}

			return validPasswords;
		}
	}
}