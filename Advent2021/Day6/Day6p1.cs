using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;

namespace Advent2021.Day6
{
	public class Day6p1
	{
		public static void Run(List<string> data)
		{
			var fishList = data[0].Split(',').Select(x => Convert.ToInt32(x));
			int[] fishGroups = new int[9];

			foreach (var fish in fishList)
			{
				fishGroups[fish] += 1;
			}

			for (int i = 0; i < 80; i++)
			{
				int[] nextDayFish = new int[9];

				for (int j = 0; j < 8; j++)
				{
					nextDayFish[j] = fishGroups[j + 1];
				}

				nextDayFish[8] = fishGroups[0];
				nextDayFish[6] += fishGroups[0];

				string str1 = "";
				string str2 = "";

				for (int j = 0; j < fishGroups.Length; j++)
				{
					str1 += $" {fishGroups[j],3}";
					str2 += $" {nextDayFish[j],3}";
				}
				
				Console.WriteLine($"Day {i}:");
				Console.WriteLine(str1);
				Console.WriteLine(str2);

				fishGroups = nextDayFish;
			}

			int fishCount = fishGroups.Sum(x => x);

			Console.WriteLine($"The horde of lanternfish will grow to be {fishCount}-strong.");
		}
	}
}
