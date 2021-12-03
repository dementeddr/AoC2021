using System;
using System.Collections.Generic;
using System.Text;

namespace Advent2021.Day1
{
	class Day1
	{
		static void stillnotMain(string[] args)
		{
			//var data = new List<int>();
			int prev = Int32.MaxValue;
			int slope = 0;

			foreach (string line in System.IO.File.ReadLines("Day1/day1-input.txt"))
			{
				//data.Add(Convert.ToInt32(line));
				int depth = Convert.ToInt32(line);

				if (depth > prev)
				{
					slope++;
				}

				prev = depth;
			}

			Console.WriteLine($"{slope} measurements were deeper than the previous");
		}
	}
}
