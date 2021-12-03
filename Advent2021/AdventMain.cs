using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;

namespace Advent2021
{
	class AdventMain
	{
		static void Main(string[] args)
		{
			string filename = $"Day{args[0]}/day{args[0]}" + "-input.txt";
			string classname = $"Advent2021.Day{args[0]}.Day{args[0]}p{args[1]}";
			var data = new List<string>();

			foreach (string line in System.IO.File.ReadLines(filename))
			{
				data.Add(line);
			}

			//Console.WriteLine(filename);
			//Console.WriteLine(classname);
			//Console.WriteLine(typeof(Day1.Day1p1));

			Type dayType = Type.GetType(classname);
			MethodInfo runMethod = dayType.GetMethod("Run");
			runMethod.Invoke(dayType, ( new object[] {data} ));
		}
	}
}
