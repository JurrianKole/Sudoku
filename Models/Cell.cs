using Sudoku.Enums;

namespace Sudoku.Models;

public record Cell(CellValue Value, int Row, int Column);
