using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CommandInterpreter
{
	class Program
	{	
		static void Main(string[] args)
		{
			var strings = Console.ReadLine().Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries).ToList();
			while (true)
			{
				var line = Console.ReadLine().ToLower();
				if (line == "end")
				{
					break;
				}
				var tokens = line.Split(' ');
				var command = tokens[0];
				var isValidInput = IsItValidInput(tokens, strings);

				if (!isValidInput)
				{
					Console.WriteLine("Invalid input parameters.");
					continue;
				}
				switch (command)
				{
					case "reverse":
						Reverse(strings, tokens);
						break;
					case "sort":
						Sort(strings, tokens);
						break;
					case "rollleft":
						RollLeft(strings, tokens);
						break;
					case "rollright":
						RollRight(strings, tokens);
						break;
				}

			}
			Console.WriteLine($"[{string.Join(", ", strings)}]");
		}

		private static void RollRight(List<string> strings, string[] tokens)
		{
			var count = int.Parse(tokens[1]);
			for (int i = 0; i < count % strings.Count; i++)
			{
				strings.Insert(0, strings[strings.Count - 1]);
				strings.RemoveAt(strings.Count - 1);
			}
		}

		private static void RollLeft(List<string> strings, string[] tokens)
		{
			var count = int.Parse(tokens[1]);
			for (int i = 0; i < count % strings.Count; i++)
			{
				strings.Add(strings[0]);
				strings.RemoveAt(0);
			}
		}

		private static void Sort(List<string> strings, string[] tokens)
		{
			var start = int.Parse(tokens[2]);
			var count = int.Parse(tokens[4]);
			strings.Sort(start, count, StringComparer.Ordinal);
		}

		private static void Reverse(List<string> strings, string[] tokens)
		{
			var start = int.Parse(tokens[2]);
			var count = int.Parse(tokens[4]);
			List<string> listToReverse = strings.GetRange(start, count);
			listToReverse.Reverse();
			strings.RemoveRange(start, count);
			strings.InsertRange(start, listToReverse);
		}

		private static bool IsItValidInput(string[] tokens, List<string> strings)
		{
			var isValid = true;
			var start = 0;
			var count = 0;
			if (tokens[0] == "reverse" || tokens[0] == "sort")
			{
				start = int.Parse(tokens[2]);
				count = int.Parse(tokens[4]);
				long end = start + count - 1;
				if (start < 0 || start >= strings.Count || count < 0 || end >= strings.Count)
				{
					isValid = false;
				}
			}
			else
			{
				count = int.Parse(tokens[1]);
				if (count < 0)
				{
					isValid = false;
				}
			}

			return isValid;
		}
		
	}
}
