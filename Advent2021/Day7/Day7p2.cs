using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Advent2021.Day7
{
	public class Day7p2
	{
		public static void Run(List<string> data)
		{
			var crabList = data[0].Split(',').Select(x => Convert.ToInt32(x));
			var formation = new int[2000];
			var averageOfCrabs = (int) Math.Round(crabList.Sum(x => x) / (double) crabList.Count());
			int fuel = Int32.MaxValue;

			foreach (int crab in crabList)
			{
				formation[crab] += 1;
			}

			for (int i=0; i<formation.Length; i++)
			{
				int calcFuel = CalculateFuel(formation, i);

				if (calcFuel < fuel)
				{
					Console.WriteLine($"Less fuel at {i}: {calcFuel} < {fuel}");
					fuel = calcFuel;
				}
			}

			Console.WriteLine($"Fuel required for crab positioning protocol: {fuel}");
		}

		private static int CalculateFuel(int[] formation, int position)
		{
			int fuel = 0;

			for (int i = 0; i < formation.Length; i++)
			{
				int n = Math.Abs(position - i);
				fuel += (((n+1)*n) / 2) * formation[i];
			}

			return fuel;
		}
	}
}
