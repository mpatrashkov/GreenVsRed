using System;
using System.Linq;

namespace GreenVsRed {
	class Program {
		static void Main(string[] args) {
			var size = Console.ReadLine().Split(", ").Select(int.Parse).ToList();
			int width = size[0];
			int height = size[1];

			var grid = new Grid(width, height);

			for(int i = 0; i < height; i++) {
				var line = Console.ReadLine().ToCharArray().Select(char.ToString).Select(int.Parse).ToList();
				grid.FeedLine(line);
			}

			var lastLine = Console.ReadLine().Split(", ").Select(int.Parse).ToList();
			int x = lastLine[0];
			int y = lastLine[1];
			int n = lastLine[2];

			int timesGreen = 0;
			for(int i = 0; i < n; i++) {
				if(grid.Cells[x, y].Color == CellColor.Green) {
					timesGreen++;
				}

				grid.NextGeneration();
			}

			if (grid.Cells[x, y].Color == CellColor.Green) {
				timesGreen++;
			}

			Console.WriteLine(timesGreen);
		}
	}
}
