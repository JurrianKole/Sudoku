using Sudoku.Enums;
using Sudoku.Extensions;
using Sudoku.Models;

namespace Sudoku.Validators;

public static class GridValidator
{
    public static bool IsValid(Grid grid)
    {
        var allSubGridsAreValid = grid.SubGrids.All(subGrid => subGrid.IsValidSubGrid());

        var allValuesPerRowAreUnique = AllValuesPerRowAreUnique(grid);
        var allValuesPerColumnAreUnique = AllValuesPerColumnAreUnique(grid);

        return allSubGridsAreValid && allValuesPerRowAreUnique && allValuesPerColumnAreUnique;
    }

    private static bool AllValuesPerRowAreUnique(Grid grid)
    {
        var set = new HashSet<CellValue>();
        
        var rows = grid
            .SubGrids.SelectMany(subGrid => subGrid.Cells)
            .Where(cell => cell.Value != CellValue.None)
            .GroupBy(cell => cell.Row);

        foreach (var row in rows)
        {
            var rowIsUnique = row.Select(cell => cell.Value).All(cellValue => set.Add(cellValue));

            if (!rowIsUnique)
            {
                return false;
            }
            
            set.Clear();
        }

        return true;
    }

    private static bool AllValuesPerColumnAreUnique(Grid grid)
    {
        var set = new HashSet<CellValue>();
        
        var columns = grid
            .SubGrids.SelectMany(subGrid => subGrid.Cells)
            .Where(cell => cell.Value != CellValue.None)
            .GroupBy(cell => cell.Column);

        foreach (var column in columns)
        {
            var columnIsUnique = column.Select(cell => cell.Value).All(cellValue => set.Add(cellValue));

            if (!columnIsUnique)
            {
                return false;
            }
            
            set.Clear();
        }

        return true;
    }
}