using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace GreenVsRed {
	abstract class NeighbourChangeCell : ICell {
		public virtual CellColor Color { get; set; }

		public virtual List<int> NeighboursToChange { get; set; }

		public bool Change(List<ICell> cells) {
			var greenCells = cells.Count(cell => cell.Color == CellColor.Green);

			if (NeighboursToChange.Contains(greenCells)) {
				return true;
			}

			return false;
		}

		public virtual ICell Next(List<ICell> cells) {
			return this;	
		}
	}
}
