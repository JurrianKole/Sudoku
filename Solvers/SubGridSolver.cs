using Sudoku.Enums;
using Sudoku.Extensions;
using Sudoku.Models;
using Sudoku.Solvers.Abstractions;

namespace Sudoku.Solvers;

public class SubGridSolver : ISolver
{
    public Grid SolveGrid(Grid grid)
    {
        var allCellValues = Enum.GetValues<CellValue>().Where(cellValue => cellValue != CellValue.None).ToArray();

        while (!grid.IsSolved())
        {
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
                    Console.WriteLine("Only one value possible for cell with row {0} and column {1}", cellToSolve.Row, cellToSolve.Column);

                    var except = allCellValues.Except(preOccupiedCellValues).First();

                    Console.WriteLine("Cell with row {0} and column {1} needs to have value {2}", cellToSolve.Row, cellToSolve.Column, except);

                    var updatedCell = cellToSolve.Mutate(except);

                    grid = grid.Mutate(updatedCell);
                }
            }
        }
        
        return grid;
    }

    private HashSet<CellValue> GetPreOccupiedCellValues(Cell currentCell, Grid grid)
    {
        var valuesInCurrentRow = grid.GetAllFilledValuesInRow(currentCell.Row);
        var valuesInCurrentColumn = grid.GetAllFilledValuesInColumn(currentCell.Column);
        var valuesInCurrentSubGrid = grid.GetAllFilledValuesInSubGrid(currentCell.GetSubGridName());

        return new HashSet<CellValue>(new[] { valuesInCurrentRow, valuesInCurrentColumn, valuesInCurrentSubGrid }.SelectMany(c => c));
    }
}
