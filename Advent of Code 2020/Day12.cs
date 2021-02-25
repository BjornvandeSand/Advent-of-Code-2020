using System;

namespace Advent_of_Code_2020
{
	public class Day12
	{
		public static int Part1(string[] input)
		{
			int posx = 0;
			int posy = 0;
			int facing = 90;

			foreach (string line in input)
			{
				char instruction = line[0];
				int amount = Int32.Parse(line.Substring(1, line.Length - 1));

				switch (instruction)
				{
					case ('F'):
						switch (facing)
						{
							case (0):
								posy += amount;
								break;

							case (90):
								posx += amount;
								break;

							case (180):
								posy -= amount;
								break;

							case (270):
								posx -= amount;
								break;

							default: //Should never happen
									 //Console.WriteLine("Oy! Hol' up... Unknown facing angle:" + facing);
								break;
						}
						break;

					case ('L'):
						facing = (facing - amount + 360) % 360;
						break;

					case ('R'):
						facing = (facing + amount + 360) % 360;
						break;

					case ('N'):
						posy += amount;
						break;

					case ('E'):
						posx += amount;
						break;

					case ('S'):
						posy -= amount;
						break;

					case ('W'):
						posx -= amount;
						break;

					default: //should never happen
							 //Console.WriteLine("Oy! Hol' up... Unknown instruction:" + instruction);
						break;
				}
			}

			return Math.Abs(posx) + Math.Abs(posy);
		}

		public static int Part2(string[] input)
		{
			int shipPosX = 0;
			int shipPosY = 0;

			int waypointPosX = 10;
			int waypointPosY = 1;

			for (int i = 0; i < input.Length; i++)
			{
				char instruction = input[i][0];
				int amount = Int32.Parse(input[i].Substring(1, input[i].Length - 1));

				int tempX;

				switch (instruction)
				{
					case ('F'):
						shipPosX += waypointPosX * amount;
						shipPosY += waypointPosY * amount;
						break;

					case ('L'):
						switch (amount)
						{
							case (90)://same as R270
								tempX = waypointPosX;
								waypointPosX = waypointPosY * -1;
								waypointPosY = tempX;
								break;

							case (180): //same as R180
								waypointPosX *= -1;
								waypointPosY *= -1;
								break;

							case (270)://same as R90
								tempX = waypointPosX;
								waypointPosX = waypointPosY;
								waypointPosY = tempX * -1;
								break;

							default: //should never happen
								Console.WriteLine("Oy! Hol' up... Unknown instruction:" + instruction);
								break;
						}

						break;

					case ('R'):
						switch (amount)
						{
							case (90)://same as L270
								tempX = waypointPosX;
								waypointPosX = waypointPosY;
								waypointPosY = tempX * -1;
								break;

							case (180): //same as L180
								waypointPosX *= -1;
								waypointPosY *= -1;
								break;

							case (270)://same as L90
								tempX = waypointPosX;
								waypointPosX = waypointPosY * -1;
								waypointPosY = tempX;
								break;

							default: //should never happen
								Console.WriteLine("Oy! Hol' up... Unknown instruction:" + instruction);
								break;
						}

						break;

					case ('N'):
						waypointPosY += amount;
						break;

					case ('E'):
						waypointPosX += amount;
						break;

					case ('S'):
						waypointPosY -= amount;
						break;

					case ('W'):
						waypointPosX -= amount;
						break;

					default: //should never happen
						Console.WriteLine("Oy! Hol' up... Unknown instruction:" + instruction);
						break;
				}

				/*
				Console.WriteLine("Line: " + (i + 1));
				Console.WriteLine("instruction: " + input[i]);
				Console.WriteLine("Ship location : X" + shipPosX + "/Y" + shipPosY);
				Console.WriteLine("Waypoint location : X" + waypointPosX + "/Y" + waypointPosY);
				Console.ReadLine();
				*/
			}

			return Math.Abs(shipPosX) + Math.Abs(shipPosY);
		}
	}
}