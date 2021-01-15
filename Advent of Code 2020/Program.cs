using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace Advent_of_Code_2020
{
	class Program
	{
		static void Main(string[] args)
		{
			Console.WriteLine("Bjorn van de Sand - Advent of Code 2020." + Environment.NewLine);

			Console.WriteLine("Which day?");
			int input = Int32.Parse(Console.ReadLine());
			Console.WriteLine("");

			string[] puzzleInput = ParseInput(input);

			switch (input)
			{
				case 1:
					int[] puzzle1Input = Array.ConvertAll(puzzleInput, int.Parse);
					Console.WriteLine(Puzzle1Part1(puzzle1Input));
					Console.WriteLine(Puzzle1Part2(puzzle1Input) + Environment.NewLine);
					break;

				case 2:
					Console.WriteLine(Puzzle2Part1(puzzleInput));
					Console.WriteLine(Puzzle2Part2(puzzleInput) + Environment.NewLine);
					break;

				case 3:
					Console.WriteLine(Puzzle3(puzzleInput, 3, 1));
					Console.WriteLine(Puzzle3(puzzleInput, 1, 1) * Puzzle3(puzzleInput, 3, 1) * Puzzle3(puzzleInput, 5, 1) * Puzzle3(puzzleInput, 7, 1) * Puzzle3(puzzleInput, 1, 2) + Environment.NewLine);
					break;

				case 4:
					Console.WriteLine(Puzzle4Part1(puzzleInput));
					Console.WriteLine(Puzzle4Part2(puzzleInput) + Environment.NewLine);
					break;

				case 5:
					Console.WriteLine(Puzzle5Part1(puzzleInput));
					Console.WriteLine(Puzzle5Part2(puzzleInput) + Environment.NewLine);
					break;

				case 6:
					Console.WriteLine(Puzzle6Part1(puzzleInput));
					Console.WriteLine(Puzzle6Part2(puzzleInput) + Environment.NewLine);
					break;

				case 7:
					Console.WriteLine(Puzzle7Part1(puzzleInput));
					Console.WriteLine(Puzzle7Part2(puzzleInput) + Environment.NewLine);
					break;

				case 8:
					Console.WriteLine(Puzzle8Part1(puzzleInput));
					Console.WriteLine(Puzzle8Part2(puzzleInput) + Environment.NewLine);
					break;

				case 9:
					Console.WriteLine(Puzzle9Part1(puzzleInput));
					Console.WriteLine(Puzzle9Part2(puzzleInput) + Environment.NewLine);
					break;

				case 10:
					Console.WriteLine(Puzzle10Part1(puzzleInput));
					Console.WriteLine(Puzzle10Part2(puzzleInput) + Environment.NewLine);
					break;

				case 11:
					//Console.WriteLine(Puzzle11Part1(puzzleInput));
					//Console.WriteLine(Puzzle11Part2(puzzleInput) + Environment.NewLine);
					break;

				case 12:
					//Console.WriteLine(Puzzle12Part1(puzzleInput));
					//Console.WriteLine(Puzzle12Part2(puzzleInput) + Environment.NewLine);
					break;

				case 13:
					//Console.WriteLine(Puzzle13Part1(puzzleInput));
					//Console.WriteLine(Puzzle13Part2(puzzleInput) + Environment.NewLine);
					break;

				case 14:
					//Console.WriteLine(Puzzle14Part1(puzzleInput));
					//Console.WriteLine(Puzzle14Part2(puzzleInput) + Environment.NewLine);
					break;

				case 15:
					//Console.WriteLine(Puzzle15Part1(puzzleInput));
					//Console.WriteLine(Puzzle15Part2(puzzleInput) + Environment.NewLine);
					break;

				case 16:
					//Console.WriteLine(Puzzle16Part1(puzzleInput));
					//Console.WriteLine(Puzzle16Part2(puzzleInput) + Environment.NewLine);
					break;

				case 17:
					//Console.WriteLine(Puzzle17Part1(puzzleInput));
					//Console.WriteLine(Puzzle17Part2(puzzleInput) + Environment.NewLine);
					break;

				case 18:
					//Console.WriteLine(Puzzle18Part1(puzzleInput));
					//Console.WriteLine(Puzzle18Part2(puzzleInput) + Environment.NewLine);
					break;

				case 19:
					//Console.WriteLine(Puzzle19Part1(puzzleInput));
					//Console.WriteLine(Puzzle19Part2(puzzleInput) + Environment.NewLine);
					break;

				case 20:
					//Console.WriteLine(Puzzle20Part1(puzzleInput));
					//Console.WriteLine(Puzzle20Part2(puzzleInput) + Environment.NewLine);
					break;

				case 21:
					//Console.WriteLine(Puzzle21Part1(puzzleInput));
					//Console.WriteLine(Puzzle21Part2(puzzleInput) + Environment.NewLine);
					break;

				case 22:
					//Console.WriteLine(Puzzle22Part1(puzzleInput));
					//Console.WriteLine(Puzzle22Part2(puzzleInput) + Environment.NewLine);
					break;

				case 23:
					//Console.WriteLine(Puzzle23Part1(puzzleInput));
					//Console.WriteLine(Puzzle23Part2(puzzleInput) + Environment.NewLine);
					break;

				case 24:
					//Console.WriteLine(Puzzle24Part1(puzzleInput));
					//Console.WriteLine(Puzzle24Part2(puzzleInput) + Environment.NewLine);
					break;

				case 25:
					//Console.WriteLine(Puzzle25Part1(puzzleInput));
					//Console.WriteLine(Puzzle25Part2(puzzleInput) + Environment.NewLine);
					break;

				default:
					Environment.Exit(1);
					break;
			}

			Console.WriteLine("We done here!");
			Console.ReadLine();

			Environment.Exit(0);
		}

		static string[] ParseInput(int input)
		{
			return File.ReadAllText(input + ".txt").Split(
				new[] { Environment.NewLine },
				StringSplitOptions.None
			);
		}

		static int Puzzle1Part1(int[] input)
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

		static int Puzzle1Part2(int[] input)
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

		static int Puzzle2Part1(string[] input)
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

		static int Puzzle2Part2(string[] input)
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

		static int Puzzle3(string[] input, int slopeColumn, int slopeRow)
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

		static int Puzzle4Part1(string[] input)
		{
			int validPassports = 0;

			List<string> passports = new List<string>();

			string tempData = "";

			string[] requirements = new string[]
			{
				"byr", "iyr", "eyr", "hgt", "hcl", "ecl", "pid"
			};

			foreach (string line in input)
			{

				if (line == "")
				{
					passports.Add(tempData);
					tempData = "";
				}
				else
				{
					tempData += " " + line;
				}
			}

			foreach (string passport in passports)
			{
				bool valid = true;

				foreach (string requirement in requirements)
				{
					if (!passport.Contains(requirement))
					{
						valid = false;
						break;
					}
				}

				if (valid)
				{
					validPassports++;
				}
			}

			return validPassports;
		}

		static int Puzzle4Part2(string[] input)
		{
			int validPassports = 0;

			List<string> passports = new List<string>();

			string tempData = "";

			string[] requirements = new string[]
			{
				"byr", "iyr", "eyr", "hgt", "hcl", "ecl", "pid"
			};

			foreach (string line in input)
			{

				if (line == "")
				{
					passports.Add(tempData);
					tempData = "";
				}
				else
				{
					tempData += " " + line;
				}
			}

			//Check all the passports
			foreach (string passport in passports)
			{
				bool valid = true; //Good passport until proven otherwise
				string[] pairs = passport.Split(' ');

				//Check every requirement for this passport
				foreach (string requirement in requirements)
				{
					bool requirementFound = false; //Requirement isn't found until it is

					//Check every pair if it contains this requirement
					foreach (string pair in pairs)
					{
						string[] keyValuePair = pair.Split(':');
						if (keyValuePair[0] == requirement)
						{
							switch (requirement)
							{
								case "byr":
									if (Int32.Parse(keyValuePair[1]) >= 1920 && Int32.Parse(keyValuePair[1]) <= 2002)
									{
										requirementFound = true;
									}

									break;

								case "iyr":
									if (Int32.Parse(keyValuePair[1]) >= 2010 && Int32.Parse(keyValuePair[1]) <= 2020)
									{
										requirementFound = true;
									}

									break;

								case "eyr":
									if (Int32.Parse(keyValuePair[1]) >= 2020 && Int32.Parse(keyValuePair[1]) <= 2030)
									{
										requirementFound = true;
									}

									break;

								case "hgt":
									if (keyValuePair[1].Length >= 4)
									{
										string measurement = keyValuePair[1].Substring(keyValuePair[1].Length - 2);

										if (measurement == "cm")
										{
											if (Int32.Parse(keyValuePair[1].Substring(0, keyValuePair[1].Length - 2)) >= 150 && Int32.Parse(keyValuePair[1].Substring(0, keyValuePair[1].Length - 2)) <= 193)
											{
												requirementFound = true;
											}
										}
										if (measurement == "in")
										{
											if (Int32.Parse(keyValuePair[1].Substring(0, keyValuePair[1].Length - 2)) >= 59 && Int32.Parse(keyValuePair[1].Substring(0, keyValuePair[1].Length - 2)) <= 76)
											{
												requirementFound = true;
											}
										}
									}

									break;

								case "hcl":
									if (keyValuePair[1][0] == '#' && keyValuePair[1].Length == 7)
									{
										requirementFound = true;
									}

									break;

								case "ecl":
									if (keyValuePair[1] == "amb" || keyValuePair[1] == "blu" || keyValuePair[1] == "brn" || keyValuePair[1] == "gry" || keyValuePair[1] == "grn" || keyValuePair[1] == "hzl" || keyValuePair[1] == "oth")
									{
										requirementFound = true;
									}

									break;

								case "pid":
									if (keyValuePair[1].Length == 9 && Int32.TryParse(keyValuePair[1], out _))
									{
										requirementFound = true;
									}
									break;

								default:
									break;
							}
						}
					}

					//This passport misses a requirement
					if (requirementFound == false)
					{
						valid = false; //And is therefore false
						break;
					}
				}

				//No requirement missing?
				if (valid)
				{
					validPassports++; //Got ourselves a good one then
				}
			}

			return validPassports;
		}
		static int Puzzle5Part1(string[] input)
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

		static int Puzzle5Part2(string[] input)
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

		static int Puzzle6Part1(string[] input)
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
		static int Puzzle6Part2(string[] input)
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
		static int Puzzle7Part1(string[] input)
		{
			Dictionary<string, List<string>> rules = new Dictionary<string, List<string>>();

			foreach (string line in input)
			{
				string[] parts = line.Split(new string[] { " contain" }, StringSplitOptions.None);
				parts[1] = parts[1].Substring(0, parts[1].Length - 1); //remove period at the end
				string[] values = parts[1].Split(',');

				string key = parts[0].Substring(0, parts[0].Length - 5);

				List<string> valuesLOL = new List<string>();

				foreach (string value in values)
				{
					if (value != " no other bags")
					{
						if (value[1] == '1')
						{
							valuesLOL.Add(value.Substring(3, value.Length - 7));
						}
						else
						{
							valuesLOL.Add(value.Substring(3, value.Length - 8));
						}
					}
				}

				rules.Add(key, valuesLOL);
			}

			HashSet<string> searchSet = new HashSet<string>();
			HashSet<string> completedSet = new HashSet<string>();

			foreach (KeyValuePair<string, List<String>> entry in rules)
			{
				if (entry.Value.Contains("shiny gold"))
				{
					searchSet.Add(entry.Key);
					completedSet.Add(entry.Key);
				}
			}

			while (searchSet.Any())
			{
				HashSet<string> tempList = new HashSet<string>();

				foreach (string bag in searchSet)
				{
					foreach (KeyValuePair<string, List<String>> entry in rules)
					{
						if (entry.Value.Contains(bag))
						{
							if (!completedSet.Contains(entry.Key))
							{
								tempList.Add(entry.Key);
							}
						}
					}

					completedSet.Add(bag);
				}

				searchSet = tempList;
			}

			return completedSet.Count;
		}
		static int Puzzle7Part2(string[] input)
		{
			Dictionary<string, List<BagInfo>> rules = new Dictionary<string, List<BagInfo>>();

			foreach (string line in input)
			{
				string[] parts = line.Split(new string[] { " contain" }, StringSplitOptions.None);
				parts[1] = parts[1].Substring(0, parts[1].Length - 1); //remove period at the end
				string[] values = parts[1].Split(',');

				string key = parts[0].Substring(0, parts[0].Length - 5);

				List<BagInfo> valuesLOL = new List<BagInfo>();

				foreach (string value in values)
				{
					if (value != " no other bags")
					{
						if (value[1] == '1')
						{
							valuesLOL.Add(new BagInfo(1, value.Substring(3, value.Length - 7)));
						}
						else
						{
							valuesLOL.Add(new BagInfo(int.Parse(value[1] + ""), value.Substring(3, value.Length - 8)));
						}
					}
				}

				rules.Add(key, valuesLOL);
			}

			int RecursionHell(int number, List<BagInfo> bags)
			{
				if (!bags.Any())
				{
					return number;
				}

				int output = 1;

				foreach (BagInfo bag in bags)
				{
					output += RecursionHell(bag.amount, rules[bag.color]);
				}

				output *= number;

				return output;
			}

			return RecursionHell(1, rules["shiny gold"]);
		}
		static int Puzzle8Part1(string[] input)
		{
			int accumulator = 0;
			int counter = 0;

			HashSet<int> executedInstructions = new HashSet<int>();

			while (true)
			{
				string[] instruction;

				if (!executedInstructions.Contains(counter))
				{
					executedInstructions.Add(counter);

					switch (input[counter].Substring(0, 3))
					{
						case "acc":
							instruction = input[counter].Split(' ');
							accumulator += Int32.Parse(instruction[1]);
							counter++;
							break;

						case "jmp":
							instruction = input[counter].Split(' ');
							counter += Int32.Parse(instruction[1]);
							break;

						case "nop":
							counter++;
							break;

						default:
							break;
					}
				}
				else
				{
					return accumulator;
				}
			}
		}

		static int Puzzle8Part2(string[] input)
		{
			Queue<SearchTuple> searchQueue = new Queue<SearchTuple>();
			searchQueue.Enqueue(new SearchTuple(0, 0, new bool[input.Length], false));

			while (searchQueue.Any()) //There are still paths to explore
			{
				SearchTuple current = searchQueue.Dequeue();
				string[] instruction;

				Console.WriteLine("while loop instance");

				if (!current.executedInstructions[current.counter]) //We're not in a loop
				{
					if (current.counter == input.Length - 1) //We've reached the end of the file and we're done
					{
						Console.WriteLine("WIN!");
						return current.accumulator;
					}

					current.executedInstructions[current.counter] = true;

					switch (input[current.counter].Substring(0, 3))
					{
						case "acc":
							Console.WriteLine("acc read");
							instruction = input[current.counter].Split(' ');
							searchQueue.Enqueue(new SearchTuple(current.accumulator + Int32.Parse(instruction[1]), current.counter + 1, (bool[])current.executedInstructions.Clone(), current.correction)); //acc

							break;

						case "jmp":
							Console.WriteLine("jmp read");
							instruction = input[current.counter].Split(' ');
							searchQueue.Enqueue(new SearchTuple(current.accumulator, current.counter + Int32.Parse(instruction[1]), (bool[])current.executedInstructions.Clone(), current.correction)); //jmp

							if (!current.correction) //There hasn't been a correction yet, so try turning this one into a nop
							{
								Console.WriteLine("corrected jmp to nop");
								searchQueue.Enqueue(new SearchTuple(current.accumulator, current.counter + 1, (bool[])current.executedInstructions.Clone(), true));
							}

							break;

						case "nop":
							Console.WriteLine("nop read");
							searchQueue.Enqueue(new SearchTuple(current.accumulator, current.counter + 1, (bool[])current.executedInstructions.Clone(), current.correction));

							if (!current.correction) //There hasn't been a correction yet, so try turning this one into a jump
							{
								Console.WriteLine("corrected nop to jmp");
								instruction = input[current.counter].Split(' ');
								searchQueue.Enqueue(new SearchTuple(current.accumulator, current.counter + Int32.Parse(instruction[1]), (bool[])current.executedInstructions.Clone(), true)); //jmp
							}

							break;

						default:
							Console.WriteLine("NO INSTRUCTION READ. SHOULDN'T HAPPEN!");
							break; //Should never be reached as all instructions are accounted for
					}
				}
				else //We're in a loop. Stop looking down this path.
				{
					Console.WriteLine("LOOP DETECTED!");
				}

				//x > 125 
			}

			Console.WriteLine("QUEUE EMPTY. SHOULDN'T HAPPEN!");
			return -1; //Only reached when queue is empty and a solution should always be reached before that happens 
		}
		static long Puzzle9Part1(string[] input)
		{
			long[] inputParsed = new long[input.Length - 1];

			for (int i = 0; i < input.Length - 1; i++)
			{
				inputParsed[i] = Convert.ToInt64(input[i]);
			}

			for(int i = 25; i < inputParsed.Length; i++)
			{
				bool found = false;

				for (int j = i - 25; j < i; j++)
				{
					for(int k = i - 24; k < i; k++)
					{
						if(j != k && inputParsed[j] + inputParsed[k] == inputParsed[i])
						{
							found = true;
							break;
						}
					}
				}

				if (!found)
				{
					return inputParsed[i];
				}
			}

			return 0;
		}
		static long Puzzle9Part2(string[] input)
		{
			long goal = Puzzle9Part1(input);

			long[] inputParsed = new long[input.Length - 1];

			for (int i = 0; i < input.Length - 1; i++)
			{
				inputParsed[i] = Convert.ToInt64(input[i]);
			}

			for (int i = 0; i < inputParsed.Length; i++)
			{
				long counter = inputParsed[i];
				int index = i + 1;

				while (counter < goal)
				{
					counter += inputParsed[index];

					if (counter == goal)
					{
						SortedSet<long> range = new SortedSet<long>();
						for(int j = i; j < index; j++)
						{
							range.Add(inputParsed[j]);
						}

						return range.First() + range.Last();
					}

					index++;
				}
			}

			return 0;
		}
		static int Puzzle10Part1(string[] input)
		{
			SortedSet<int> adapters = new SortedSet<int>();

			foreach(string line in input)
			{
				adapters.Add(Int32.Parse(line));
			}

			int oneJolts = 0;
			int threeJolts = 0;

			int counter = 0;

			foreach(int adapter in adapters)
			{
				int difference = adapter - counter;

				switch (difference) {
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
		static int Puzzle10Part2(string[] input)
		{
			return 0;
		}
	}
}

class BagInfo
{
	public int amount;
	public string color;

	public BagInfo(int amount, string color)
	{
		this.color = color;
		this.amount = amount;
	}

	public override string ToString()
	{
		return amount + " " + color + " bags";
	}
}

class SearchTuple
{
	public int accumulator; //Value accumulated in accumulator
	public int counter; //Which line of the instructions we're on
	public bool[] executedInstructions; //Keeps track of which lines of the instructions we've already visited
	public bool correction; //Whether or not a nop/jmp correction has already been made in this branch of the tree

	public SearchTuple(int accumulator, int counter, bool[] executedInstructions, bool correction)
	{
		this.accumulator = accumulator;
		this.counter = counter;
		this.executedInstructions = executedInstructions;
		this.correction = correction;
	}

	public override string ToString()
	{
		return "Accumulator: " + accumulator + " Counter:" + counter + " Correction: " + correction;
	}
}