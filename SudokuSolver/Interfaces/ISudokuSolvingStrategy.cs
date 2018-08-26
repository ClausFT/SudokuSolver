using SudokuSolver.Entities;

namespace SudokuSolver.Interfaces
{
    public interface ISudokuSolvingStrategy
    {
        string Name { get; }
        Map Solve(Map map);
    }
}