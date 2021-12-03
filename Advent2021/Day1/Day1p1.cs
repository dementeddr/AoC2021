using System;
using System.Collections.Generic;
using System.Text;

namespace Advent2021.Day1
{
	public class Day1p1
	{
		public static void Run(List<string> data)
		{
			int prev = Int32.MaxValue;
			int slope = 0;

			foreach (string line in data)
			{
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
