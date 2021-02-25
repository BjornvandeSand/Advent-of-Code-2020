using System;
using System.Collections.Generic;

namespace Advent_of_Code_2020
{
	public class Day11
	{

		public static long Part1(string[] input)
		{
			Grid grid = new Grid(input);

			Console.WriteLine(grid);

			while (grid.update()) { }

			Console.WriteLine(grid);

			return grid.occupiedSeats();
		}

		public static long Part2(string[] input)
		{
			Grid2 grid = new Grid2(input);

			Console.WriteLine(grid);

			while (grid.update()) { }

			return grid.occupiedSeats();
		}
	}

	class Grid
	{
		private Location[][] grid;
		private List<Location> seats;
		public Grid(string[] input)
		{
			//Initializations
			grid = new Location[input.Length][];
			seats = new List<Location>();

			for (int x = 0; x < input.Length; x++)
			{
				grid[x] = new Location[input[0].Length];

				for (int y = 0; y < input[x].Length; y++)
				{
					grid[x][y] = new Location(input[x][y]);
					if (input[x][y] == 'L')
					{
						seats.Add(grid[x][y]);
					}
				}
			}

			//Add neighbours to seats		
			for (int x = 0; x < input.Length; x++)
			{
				for (int y = 0; y < input[0].Length; y++)
				{
					if (grid[x][y].State == 'L')
					{
						for (int dx = -1; dx <= 1; dx++)
						{
							for (int dy = -1; dy <= 1; dy++)
							{
								int newIndexX = x + dx;
								int newIndexY = y + dy;

								if (newIndexX >= 0 && newIndexX < grid.Length && newIndexY >= 0 && newIndexY < grid[0].Length)
								{
									if (!(dx == 0 && dy == 0))
									{
										if (grid[newIndexX][newIndexY].State == 'L')
										{
											grid[x][y].seatNeighbors.Add(grid[newIndexX][newIndexY]);
										}
									}
								}
							}
						}
					}
				}
			}
		}

		public bool update()
		{
			bool changes = false;

			foreach (Location seat in seats)
			{
				seat.generateSuccessor();
			}

			foreach (Location seat in seats)
			{
				changes |= seat.update();
			}

			return changes;
		}

		public int occupiedSeats()
		{
			int counter = 0;

			foreach (Location seat in seats)
			{
				if (seat.State == '#')
				{
					counter++;
				}
			}

			return counter;
		}

		public override string ToString()
		{
			string output = "";

			for (int x = 0; x < grid.Length; x++)
			{
				for (int y = 0; y < grid[0].Length; y++)
				{
					output += grid[x][y];
				}

				output += Environment.NewLine;
			}

			return output;
		}

		private class Location
		{
			public char State { get; set; }
			public List<Location> seatNeighbors { get; set; }
			char successorState;

			public Location(char state)
			{
				this.State = state;
				seatNeighbors = new List<Location>();
			}

			public void generateSuccessor()
			{
				int seatedNeighbors = 0;
				foreach (Location seat in seatNeighbors)
				{
					if (seat.State == '#')
					{
						seatedNeighbors++;
					}
				}

				successorState = State;

				switch (State)
				{
					case 'L':
						if (seatedNeighbors == 0)
						{
							successorState = '#';
						}
						break;

					case '#':
						if (seatedNeighbors >= 4)
						{
							successorState = 'L';
						}
						break;

					default:
						break;
				}
			}

			public bool update()
			{
				bool changed = State != successorState;
				State = successorState;

				return changed;
			}

			public override string ToString()
			{
				return "" + State;
			}
		}
	}
	class Grid2
	{
		public Location[][] grid;
		public List<Location> seats;
		public Grid2(string[] input)
		{
			//Initializations
			grid = new Location[input.Length][];
			seats = new List<Location>();

			for (int x = 0; x < input.Length; x++)
			{
				grid[x] = new Location[input[0].Length];

				for (int y = 0; y < input[x].Length; y++)
				{
					grid[x][y] = new Location(this, input[x][y], x, y);
					if (input[x][y] != '.')
					{
						seats.Add(grid[x][y]);
					}
				}
			}
		}

		public bool update()
		{
			bool changes = false;

			foreach (Location seat in seats)
			{
				seat.generateSuccessor();
			}

			foreach (Location seat in seats)
			{
				changes |= seat.update();
			}

			return changes;
		}

