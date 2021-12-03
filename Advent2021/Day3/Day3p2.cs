using System;
using System.Collections.Generic;
using System.Text;

namespace Advent2021.Day3
{
	public class Day3p2
	{
		public static void Run(List<string> data)
		{
			List<string> oxyList = new List<string>();
			List<string> co2List = new List<string>();

			foreach (string line in data)
			{
				oxyList.Add(line);
				co2List.Add(line);
			}

			for (int i = 0; i < oxyList[0].Length && oxyList.Count > 1; i++)
			{
				int bit = 0;

				foreach (string line in oxyList)
				{
					if (line[i] == '1')
						bit++;
					else if (line[i] == '0')
						bit--;
					else
						Console.WriteLine($"Bad input: {line}[{i}]");
				}

				for (int j = 0; j < oxyList.Count;)
				{
					string line = oxyList[j];

					if (line[i] == '0' && bit >= 0 || line[i] == '1' && bit < 0)
						oxyList.RemoveAt(j);
					else
						j++;

					if (oxyList.Count <= 1)
						break;
				}
			}

			for (int i = 0; i < co2List[0].Length && co2List.Count > 1; i++)
			{
				int bit = 0;

				foreach (string line in co2List)
				{
					if (line[i] == '1')
						bit++;
					else if (line[i] == '0')
						bit--;
					else
						Console.WriteLine($"Bad input: {line}[{i}]");
				}

				for (int j = 0; j < co2List.Count;)
				{
					string line = co2List[j];

					if (line[i] == '0' && bit < 0 || line[i] == '1' && bit >= 0)
						co2List.RemoveAt(j);
					else
						j++;

					if (co2List.Count <= 1)
						break;
				}
			}

			uint oxyVal = Convert.ToUInt32(oxyList[0], 2);
			uint co2Val = Convert.ToUInt32(co2List[0], 2);

			Console.WriteLine($"Oxygen Reading: {oxyList[0]} = {oxyVal}");
			Console.WriteLine($"CO2 Reading:  {co2List[0]} = {co2Val}");

			Console.WriteLine("The \"I sure hope this submarine doesn't asphyxiate us all\" number is " + (oxyVal * co2Val));
		}
	}
}
