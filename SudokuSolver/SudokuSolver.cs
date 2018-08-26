using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using SudokuSolver.Entities;
using SudokuSolver.Interfaces;

namespace SudokuSolver
{
    public class SudokuSolver
    {
        private List<ISudokuSolvingStrategy> Strategies { get; }

        public SudokuSolver()
        {
            Strategies = new List<ISudokuSolvingStrategy>();
        }

        public SudokuSolver(params ISudokuSolvingStrategy[] strategies)
        {
            Strategies = strategies.ToList();
        }

        public void AddStrategy(ISudokuSolvingStrategy solvingStrategy)
        {
            Strategies.Add(solvingStrategy);
        }

        public Map Solve(Map map)
        {
            if (!Strategies.Any())
            {
                Console.WriteLine("No solving strategy added");
                return map;
            }

            var stopwatch = new Stopwatch();
            foreach (var strategy in Strategies)
            {
                stopwatch.Restart();
                Console.Write($"Applying {strategy.Name.ToLower()}...");
                map = strategy.Solve(map);
                stopwatch.Stop();
                Console.WriteLine($" ({stopwatch.ElapsedMilliseconds} ms)");
                if (map.IsSolved)
                    return map;
            }

            return map;
        }
    }
}