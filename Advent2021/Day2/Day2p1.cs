using System;
using System.Collections.Generic;
using System.Text;

namespace Advent2021.Day2
{
	public class Day2p1
	{
		public static void Run(List<string> data)
		{
			int depth = 0;
			int distance = 0;

			foreach (string line in data)
			{
				var datum = line.Split(' ');
				int displacement = Convert.ToInt32(datum[1]);

				Console.WriteLine($"{line}  =  {datum[0]} {displacement}");

				switch (datum[0])
				{
					case "forward": distance += displacement;
						break;
					case "down": depth += displacement;
						break;
					case "up": depth -= displacement;
						break;
					default: Console.WriteLine($"{datum[0]} is not a valid direction.");
						break;
				}
			}

			Console.WriteLine($"The displacement vector area is {depth} * {distance} = {depth*distance}");
		}
	}
}
