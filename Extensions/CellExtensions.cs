using Sudoku.Enums;
using Sudoku.Models;

namespace Sudoku.Extensions;

public static class CellExtensions
{
    public static SubGridName GetSubGridName(this Cell cell)
    {
        return cell switch
        {
            { Row: <= 2, Column: <= 2 } => SubGridName.TopLeft,
            { Row: <= 2, Column: > 2 and <= 5 } => SubGridName.Top,
            { Row: <= 2, Column: > 5 and <= 8 } => SubGridName.TopRight,
            { Row: > 2 and <= 5, Column: <= 2 } => SubGridName.Left,
            { Row: > 2 and <= 5, Column: > 2 and <= 5 } => SubGridName.Center,
            { Row: > 2 and <= 5, Column: > 5 and <= 8 } => SubGridName.Right,
            { Row: > 5 and <= 8, Column: <= 2 } => SubGridName.BottomLeft,
            { Row: > 5 and <= 8, Column: > 2 and <= 5 } => SubGridName.Bottom,
            { Row: > 5 and <= 8, Column: > 5 and <= 8 } => SubGridName.BottomRight,
            _ => throw new ArgumentOutOfRangeException(nameof(cell), cell, null)
        };
    }

    public static Cell Mutate(this Cell cell, CellValue cellValue)
    {
        return cell with { Value = cellValue };
    }
}
