using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Advent2021.Day8
{
	public class Day8p1
	{
		public static void Run(List<string> data)
		{
			var digits = new int[10];

			foreach (string line in data)
			{
				// You can take the programmer out of python, but you can't take the python out of the programmer.
				var display = line.Split('|')[1].Split(' ');

				foreach (var segments in display)
				{
					switch (segments.Length)
					{
						case 2: digits[1]++;
							break;
						case 3: digits[7]++;
							break;
						case 4: digits[4]++;
							break;
						case 7: digits[8]++;
							break;
						default: continue;
					}
				}
			}

			int count1478 = digits.Sum(x => x);

			Console.WriteLine($"The number of 1, 4, 7, and 9 digits displayed on this broken-ass UI are {count1478}");
		}
	}
}
