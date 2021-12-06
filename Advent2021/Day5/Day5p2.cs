using System;
using System.Collections.Generic;
using System.ComponentModel.Design;
using System.Text;
using System.Text.RegularExpressions;
using Microsoft.VisualBasic.FileIO;

namespace Advent2021.Day5
{
	public class Day5p2
	{
		public static void Run(List<string> data)
		{
			List<((int, int), (int, int))> verts = new List<((int, int), (int, int))>();
			List<((int, int), (int, int))> horiz = new List<((int, int), (int, int))>();
			List<((int, int), (int, int))> diagDowns = new List<((int, int), (int, int))>();
			List<((int, int), (int, int))> diagUps = new List<((int, int), (int, int))>();

			int xMax = 0;
			int yMax = 0;
			int[,] oceanFloor;

			Regex rx = new Regex(@"(\d+)\,(\d+) .* (\d+)\,(\d+)", RegexOptions.Compiled);

			foreach (string line in data)
			{
				Match match = rx.Match(line);
				(int, int) start = (Convert.ToInt32(match.Groups[1].Value), Convert.ToInt32(match.Groups[2].Value));
				(int, int) end = (Convert.ToInt32(match.Groups[3].Value), Convert.ToInt32(match.Groups[4].Value));

				//Console.WriteLine($"{line}   {(start)} , {(end)}");

				if (start.Item1 == end.Item1)
					verts.Add((start, end));
				
				else if (start.Item2 == end.Item2)
					horiz.Add((start, end));

				else if (start.Item1 > end.Item1 && start.Item2 > end.Item2)
					diagDowns.Add((end, start));

				else if (start.Item1 < end.Item1 && start.Item2 < end.Item2)
					diagDowns.Add((start, end));

				else if (start.Item1 > end.Item1 && start.Item2 < end.Item2)
					diagUps.Add((start, end));

				else if (start.Item1 < end.Item1 && start.Item2 > end.Item2)
					diagUps.Add((end, start));

				if (start.Item1 > xMax)
					xMax = start.Item1;

				if (end.Item1 > xMax)
					xMax = end.Item1;

				if (start.Item2 > yMax)
					yMax = start.Item2;

				if (end.Item2 > yMax)
					yMax = end.Item2;
			}

			oceanFloor = new int[yMax + 1, xMax + 1];

			foreach (var vent in horiz)
			{
				int west = Math.Min(vent.Item1.Item1, vent.Item2.Item1);
				int east = Math.Max(vent.Item1.Item1, vent.Item2.Item1);

				for (int x = west; x <= east; x++)
				{
					oceanFloor[vent.Item1.Item2, x] += 1;
				}
				//PrintOcean(oceanFloor);
			}

			foreach (var vent in verts)
			{
				int north = Math.Min(vent.Item1.Item2, vent.Item2.Item2);
				int south = Math.Max(vent.Item1.Item2, vent.Item2.Item2);

				for (int y = north; y <= south; y++)
				{
					oceanFloor[y, vent.Item1.Item1] += 1;
				}
				//PrintOcean(oceanFloor);
			}

			foreach (var vent in diagDowns)
			{
				for (int x = vent.Item1.Item1, y = vent.Item1.Item2;
					x <= vent.Item2.Item1 && y <= vent.Item2.Item2;
					x++, y++)
				{
					oceanFloor[y, x] += 1;
				}
			}

			foreach (var vent in diagUps)
			{
				for (int x = vent.Item1.Item1, y = vent.Item1.Item2;
					x >= vent.Item2.Item1 && y <= vent.Item2.Item2;
					x--, y++)
				{
					oceanFloor[y, x] += 1;
				}
			}

			int intersects = 0;

			foreach (int spot in oceanFloor)
			{
				if (spot > 1)
					intersects++;
			}

			PrintOcean(oceanFloor);
			Console.WriteLine($"The number of oceanfloor vent confluences is {intersects}");
		}

		private static void PrintOcean(int [,] oceanFloor)
		{
			for (int x = 0; x < oceanFloor.GetLength(0); x++)
			{
				string printline = "";

				for (int y = 0; y < oceanFloor.GetLength(1); y++)
				{
					printline += " " + oceanFloor[x, y];
				}
				Console.WriteLine(printline.Replace('0', '.'));
			}
			Console.WriteLine();
		}
	}

}
