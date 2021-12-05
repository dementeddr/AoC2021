using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using Microsoft.VisualBasic.CompilerServices;

namespace Advent2021.Day4
{
	public class Day4p2
	{
		public static void Run(List<string> data)
		{
			List<BingoBoard> boards = new List<BingoBoard>();
			List<int> calls = data[0].Split(',').Select(num => Convert.ToInt32(num)).ToList();
			int score = 0;

			for (int i = 1; i < data.Count; i+=6)
			{
				boards.Add(new BingoBoard(data.GetRange(i+1, 5)));
			}

			foreach (int call in calls)
			{
				for (int i = 0; i<boards.Count && boards.Count > 1; )
				{
					int result = boards[i].CheckBoard(call);

					if (result > 0)
					{
						score = result;
						boards.RemoveAt(i);
					}
					else
						i++;
				}

				if (boards.Count <= 1)
					break;
			}

			Console.WriteLine($"And the losing board is.... {score}!");
		}
	}
}
