using System.Linq;
using SudokuSolver.Entities;

namespace SudokuSolver.Helpers
{
    public class RulesHelper
    {
        public static bool ViolatesRules(int number, Map map, Cell cell)
        {
            return IsNumberInRow(number, map, cell)
                   || IsNumberInColumn(number, map, cell)
                   || IsNumberInBox(number, map, cell);
        }

        private static bool IsNumberInRow(int number, Map map, Cell cell)
        {
            var row = map.Cells[cell.Coordinate.Row];
            return row.Any(cellToCheck => cellToCheck.Number == number);
        }

        private static bool IsNumberInColumn(int candidate, Map map, Cell cell)
        {
            return map.Cells.Any(row => row[cell.Coordinate.Column].Number == candidate);
        }

        private static bool IsNumberInBox(int candidate, Map map, Cell cell)
        {
            var boxStartCoordinate = BoxHelper.GetBoxStartCoordinate(cell);

            for (int row = boxStartCoordinate.Row; row < boxStartCoordinate.Row + 3; row++)
            {
                for (int column = boxStartCoordinate.Column; column < boxStartCoordinate.Column + 3; column++)
                {
                    if (map.Cells[row][column].Number == candidate)
                        return true;
                }
            }

            return false;
        }
    }
}