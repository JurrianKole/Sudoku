using Sudoku.Enums;
using Sudoku.Extensions;
using Sudoku.Models;
using Sudoku.Solvers.Abstractions;

namespace Sudoku.Solvers;

public class BruteForceSolver : ISolver
{
    public Grid SolveGrid(Grid grid)
    {
        var iterations = 0;

        var mutableGrid = grid with { };
        
        while (!mutableGrid.IsSolved())
        {
            iterations++;
            mutableGrid = grid with { };
            
            mutableGrid = YoloAllRows(mutableGrid);
        }
        
        Console.WriteLine("Solving grid took {0} iterations", iterations);
        
        return mutableGrid;
    }

    private static Grid YoloAllRows(Grid grid)
    {
        var validCellValues = Enum.GetValues<CellValue>().Where(cellValue => cellValue != CellValue.None).ToArray();
        
        var rows = grid.SubGrids.SelectMany(cell => cell.Cells).GroupBy(cell => cell.Row);

        foreach (var row in rows)
        {
            var usedValuesInRow = row.Where(cell => cell.Value != CellValue.None).Select(cell => cell.Value);
            var unusedValuesInRow = validCellValues.Except(usedValuesInRow).ToList();

            foreach (var cell in row.Where(cell => cell.Value == CellValue.None))
            {
                var randomNumber = Random.Shared.Next(0, unusedValuesInRow.Count);

                var randomCellValue = unusedValuesInRow[randomNumber];

                var mutatedCell = cell.Mutate(randomCellValue);

                grid = grid.Mutate(mutatedCell);

                unusedValuesInRow.Remove(randomCellValue);
            }
        }

        return grid;
    }
}