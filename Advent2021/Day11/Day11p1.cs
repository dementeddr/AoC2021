using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Text;

namespace Advent2021.Day11
{
	public class Day11p1
	{
		public static void Run(List<string> data)
		{
			var octos = new int[data.Count,data[0].Length];
			int flashes = 0;

			for (int y = 0; y < data.Count; y++)
			{
				for (int x = 0; x < data[y].Length; x++)
				{
					octos[y, x] = Convert.ToInt32(""+data[y][x]);
				}
			}

			for (int i = 0; i < 100; i++)
			{
				var nines = new List<(int, int)>();

				for (int y = 0; y < octos.GetLength(0); y++)
				{
					for (int x = 0; x < octos.GetLength(1); x++)
					{
						octos[y, x] += 1;

						if (octos[y, x] > 9)
						{
							nines.Add((x, y));
						}
					}
				}

				while (nines.Count > 0)
				{
					var coord = nines[0];
					nines.RemoveAt(0);
					
					Flash(octos, nines, coord.Item1, coord.Item2);
					flashes++;
				}

				for (int y = 0; y < octos.GetLength(0); y++)
				{
					for (int x = 0; x < octos.GetLength(1); x++)
					{
						if (octos[y, x] > 9)
						{
							octos[y, x] = 0;
						}
					}
				}

				Console.WriteLine($"{i+1}: {flashes}");
			}

			Console.WriteLine($"You are charged with {flashes} counts of indecent exposure.");
		}

		private static void Flash(int[,] octos, List<(int, int)> nines, int x, int y)
		{
			var adjacents = new List<(int, int)>();
			int height = octos.GetLength(0)-1;
			int width = octos.GetLength(1)-1;

			if (x > 0) 
				adjacents.Add((x-1, y));

			if (x < width)
				adjacents.Add((x+1, y));

			if (y > 0)
				adjacents.Add((x, y-1));

			if (y < height)
				adjacents.Add((x, y+1));

			if (x > 0 && y > 0)
				adjacents.Add((x-1, y-1));

			if (x < width && y < height)
				adjacents.Add((x+1,y+1));

			if (x > 0 && y < height)
				adjacents.Add((x-1, y+1));

			if (x < width && y > 0)
				adjacents.Add((x+1, y-1));

			foreach (var coord in adjacents)
			{
				octos[coord.Item2, coord.Item1]+=1;

				if (octos[coord.Item2, coord.Item1] == 10)
				{
					nines.Add(coord);
				}
			}
		}
	}
}
