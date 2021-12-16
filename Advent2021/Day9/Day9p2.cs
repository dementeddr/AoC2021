using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;

namespace Advent2021.Day9
{
	public class Day9p2
	{
		public static void Run(List<string> data)
		{
			var seafloor = new int[data.Count, data[0].Length];
			var drainage = new int[data.Count, data[0].Length];
			var basins = new List<(int,int)>();

			for (int y = 0; y < data.Count; y++)
			{
				for (int x = 0; x < data[y].Length; x++)
				{
					seafloor[y,x] = Convert.ToInt32("" + data[y][x]);
				}
			}

			for (int y = 0; y < data.Count; y++)
			{
				for (int x = 0; x < data[y].Length; x++)
				{
					if (isLocalMin(seafloor, x, y))
					{
						basins.Add((x,y));
						drainage[y,x] = basins.Count;
					}
				}
			}

			foreach (var basin in basins)
			{
				FloodFill(seafloor, drainage, basin.Item1, basin.Item2, drainage[basin.Item2, basin.Item1]);
			}

			var basinAreas = new int[basins.Count+1];

			for (int y = 0; y < drainage.GetLength(0); y++)
			{
				string printstr = "";
				for (int x = 0; x < drainage.GetLength(1); x++)
				{
					printstr += drainage[y, x];
				}
				Console.WriteLine(printstr);
			}

			foreach (var tile in drainage)
			{
				basinAreas[tile]++;
			}

			basinAreas[0] = -1;

			var sortedBasins = basinAreas.ToList();
			sortedBasins.Sort();
			sortedBasins.Reverse();

			int output = sortedBasins[0] * sortedBasins[1] * sortedBasins[2];

			Console.WriteLine($"The basin multiplicity value is {output}");
		}

		private static void FloodFill(int[,] seafloor, int[,] drainage, int x, int y, int basin)
		{
			var adjacents = GetAdjacents(drainage, x, y);

			foreach (var tile in adjacents)
			{
				if (seafloor[tile.Item3, tile.Item2] != 9 && drainage[tile.Item3, tile.Item2] == 0)
				{
					drainage[tile.Item3, tile.Item2] = basin;
					FloodFill(seafloor, drainage, tile.Item2, tile.Item3, basin);
				}
			}
		}

		private static bool isLocalMin(int[,] map, int x, int y)
		{
			var adjacents = GetAdjacents(map, x, y);

			foreach (var tile in adjacents)
			{
				if (tile.Item1 <= map[y,x])
					return false;
			}

			return true;
		}

		private static List<(int, int, int)> GetAdjacents(int[,] map, int x, int y)
		{
			
			var adjacents = new List<(int, int, int)>();
			int height = map.GetLength(0);
			int width = map.GetLength(1);

			if (x < width-1)
				adjacents.Add((map[y,x+1], x+1, y));

			if (x > 0)
				adjacents.Add((map[y,x-1], x-1, y));

			if (y < height-1)
				adjacents.Add((map[y+1,x], x, y+1));

			if (y > 0)
				adjacents.Add((map[y-1,x], x, y-1));

			return adjacents;
		}
	}
}
