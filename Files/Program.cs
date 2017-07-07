using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Files
{
	class File
	{
		public string Root { get; set; }
		public string Name { get; set; }
		public long Size { get; set; }
		public string Extension { get; set; }
	}
	class Program
	{
		static void Main(string[] args)
		{
			var n = int.Parse(Console.ReadLine());
			var allFiles = new List<File>();
			for (int i = 0; i < n; i++)
			{
				var inputLine = Console.ReadLine();
				var leftmostSlash = inputLine.IndexOf(@"\");
				string root = "";
				if (leftmostSlash >= 0)
				{
					root = inputLine.Substring(0, leftmostSlash);
				}
				var rightmostSemicolon = inputLine.LastIndexOf(';');
				long size = 0;
				if (rightmostSemicolon >= 0)
				{
					size = long.Parse(inputLine.Substring(rightmostSemicolon + 1));
				}
				
				var fullPathAndFileName = inputLine.Substring(0, rightmostSemicolon);
				
				var lastDot = fullPathAndFileName.LastIndexOf('.');
				string ext = "";
				if (lastDot >= 0)
				{
					ext = fullPathAndFileName.Substring(lastDot + 1);
				}
				var rightmostSlash = fullPathAndFileName.LastIndexOf('\\');
				var fileName = fullPathAndFileName.Substring(rightmostSlash + 1);
				var match = allFiles.FirstOrDefault(f => f.Name == fileName && f.Root == root);
				if (match != null)
				{
					match.Size = size;
				}
				else
				{
					allFiles.Add(new File { Name = fileName, Extension = ext, Root = root, Size = size });
				}
			}
			var command = Regex.Split(Console.ReadLine(), @"\s+in\s+");
			var extSearch = command[0];
			var rootSearch = command[1];

			var result = allFiles
				.Where(f => f.Extension == extSearch)
				.Where(f => f.Root == rootSearch)
				.OrderByDescending(f => f.Size)
				.ThenBy(f => f.Name);

			if (result.Any())
			{
				foreach (var file in result)
				{
					Console.WriteLine($"{file.Name} - {file.Size} KB");
				}
			}
			else
			{
				Console.WriteLine("No");
			}
		}
	}
}