		public int occupiedSeats()
		{
			int counter = 0;

			foreach (Location seat in seats)
			{
				if (seat.State == '#')
				{
					counter++;
				}
			}

			return counter;
		}

		public override string ToString()
		{
			string output = "";

			for (int x = 0; x < grid.Length; x++)
			{
				for (int y = 0; y < grid[0].Length; y++)
				{
					output += grid[x][y];
				}

				output += Environment.NewLine;
			}

			return output;
		}

		public class Location
		{
			public char State { get; set; }

			Grid2 owner;
			char successorState;
			int x;
			int y;

			public Location(Grid2 owner, char state, int x, int y)
			{
				this.owner = owner;
				this.State = state;
				this.x = x;
				this.y = y;
			}

			public void generateSuccessor()
			{
				int seatedNeighbors = 0;
				int newIndexX;
				int newIndexY;

				//up
				for (newIndexX = x - 1; newIndexX >= 0; newIndexX--)
				{

					if (owner.grid[newIndexX][y].State == '#')
					{
						seatedNeighbors++;
						break;
					}

					if (owner.grid[newIndexX][y].State == 'L')
					{
						break;
					}
				}

				//up right
				for (newIndexX = x - 1, newIndexY = y + 1; newIndexX >= 0 & newIndexY < owner.grid[0].Length; newIndexX--, newIndexY++)
				{
					if (owner.grid[newIndexX][newIndexY].State == '#')
					{
						seatedNeighbors++;
						break;
					}

					if (owner.grid[newIndexX][newIndexY].State == 'L')
					{
						break;
					}
				}


				//right
				for (newIndexY = y + 1; newIndexY < owner.grid[0].Length; newIndexY++)
				{
					if (owner.grid[x][newIndexY].State == '#')
					{
						seatedNeighbors++;
						break;
					}

					if (owner.grid[x][newIndexY].State == 'L')
					{
						break;
					}
				}

				//right down
				for (newIndexX = x + 1, newIndexY = y + 1; newIndexX < owner.grid.Length & newIndexY < owner.grid[0].Length; newIndexX++, newIndexY++)
				{
					if (owner.grid[newIndexX][newIndexY].State == '#')
					{
						seatedNeighbors++;
						break;
					}

					if (owner.grid[newIndexX][newIndexY].State == 'L')
					{
						break;
					}
				}

				//down
				for (newIndexX = x + 1; newIndexX < owner.grid.Length; newIndexX++)
				{

					if (owner.grid[newIndexX][y].State == '#')
					{
						seatedNeighbors++;
						break;
					}

					if (owner.grid[newIndexX][y].State == 'L')
					{
						break;
					}
				}

				//down left
				for (newIndexX = x + 1, newIndexY = y - 1; newIndexX < owner.grid.Length & newIndexY >= 0; newIndexX++, newIndexY--)
				{
					if (owner.grid[newIndexX][newIndexY].State == '#')
					{
						seatedNeighbors++;
						break;
					}

					if (owner.grid[newIndexX][newIndexY].State == 'L')
					{
						break;
					}
				}

				//left
				for (newIndexY = y - 1; newIndexY >= 0; newIndexY--)
				{

					if (owner.grid[x][newIndexY].State == '#')
					{
						seatedNeighbors++;
						break;
					}

					if (owner.grid[x][newIndexY].State == 'L')
					{
						break;
					}
				}

				//left up
				for (newIndexX = x - 1, newIndexY = y - 1; newIndexX >= 0 & newIndexY >= 0; newIndexX--, newIndexY--)
				{
					if (owner.grid[newIndexX][newIndexY].State == '#')
					{
						seatedNeighbors++;
						break;
					}

					if (owner.grid[newIndexX][newIndexY].State == 'L')
					{
						break;
					}
				}

				successorState = State;

				switch (State)
				{
					case 'L':
						if (seatedNeighbors == 0)
						{
							successorState = '#';
						}
						break;

					case '#':
						if (seatedNeighbors >= 5)
						{
							successorState = 'L';
						}
						break;

					default:
						break;
				}
			}

			public bool update()
			{
				bool changed = State != successorState;
				State = successorState;

				return changed;
			}

			public override string ToString()
			{
				return "" + State;
			}
		}
	}
}