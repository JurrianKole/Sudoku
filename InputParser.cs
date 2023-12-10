using Sudoku.Enums;
using Sudoku.Extensions;
using Sudoku.Models;

namespace Sudoku;

public static class InputParser
{
    public static Grid Parse(string[] input)
    {
        var cells = input
            .Select(
                (line, row) => line
                    .Split(' ')
                    .Select(
                        (cell, column) => new Cell(
                            Enum.TryParse<CellValue>(cell, true, out var cellValue) ? cellValue : CellValue.None,
                            row,
                            column)))
            .ToArray();

        var subGrids = cells
            .SelectMany(c => c)
            .GroupBy(c => c.GetSubGridName())
            .Select(c => new SubGrid(c.Select(cell => cell).ToArray(), c.First().GetSubGridName()))
            .ToArray();

        return new Grid(subGrids);
    }
}
