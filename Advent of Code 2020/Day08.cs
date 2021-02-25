using System;
using System.Collections.Generic;
using System.Linq;

namespace Advent_of_Code_2020
{
	public class Day08
	{
		public static int Part1(string[] input)
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

		public static int Part2(string[] input)
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
}