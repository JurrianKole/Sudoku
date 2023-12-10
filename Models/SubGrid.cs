using Sudoku.Enums;

namespace Sudoku.Models;

public record SubGrid(Cell[] Cells, SubGridName SubGridName)
{
    protected SubGrid(SubGrid oldItem)
    {
        this.Cells = oldItem.Cells;
        this.SubGridName = oldItem.SubGridName;
    }
}
