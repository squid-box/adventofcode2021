namespace AdventOfCode2021;

using System;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;

using Spectre.Console;

public class Program
{
    public static void Main()
    {
        AnsiConsole.Render(new Rule("Advent of Code 2021"));

        var inputDownloader = new InputDownloader();

        var problems = Assembly.GetExecutingAssembly().GetTypes()
            .Where(type => type.IsSubclassOf(typeof(ProblemBase)))
            .Select(problemType => (ProblemBase)Activator.CreateInstance(problemType, args: inputDownloader))
            .OrderBy(x => x?.Day)
            .ToList();

        var selection = AnsiConsole.Prompt(
            new TextPrompt<int>("Select day to run [green][[1-25]][/] or [green]0[/] to run all")
                .Validate(number =>
                {
                    return number switch
                    {
                        < 0 => ValidationResult.Error("[red]Too low[/]"),
                        > 25 => ValidationResult.Error("[red]Too high[/]"),
                        _ => ValidationResult.Success(),
                    };
                })
            );

        if (selection != 0)
        {
            var problem = problems[selection - 1];

            AnsiConsole.Status()
                .Start($"Solving problem #[green]{problem.Day}[/]...", context =>
                {
                    context.Spinner(Spinner.Known.Christmas);
                    context.SpinnerStyle(Style.Parse("gold1"));
                    problem.CalculateSolution();
                });

            PrintProblemSolution(problem);
        }
        else
        {
            AnsiConsole.Status()
                .Start("Solving...", context =>
                {
                    context.Spinner(Spinner.Known.Christmas);
                    context.SpinnerStyle(Style.Parse("gold1"));

                    var solved = 0;

                    Parallel.ForEach(problems, problem =>
                    {
                        problem.CalculateSolution();
                        solved++;

                        context.Status($"Solved {solved}/{problems.Count} problems...");
                    });
                });

            // Print results here, or they're disordered...
            foreach (var problem in problems)
            {
                PrintProblemSolution(problem);
            }
        }
    }

    private static void PrintProblemSolution(ProblemBase problem)
    {
        AnsiConsole.MarkupLine(problem.Result.ToString());
        AnsiConsole.MarkupLine($"Day total: [blue]{problem.Result.FullTime}[/]");
        AnsiConsole.WriteLine();
    }
}