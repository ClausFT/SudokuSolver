using SudokuSolver.Entities;

namespace SudokuSolver.Factories
{
    public class MapFactory
    {
        public static Map Create(int[][] simpleMap)
        {
            var map = new Map();

            for (int row = 0; row < 9; row++)
            {
                for (int column = 0; column < 9; column++)
                {
                    var value = simpleMap[row][column];
                    var cell = new Cell(row, column, value);
                    map.Cells[row][column] = cell;
                }
            }

            return map;
        }
    }
}