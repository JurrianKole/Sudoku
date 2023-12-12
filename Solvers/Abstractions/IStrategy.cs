using Sudoku.Models;

namespace Sudoku.Solvers.Abstractions;

public interface IStrategy
{
    Cell Apply(Cell cell, Grid grid);
    
    bool IsApplicable(Cell cell, Grid grid);
}
