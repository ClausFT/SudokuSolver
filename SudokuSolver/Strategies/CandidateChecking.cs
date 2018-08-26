using System.Collections.Generic;
using System.Linq;
using SudokuSolver.Entities;
using SudokuSolver.Helpers;
using SudokuSolver.Interfaces;

namespace SudokuSolver.Strategies
{
    public class CandidateChecking : ISudokuSolvingStrategy
    {
        public string Name => "Candidate checking";

        public Map Solve(Map map)
        {
            while (!map.IsSolved)
            {
                bool atLeastOneCellSolved = false;
                foreach (var row in map.Cells)
                {
                    foreach (var cell in row)
                    {
                        if (!cell.IsEmpty)
                            continue;

                        var candidates = FindCandidates(map, cell);
                        if (candidates.Count == 1)
                        {
                            cell.Number = candidates.First();
                            cell.Candidates.Clear();
                            atLeastOneCellSolved = true;
                        }
                        else
                            cell.Candidates = candidates;
                    }
                }

                if (!atLeastOneCellSolved)
                    return map;
            }

            return map;
        }

        private List<int> FindCandidates(Map map, Cell cell)
        {
            var possibleCandidates = cell.Candidates.Any() ? cell.Candidates : new List<int> { 1, 2, 3, 4, 5, 6, 7, 8, 9 };
            var candidates = new List<int>();

            foreach (var candidate in possibleCandidates)
            {
                if (RulesHelper.ViolatesRules(candidate, map, cell))
                    continue;

                candidates.Add(candidate);
            }

            return candidates;
        }
    }
}