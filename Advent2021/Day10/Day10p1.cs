using System;
using System.Collections.Generic;
using System.Text;

namespace Advent2021.Day10
{
	public class Day10p1
	{
		private static string openings = "[({<";
		private static string closings = "])}>";

		private static Dictionary<char, int> scoring = new Dictionary<char, int>()
		{
			{')', 3},
			{']', 57},
			{'}', 1197},
			{'>', 25137}
		};

		public static void Run(List<string> data)
		{
			int score = 0;

			foreach (var line in data)
			{
				var stack = new Stack<char>();
				Console.Write(line);

				foreach (var bracket in line)
				{
					if (openings.Contains(bracket))
					{
						stack.Push(bracket);
						continue;
					}

					if (closings.Contains(bracket))
					{
						var match = stack.Pop();
						var io = openings.IndexOf(match);
						var ic = closings.IndexOf(bracket);

						if (closings.IndexOf(bracket) != openings.IndexOf(match))
						{
							Console.Write($"  Found {bracket} but expected match for {match}");
							score += scoring[bracket];
							break;
						}
					}
				}
				Console.WriteLine($"   Score = {score}");
			}

			Console.WriteLine($"Your nitpicker score is {score}");
		}
	}
}
