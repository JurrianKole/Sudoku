using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

using Sudoku;
using Sudoku.Solvers.Abstractions;
using Sudoku.Solvers.DefaultSolver;
using Sudoku.Solvers.DefaultSolver.Strategies;

using var host = Host
    .CreateDefaultBuilder(args)
    .ConfigureServices(
        services =>
        {
            services.AddHostedService<Startup>();
            
            services.AddTransient<IStrategy, SubGridAndColumnAndRowMissingValueStrategy>();
            services.AddTransient<ISolver, DefaultSolver>();
        })
    .Build();

await host.StartAsync();
