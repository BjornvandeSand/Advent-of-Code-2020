using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace Advent_of_Code_2020
{
	public class Day16
	{
		public static int Part1(string[] input)
		{
			//Parse the requirements into something usable
			for(int i = 0; i < 20; i++)
			{
				string values = input[i].Split(':')[1];
				string[] sets = values.Split(new string[] { " or " }, StringSplitOptions.None);

			}

			return 0;
		}
		public static int Part2(string[] input)
		{
			return 0;
		}
	}
}