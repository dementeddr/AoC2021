using System;
using System.Collections.Generic;
using System.Text;

namespace Advent2021.Day3
{
	public class Day3p2
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

			int[] bits = new int[rates.Length];
			string gammaStr = "";

			for (int i = 0; i < rates.Length; i++)
			{
				if (rates[i] >= 0)
					bits[i] = 1;
				else if (rates[i] < 0)
					bits[i] = 0;

				gammaStr += bits[i];
			}

			Console.WriteLine($"Binary: {gammaStr}");
			uint gamma = Convert.ToUInt32(gammaStr, 2);
			Console.WriteLine($"Gamma: {gamma}");
			uint epsilon = ~gamma & 0xFFF; // If I had to handle variable input lengths, this would need to change
			Console.WriteLine($"Epsilon: {epsilon}");
			Console.WriteLine($"Result: {gamma * epsilon}");
		}
	}
}
