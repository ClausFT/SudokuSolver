using System;
using System.Collections.Generic;
using System.Diagnostics;
using SudokuSolver.Strategies;
using SudokuSolver.Entities;
using SudokuSolver.Factories;
using SudokuSolver.Helpers;
using SudokuSolver.Interfaces;

namespace SudokuSolver
{
    // http://pi.math.cornell.edu/~mec/Summer2009/meerkamp/Site/Solving_any_Sudoku_I.html
    // http://pi.math.cornell.edu/~mec/Summer2009/meerkamp/Site/Solving_any_Sudoku_II.html

    class Program
    {
        private const bool ManualInput = false;

        static void Main(string[] args)
        {
            var map = ManualInput ? new InputHelper().HandleInput() : MapFactory.Create(Maps.Hard2);

            Console.Clear();
            Console.WriteLine("Map to solve: ");
            Console.WriteLine(map + "\n");

            var stopwatch = new Stopwatch();
            stopwatch.Start();

            var solver = new SudokuSolver();
            solver.AddStrategy(new CandidateChecking());
            solver.AddStrategy(new Backtracking());
            var solution = solver.Solve(map);

            stopwatch.Stop();
            if (solution.IsSolved)
            {
                Console.WriteLine($"\nSolution ({stopwatch.ElapsedMilliseconds} ms):");
                Console.WriteLine(solution);
            }
            else
                Console.WriteLine($"\nSudoku could not be solved ({stopwatch.ElapsedMilliseconds} ms)");

            Console.ReadLine();
        }
    }
}