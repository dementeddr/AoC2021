using System;
using System.Collections.Generic;
using System.Text;

namespace Advent2021.Day9
{
	public class Day9p1
	{
		public static void Run(List<string> data)
		{
			int danger = 0;

			for (int y = 0; y < data.Count; y++)
			{
				for (int x = 0; x < data[y].Length; x++)
				{
					if (isLocalMin(data, x, y))
					{
						danger += data[y][x] - 47;
					}
				}
			}
			Console.WriteLine($"The Seafloor danger is at level {danger}");
		}

		private static bool isLocalMin(List<string> data, int x, int y)
		{
			var adjacents = new List<char>();
			int height = data.Count;
			int width = data[0].Length;

			if (x < width-1)
				adjacents.Add(data[y][x+1]);

			if (x > 0)
				adjacents.Add(data[y][x-1]);

			if (y < height-1)
				adjacents.Add(data[y+1][x]);

			if (y > 0)
				adjacents.Add(data[y-1][x]);

			foreach (char tile in adjacents)
			{
				if (tile <= data[y][x])
					return false;
			}

			return true;
		}
	}
}
