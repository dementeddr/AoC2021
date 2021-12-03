using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Advent2021
{
	class AdventMain
	{
		static void Main(string[] args)
		{
			//string filename = $"day{args[1]}" + "-input.txt";
			string filename = "Day2/day2-input.txt";
			var data = new List<string>();

			foreach (string line in System.IO.File.ReadLines(filename))
			{
				data.Add(line);
			}

			Day2.Day2p2.Run(data);

		}
	}
}
