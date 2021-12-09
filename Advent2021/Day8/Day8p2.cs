using System;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Linq;
using System.Text;

namespace Advent2021.Day8
{
	public class Day8p2
	{
		public static void Run(List<string> data)
		{
			int sum = 0;
			//var displays = new List<(string, string)>();

			foreach (string line in data)
			{
				var splitInput = line.Split('|');
				var digits = splitInput[0].Split(' ').Select(charset => new SortedSet<char>(charset)).ToArray();
				var display = splitInput[1].Split(' ').Select(charset => new SortedSet<char>(charset)).ToArray();
				var foundDigits = new SortedSet<char>[10];
				var foundSegments = new Dictionary<char, char>();

				// Tier 0
				foundDigits[1] = digits.First(x => x.Count == 2);
				foundDigits[4] = digits.First(x => x.Count == 4);
				foundDigits[7] = digits.First(x => x.Count == 3);
				foundDigits[8] = digits.First(x => x.Count == 7);

				// Tier 1
				foundDigits[6] = digits.First(x => x.Count == 6 && x.Intersect(foundDigits[1]).Count() == 1);
				foundDigits[3] = digits.First(x => x.Count == 5 && foundDigits[1].IsProperSubsetOf(x));
				foundSegments['A'] = foundDigits[7].First(x => !foundDigits[1].Contains(x));

				// Tier 2
				foundDigits[0] = digits.First(x =>
					!foundDigits[4].IsProperSubsetOf(x) && foundDigits[1].IsProperSubsetOf(x) && x.Count == 6);
				foundDigits[5] = digits.First(x => x.IsProperSubsetOf(foundDigits[6]));
				foundSegments['F'] = foundDigits[1].Intersect(foundDigits[6]).First();
				foundSegments['G'] = digits.Where(x => x.Count >= 5)
					.Aggregate((prev, next) => new SortedSet<char>(prev.Intersect(next).ToList())).First(x=> x != foundSegments['A']);

				// Tier 3
				foundDigits[2] = digits.First(x => !x.Contains(foundSegments['F']));
				foundSegments['C'] = foundDigits[1].First(x => x != foundSegments['F']);
				foundSegments['D'] = foundDigits[8].First(x => !foundDigits[0].Contains(x));
				
				// Tier 4
				foundDigits[9] = digits.First(x =>
					x.Count == 6 && x.Contains(foundSegments['C']) && x.Contains(foundSegments['D']));
				foundSegments['B'] = foundDigits[5].First(x => !foundDigits[2].Contains(x) && x != foundSegments['G']);
				foundSegments['E'] = foundDigits[2].First(x => !foundDigits[3].Contains(x));

				string displayNum = "";

				foreach (var dDigit in display)
				{
					for (int i = 0; i < 10; i++)
					{
						if (foundDigits[i].SetEquals(dDigit))
						{
							displayNum += i;
							break;
						}
					}
				}

				Console.WriteLine($"{splitInput[1]} = {displayNum}");
				sum += Convert.ToInt32(displayNum);
			}

			Console.WriteLine($"The numbers Mason. The numbers add up to {sum}");
		}
	}
}
