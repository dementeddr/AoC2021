using System;
using System.Collections.Generic;
using System.Text;

namespace Advent2021.Test
{
	class Day0p0
	{
		static void Run(string[] args)
		{
			//var data = new SortedSet<int>();
			var data = new List<int>();

			foreach (string line in System.IO.File.ReadLines("test-input.txt"))
			{
				data.Add(Convert.ToInt32(line));
			}

			foreach (int val in data)
			{
				for (int i = data.Count - 1; i >= 0; i--)
				{
					int sum = val + data[i];
					if (sum < 2020)
						break;
					
					Console.WriteLine(val*data[i]);
						return;
					
				}
			}

		}
	}
}
