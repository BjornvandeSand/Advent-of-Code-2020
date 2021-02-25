namespace Advent_of_Code_2020
{
	public class Day01
	{
		public static int Part1(int[] input)
		{
			for (int i = 0; i < input.Length; i++)
			{
				for (int j = i; j < input.Length; j++)
				{
					if (input[i] + input[j] == 2020)
					{
						return input[i] * input[j];
					}
				}
			}

			return 0;
		}

		public static int Part2(int[] input)
		{
			for (int i = 0; i < input.Length; i++)
			{
				for (int j = i + 1; j < input.Length - 1; j++)
				{
					for (int k = j + 1; k < input.Length - 2; k++)
					{
						if (input[i] + input[j] + input[k] == 2020)
						{
							return input[i] * input[j] * input[k];
						}
					}
				}
			}

			return 0;
		}
	}
}