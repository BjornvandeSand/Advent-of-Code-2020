using System;
using System.Collections.Generic;

namespace Advent_of_Code_2020
{
	public class Day04
	{

		public static int Part1(string[] input)
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

		public static int Part2(string[] input)
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
	}
}