using System.Text;

using Sudoku.Enums;
using Sudoku.Models;
using Sudoku.Validators;

namespace Sudoku.Extensions;

public static class GridExtensions
{
    public static bool IsSolved(this Grid grid)
    {
        return GridValidator.IsValid(grid);
    }

    public static Grid Mutate(this Grid grid, Cell mutatedCellValue)
    {
        var subGrids = grid.SubGrids;
        var subGridIndex = Array.FindIndex(subGrids, subGrid => subGrid.SubGridName == mutatedCellValue.GetSubGridName());

        var subGridToMutate = subGrids[subGridIndex];

        var cells = subGridToMutate.Cells;
        var cellIndex = Array.FindIndex(cells, cell => cell.Column == mutatedCellValue.Column && cell.Row == mutatedCellValue.Row);

        cells[cellIndex] = mutatedCellValue;

        var mutatedSubGrid = new SubGrid(cells, mutatedCellValue.GetSubGridName());

        subGrids[subGridIndex] = mutatedSubGrid;

        return new Grid(subGrids);
    }

    public static HashSet<CellValue> GetAllFilledValuesInRow(this Grid grid, int row)
    {
        return grid
            .SubGrids
            .SelectMany(subGrid => subGrid.Cells)
            .Where(cell => cell.Row == row && cell.Value != CellValue.None)
            .Select(cell => cell.Value)
            .ToHashSet();
    }
    
    public static HashSet<CellValue> GetAllFilledValuesInColumn(this Grid grid, int column)
    {
        return grid
            .SubGrids
            .SelectMany(subGrid => subGrid.Cells)
            .Where(cell => cell.Column == column && cell.Value != CellValue.None)
            .Select(cell => cell.Value)
            .ToHashSet();
    }

    public static HashSet<CellValue> GetAllFilledValuesInSubGrid(this Grid grid, SubGridName subGridName)
    {
        return grid
            .SubGrids
            .First(subGrid => subGrid.SubGridName == subGridName)
            .Cells
            .Where(cell => cell.Value != CellValue.None)
            .Select(cell => cell.Value)
            .ToHashSet();
    }

    public static string PrettyPrint(this Grid grid)
    {
        var stringBuilder = new StringBuilder();

        var cells = grid
            .SubGrids
            .SelectMany(cell => cell.Cells)
            .OrderBy(cell => cell.Row)
            .ThenBy(cell => cell.Row)
            .ToArray();

        foreach (var cell in cells)
        {
            stringBuilder.Append($"{(int)cell.Value}");

            if (cell.Column != 8)
            {
                stringBuilder.Append(" | ");
            }
            
            if (cell.Column == 8)
            {
                stringBuilder.Append('\n');

                if (cell.Row != 8)
                {
                    var lineSeparator = new string(Enumerable.Repeat("-   ", 9).SelectMany(c => c).ToArray());
                    stringBuilder.Append(lineSeparator + "\n");
                }
            }
        }

        return stringBuilder.ToString();
    }
}
