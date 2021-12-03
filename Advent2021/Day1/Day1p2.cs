using System;
using System.Collections.Generic;
using System.Text;

namespace Advent2021.Day1
{
	class Day1p2
	{
		static void otherMain(string[] args)
		{
			//var data = new List<int>();
			int win1 = Int32.MaxValue;
			int win2 = Int32.MaxValue;
			int prevWin = Int32.MaxValue;
			int iteration = 0;
			int slope = 0;

			foreach (string line in System.IO.File.ReadLines("Day1/day1-input.txt"))
			{
				//data.Add(Convert.ToInt32(line));
				int depth = Convert.ToInt32(line);
				int newWin = win1 + win2 + depth;

				if (newWin > prevWin && iteration > 2)
				{
					slope++;
				}

				Console.WriteLine($"{win1} {win2} {depth} = {newWin}. Compare to {prevWin}. Slope = {slope}");

				win1 = win2;
				win2 = depth;
				prevWin = newWin;
				iteration++;
			}

			Console.WriteLine($"{slope} measurements were deeper than the previous");
		}
	}
}
