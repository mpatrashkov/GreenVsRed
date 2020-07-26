using System;
using System.Collections.Generic;
using System.Text;

namespace GreenVsRed {
	interface ICell {
		CellColor Color { get; set; }
		ICell Next(List<ICell> cells);
	}
}
