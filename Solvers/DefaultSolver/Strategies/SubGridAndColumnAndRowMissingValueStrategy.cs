using Sudoku.Enums;
using Sudoku.Extensions;
using Sudoku.Models;
using Sudoku.Solvers.Abstractions;

namespace Sudoku.Solvers.DefaultSolver.Strategies;

public class SubGridAndColumnAndRowMissingValueStrategy : IStrategy
{
    public Cell Apply(Cell cell, Grid grid)
    {
        var validCellValues = Enum
            .GetValues<CellValue>()
            .Where(cellValue => cellValue != CellValue.None)
            .ToArray();

        var remainingCellValue = validCellValues.Except(GetAllValuesInSubGridColumnAndRow(cell, grid)).First();
        
        return cell.Mutate(remainingCellValue);
    }

    public bool IsApplicable(Cell cell, Grid grid)
    {
        return GetAllValuesInSubGridColumnAndRow(cell, grid).Count == 8;
    }
    
    private static HashSet<CellValue> GetAllValuesInSubGridColumnAndRow(Cell currentCell, Grid grid)
    {
        var distinctValuesInSubGrid = grid.SubGrids
            .First(subGrid => subGrid.SubGridName == currentCell.GetSubGridName())
            .GetAllValuesInSubGrid();

        var distinctValuesInRow = grid.GetAllFilledValuesInRow(currentCell.Row);
        var distinctValuesInColumn = grid.GetAllFilledValuesInColumn(currentCell.Column);

        return new HashSet<CellValue>(
            new[]
            {
                distinctValuesInSubGrid,
                distinctValuesInRow,
                distinctValuesInColumn
            }.SelectMany(cell => cell));
    }
}
