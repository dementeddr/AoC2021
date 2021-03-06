using System;
using System.Collections.Generic;
using System.Text;

namespace Advent2021.Day3
{
	public class Day3p1
	{
		public static void Run(List<string> data)
		{
			int[] rates = new int[data[0].Length];

			foreach (string line in data)
			{
				for (int i = 0; i < rates.Length; i++)
				{
					if (line[i] == '1')
						rates[i]++;
					else if (line[i] == '0')
						rates[i]--;
					else
						Console.WriteLine($"Bad input: {line} , {rates[i]}");	
				}
			}

			string gammaStr = "";

			foreach (int common in rates)
			{
				int bit = 0;
				if (common >= 0)
					bit = 1;

				gammaStr += bit;
			}

			Console.WriteLine($"Binary: {gammaStr}");
			uint gamma = Convert.ToUInt32(gammaStr, 2);
			Console.WriteLine($"Gamma: {gamma}");
			uint epsilon = ~gamma & 0xFFF;
			Console.WriteLine($"Epsilon: {epsilon}");
			Console.WriteLine($"Result: {gamma * epsilon}");
		}
	}
}
