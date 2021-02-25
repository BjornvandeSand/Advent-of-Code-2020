namespace Advent_of_Code_2020
{
	public class Day03
	{
		public static int Complete(string[] input, int slopeColumn, int slopeRow)
		{
			int column = 0;
			int treeCounter = 0;

			for (int i = 0; i < input.Length; i += slopeRow)
			{
				if (input[i][column % input[0].Length] == '#')
				{
					treeCounter++;
				}

				column += slopeColumn;
			}

			return treeCounter;
		}
	}
}