using System;
using System.Collections.Generic;

namespace Advent_of_Code_2020
{
	public class Day14
	{
		public static ulong Part1(string[] input)
		{
			Dictionary<long, long> mem = new Dictionary<long, long>();

			string mask = "";

			foreach (string line in input)
			{
				string[] split = line.Split('=');

				if (split[0] == "mask ")
				{
					mask = split[1].Substring(1, 36);
				}
				else
				{
					long address = Int64.Parse(split[0].Substring(4, split[0].Length - 6));
					long value = Int64.Parse(split[1].Substring(1, split[1].Length - 1));

					string binaryValue = Convert.ToString(value, 2);
					binaryValue = binaryValue.PadLeft(36, '0');

					string output = "";

					for (int i = 0; i < 36; i++)
					{
						switch (mask[i])
						{
							case '0':
								output += '0';
								break;

							case '1':
								output += '1';
								break;

							case 'X':
								output += binaryValue[i];
								break;

							default:
								Console.WriteLine("This should never happen.");
								break;
						}
					}

					mem[address] = Convert.ToInt64(output, 2);
				}
			}

			ulong counter = 0;

			foreach (KeyValuePair<long, long> entry in mem)
			{
				counter += (ulong)entry.Value;
			}

			return counter;
		}

		public static ulong Part2(string[] input)
		{
			Dictionary<long, long> mem = new Dictionary<long, long>();

			string mask = "";

			foreach (string line in input)
			{
				string[] split = line.Split('=');

				if (split[0] == "mask ")
				{
					mask = split[1].Substring(1, 36);
				}
				else
				{
					long address = Int64.Parse(split[0].Substring(4, split[0].Length - 6));
					long value = Int64.Parse(split[1].Substring(1, split[1].Length - 1));

					string binaryAddress = Convert.ToString(address, 2);
					binaryAddress = binaryAddress.PadLeft(36, '0');

					Queue<string> binaryAddresses = new Queue<string>();
					binaryAddresses.Enqueue("");

					Queue<string> binaryAddressesSwap = new Queue<string>();

					for (int i = 0; i < 36; i++)
					{
						while (binaryAddresses.Count > 0)
						{
							string currentAddress = binaryAddresses.Dequeue();

							switch (mask[i])
							{
								case '0':
									binaryAddressesSwap.Enqueue(currentAddress + binaryAddress[i]);
									break;

								case '1':
									binaryAddressesSwap.Enqueue(currentAddress + '1');
									break;

								case 'X':
									binaryAddressesSwap.Enqueue(currentAddress + '0');
									binaryAddressesSwap.Enqueue(currentAddress + '1');
									break;

								default:
									Console.WriteLine("This should never happen.");
									break;
							}
						}

						while (binaryAddressesSwap.Count > 0)
						{
							binaryAddresses.Enqueue(binaryAddressesSwap.Dequeue());
						}
					}

					foreach (string x in binaryAddresses)
					{
						mem[Convert.ToInt64(x, 2)] = value;
					}
				}
			}

			ulong counter = 0;

			foreach (KeyValuePair<long, long> entry in mem)
			{
				counter += (ulong)entry.Value;
			}

			return counter;
		}
	}
}