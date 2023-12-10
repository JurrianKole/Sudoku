using Sudoku.Enums;

namespace Sudoku.Models;

public record Cell(CellValue Value, int Row, int Column)
{
    protected Cell(Cell oldItem)
    {
        this.Value = oldItem.Value;
        this.Row = oldItem.Row;
        this.Column = oldItem.Column;
    }
}
