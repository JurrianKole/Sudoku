using Sudoku.Enums;
using Sudoku.Models;

namespace Sudoku.Extensions;

public static class SubGridExtensions
{
    public static bool IsValidSubGrid(this SubGrid subGrid)
    {
        var allValidCellValues = Enum.GetValues<CellValue>().Where(cellValue => cellValue != CellValue.None).ToArray();

        return allValidCellValues.All(subGrid.Cells.Select(cell => cell.Value).Contains);
    }

    public static HashSet<CellValue> GetAllValuesInSubGrid(this SubGrid subGrid)
    {
        return subGrid.Cells.Where(cell => cell.Value != CellValue.None).Select(cell => cell.Value).ToHashSet();
    }
}
