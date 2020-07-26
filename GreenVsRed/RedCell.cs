using System;
using System.Collections.Generic;
using System.Text;

namespace GreenVsRed {
	class RedCell : NeighbourChangeCell {
		public override CellColor Color { get; set; } = CellColor.Red;

		public override List<int> NeighboursToChange { get; set; } = new List<int> { 3, 6 };

		public override ICell Next(List<ICell> cells) {
			if (Change(cells)) {
				return new GreenCell();
			}

			return this;
		}
	}
}
