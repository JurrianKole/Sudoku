using Sudoku.Models;

namespace Sudoku.Solvers.Abstractions;

public interface ISolver
{
    Grid SolveGrid(Grid grid);
}
