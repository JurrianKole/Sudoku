using Sudoku.Enums;
using Sudoku.Extensions;
using Sudoku.Models;
using Sudoku.Solvers.Abstractions;

namespace Sudoku.Solvers;

public class DefaultSolver : ISolver
{
    public Grid SolveGrid(Grid grid)
    {
        var iterations = 0;
        var allCellValues = Enum.GetValues<CellValue>().Where(cellValue => cellValue != CellValue.None).ToArray();

        while (!grid.IsSolved())
        {
            iterations++;
            var cellsToSolve = grid
                .SubGrids
                .Select(subGrid => subGrid.Cells.Where(cell => cell.Value == CellValue.None))
                .SelectMany(cell => cell)
                .ToArray();

            foreach (var cellToSolve in cellsToSolve)
            {
                var preOccupiedCellValues = GetPreOccupiedCellValues(cellToSolve, grid);

                if (preOccupiedCellValues.Count == 8)
                {
                    var except = allCellValues.Except(preOccupiedCellValues).First();
                    
                    var updatedCell = cellToSolve.Mutate(except);

                    grid = grid.Mutate(updatedCell);
                }
            }
        }
        
        Console.WriteLine("Solving grid took {0} iterations", iterations);
        
        return grid;
    }

    private static HashSet<CellValue> GetPreOccupiedCellValues(Cell currentCell, Grid grid)
    {
        var valuesInCurrentRow = grid.GetAllFilledValuesInRow(currentCell.Row);
        var valuesInCurrentColumn = grid.GetAllFilledValuesInColumn(currentCell.Column);
        var valuesInCurrentSubGrid = grid.GetAllFilledValuesInSubGrid(currentCell.GetSubGridName());

        return new HashSet<CellValue>(new[] { valuesInCurrentRow, valuesInCurrentColumn, valuesInCurrentSubGrid }.SelectMany(c => c));
    }
}
