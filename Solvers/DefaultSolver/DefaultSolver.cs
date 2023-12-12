using Sudoku.Enums;
using Sudoku.Extensions;
using Sudoku.Models;
using Sudoku.Solvers.Abstractions;

namespace Sudoku.Solvers.DefaultSolver;

public class DefaultSolver : ISolver
{
    private readonly IEnumerable<IStrategy> strategies;

    public DefaultSolver(IEnumerable<IStrategy> strategies)
    {
        this.strategies = strategies;
    }

    public Grid SolveGrid(Grid grid)
    {
        var iterations = 0;

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
                var strategy = this.strategies.FirstOrDefault(strategy => strategy.IsApplicable(cellToSolve, grid));

                if (strategy == default)
                {
                    continue;
                }

                var mutatedCell = strategy.Apply(cellToSolve, grid);

                grid = grid.Mutate(mutatedCell);
            }
            
            grid.PrettyPrint();
        }
        
        Console.WriteLine("Solving grid took {0} iterations", iterations);
        
        return grid;
    }

    
}
