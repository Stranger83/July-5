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
			var strings = Console.ReadLine()
				.Split();
			while (true)
			{
				var line = Console.ReadLine().ToLower().Trim();
				if (line == "end")
				{
					break;
				}
				var commandParts = line.Split();
				var commandName = commandParts[0];
				ProcessCommand(strings, commandName, commandParts);
			}
			Console.WriteLine($"[{string.Join(", ", strings)}]");
		}

		private static void ProcessCommand(string[] strings, string cmd, string[] cmdParts)
		{
			if (cmd == "sort" || cmd == "reverse")
			{
				ProcessSortOrReverseCommand(strings, cmd, cmdParts);
			}
			if (cmd == "rollleft" || cmd == "rollright")
			{
				ProcessRollLeftOrRightCommand(strings, cmd, cmdParts);
			}
		}

		private static void ProcessRollLeftOrRightCommand(string[] strings, string cmd, string[] cmdParts)
		{
			var count = int.Parse(cmdParts[1]);
			if (count < 0)
			{
				Console.WriteLine("Invalid input parameters.");
				return;
			}
			if (cmd == "rollleft")
			{
				RollRight(strings, -count);
			}
			else if (cmd == "rollright")
			{
				RollRight(strings, count);
			}
		}

		private static void ProcessSortOrReverseCommand(string[] strings, string cmd, string[] cmdParts)
		{
			var start = int.Parse(cmdParts[2]);
			var count = int.Parse(cmdParts[4]);
			if (start < 0 || start >= strings.Length ||
				start + count - 1 >= strings.Length || count < 0)
			{
				Console.WriteLine("Invalid input parameters.");
				return;
			}
			if (cmd == "sort") {
				SortRange(strings, start, count);
			}
			else if (cmd == "reverse")
			{
				ReverseRange(strings, start, count);
			}
		}

		private static void ReverseRange(string[] strings, int start, int count)
		{
			var end = start + count - 1;
			while (start < end)
			{
				var old = strings[start];
				strings[start] = strings[end];
				strings[end] = old;
				start++;
				end--;
			}
		}

		private static void SortRange(string[] strings, int start, int count)
		{
			Array.Sort(strings, start, count);	
		}

		private static void RollRight(string[] strings, int count)
		{
			var result = new string[strings.Length];
			for (int oldIndex = 0; oldIndex < strings.Length; oldIndex++)
			{
				var newIndex = oldIndex + count;
				newIndex = newIndex % strings.Length;
				if (newIndex < 0)
				{
					newIndex += strings.Length;
				}
				result[newIndex] = strings[oldIndex];
			}
			for (int i = 0; i < strings.Length; i++)
			{
				strings[i] = result[i];
			};
		}
	}
}
