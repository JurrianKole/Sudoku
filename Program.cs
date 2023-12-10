using Sudoku;
using Sudoku.Extensions;
using Sudoku.Solvers;

var input = TestInput.EasyPeasyWikipediaExample;

var parsedInput = InputParser.Parse(input);

var solver = new DefaultSolver();

var solution = solver.SolveGrid(parsedInput);

solution.PrettyPrint();
