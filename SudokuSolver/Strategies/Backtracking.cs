using System.Collections.Generic;
using System.Linq;
using SudokuSolver.Entities;
using SudokuSolver.Helpers;
using SudokuSolver.Interfaces;

namespace SudokuSolver.Strategies
{
    public class Backtracking : ISudokuSolvingStrategy
    {
        public string Name => "Backtracking";

        public Map Solve(Map map)
        {
            var cell = map.Cells[0][0];
            var dfsStack = new Stack<CellMapPair>();
            dfsStack.Push(new CellMapPair(cell, map));

            while (dfsStack.Any())
            {
                var cellMapPair = dfsStack.Pop();
                var currentMap = cellMapPair.Map;
                var currentCell = cellMapPair.Cell;
                if (currentCell.IsSolved)
                {
                    if (currentCell.IsLastCell)
                        return currentMap;

                    var nextCoordinate = currentCell.Coordinate.GetNextCoordinate();
                    dfsStack.Push(new CellMapPair(currentMap.Cells[nextCoordinate.Row][nextCoordinate.Column], currentMap));
                    continue;
                }

                var candidates = currentCell.Candidates.Any() ? currentCell.Candidates : new List<int> { 1, 2, 3, 4, 5, 6, 7, 8, 9 };
                foreach (var candidate in candidates)
                {
                    if (RulesHelper.ViolatesRules(candidate, currentMap, currentCell))
                        continue;

                    var candidateMap = currentMap.Clone();
                    var candidateCell = currentCell.Clone();
                    candidateCell.Number = candidate;
                    candidateMap.Cells[candidateCell.Coordinate.Row][candidateCell.Coordinate.Column] = candidateCell;
                    if (currentCell.IsLastCell)
                        return candidateMap;

                    var nextCoordinate = currentCell.Coordinate.GetNextCoordinate();
                    dfsStack.Push(new CellMapPair(candidateMap.Cells[nextCoordinate.Row][nextCoordinate.Column], candidateMap));

                    //Console.Clear();
                    //Console.WriteLine(candidateMap);
                    //Thread.Sleep(50);
                }

            }

            return map;
        }
    }
}