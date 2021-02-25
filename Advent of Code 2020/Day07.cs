using System;
using System.Collections.Generic;
using System.Linq;

namespace Advent_of_Code_2020
{
	public class Day07
	{
		public static int Part1(string[] input)
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

		public static int Part2(string[] input)
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
					output += RecursionHell(bag.Amount, rules[bag.Color]);
				}

				output *= number;

				return output;
			}

			return RecursionHell(1, rules["shiny gold"]);
		}
	}

	class BagInfo
	{
		public int Amount { get; }
		public string Color { get; }

		public BagInfo(int amount, string color)
		{
			this.Amount = amount;
			this.Color = color;
		}

		public override string ToString()
		{
			return Amount + " " + Color + " bags";
		}
	}
}