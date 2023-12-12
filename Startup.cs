using Microsoft.Extensions.Hosting;

using Sudoku.Solvers.Abstractions;

namespace Sudoku;

public class Startup : IHostedService
{
    private readonly ISolver solver;

    public Startup(ISolver solver)
    {
        this.solver = solver;
    }

    public async Task StartAsync(CancellationToken cancellationToken)
    {
        var grid = InputParser.Parse(TestInput.SudokuDotComMedium);

        this.solver.SolveGrid(grid);
    }

    public Task StopAsync(CancellationToken cancellationToken)
    {
        throw new NotImplementedException();
    }
}
