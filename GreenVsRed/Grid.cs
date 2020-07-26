using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace GreenVsRed {
	class Grid {
		public int Width { get; set; }
		public int Height { get; set; }
		public int Generation { get; set; }

		public ICell[,] Cells { get; set; }
		private int currentLine = 0;

		public Grid(int width, int height) {
			Width = width;
			Height = height;

			Cells = new ICell[Width, Height];
		}

		public void FeedLine(List<int> numbers) {
			for(int i = 0; i < numbers.Count; i++) {
				if (numbers[i] == 1) {
					Cells[i, currentLine] = new GreenCell();
				}
				else {
					Cells[i, currentLine] = new RedCell();
				}
			}

			currentLine++;
		}

		public void NextGeneration() {
			ICell[,] newCells = new ICell[Width, Height];

			for(int i = 0; i < Width; i++) {
				for (int j = 0; j < Height; j++) {
					newCells[i, j] = Cells[i, j].Next(GetNeighbours(i, j));
				}
			}

			Cells = newCells;
		}

		private List<ICell> GetNeighbours(int cellX, int cellY) {
			var neighbours = new List<ICell>();

			int startX = Math.Clamp(cellX - 1, 0, Width - 1);
			int endX = Math.Clamp(cellX + 1, 0, Width - 1);

			int startY = Math.Clamp(cellY - 1, 0, Height - 1);
			int endY = Math.Clamp(cellY + 1, 0, Height - 1);

			for (int x = startX; x <= endX; x++) {
				for (int y = startY; y <= endY; y++) {
					if (x != cellX || y != cellY) {
						neighbours.Add(Cells[x, y]);
					}
				}
			}

			return neighbours;
		}
	}
}
