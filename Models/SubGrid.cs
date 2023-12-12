using Sudoku.Enums;

namespace Sudoku.Models;

public record SubGrid(Cell[] Cells, SubGridName SubGridName);
