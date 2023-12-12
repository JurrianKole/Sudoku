using Spectre.Console;

using Sudoku.Enums;
using Sudoku.Models;
using Sudoku.Validators;

using Grid = Sudoku.Models.Grid;

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

    public static int GetCellValueCount(this Grid grid, CellValue cellValue)
    {
        return grid
            .SubGrids
            .SelectMany(subGrid => subGrid.Cells)
            .Count(cell => cell.Value == cellValue);
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
    
    public static void PrettyPrint(this Grid grid)
    {
        var table = new Table();

        table.HideHeaders();
        table.Border(TableBorder.Ascii);

        table.AddColumns(Enumerable.Range(1, 9).Select(i => i.ToString()).ToArray());

        var rows = grid.SubGrids.SelectMany(subGrid => subGrid.Cells).GroupBy(cell => cell.Row);

        foreach (var row in rows)
        {
            var stringValues = row.Select(cell => (int)cell.Value).Select(cellValue => cellValue == 0 ? string.Empty : cellValue.ToString()).ToArray();

            table.AddRow(stringValues);
        }

        AnsiConsole.Write(table);
    }
}
