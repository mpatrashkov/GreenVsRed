using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace GreenVsRed {
	class GreenCell : NeighbourChangeCell {
		public override CellColor Color { get; set; } = CellColor.Green;

		public override List<int> NeighboursToChange { get; set; } = new List<int> { 0, 1, 4, 5, 7, 8 };

		public override ICell Next(List<ICell> cells) {
			if(Change(cells)) {
				return new RedCell();
			}

			return this;
		}
	}
}
