using System;
using System.Collections.Generic;
using System.Text;

namespace Advent2021.Day10
{
	public class Day10p2
	{
		private static string openings = "[({<";
		private static string closings = "])}>";

		private static Dictionary<char, int> scoring = new Dictionary<char, int>()
		{
			{'(', 1},
			{'[', 2},
			{'{', 3},
			{'<', 4}
		};

		public static void Run(List<string> data)
		{
			var scores = new List<long>();

			foreach (var line in data)
			{
				var stack = new Stack<char>(); 
				long score = 0;
				bool isCorrupt = false;
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

						if (closings.IndexOf(bracket) != openings.IndexOf(match))
						{
							Console.Write($"   Corrupted: Found {bracket} but expected match for {match}");
							isCorrupt = true;
							break;
						}
					}
				}

				if (!isCorrupt)
				{
					foreach (var bracket in stack)
					{
						score = (score * 5) + scoring[bracket];
					}
					scores.Add(score);
				}
				Console.WriteLine($"   Score = {score}");
			}

			scores.Sort();

			Console.WriteLine($"Your median completionist score is {scores[scores.Count / 2]}");
		}
	}
}
