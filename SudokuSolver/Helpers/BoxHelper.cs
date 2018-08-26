using System;
using SudokuSolver.Entities;

namespace SudokuSolver.Helpers
{
    public class BoxHelper
    {
        public static Coordinate GetBoxStartCoordinate(Cell cell)
        {
            var row = cell.Coordinate.Row;
            var column = cell.Coordinate.Column;

            if (row < 3)
            {
                if (column < 3)
                    return new Coordinate(0, 0);

                if (column > 2 && column < 6)
                    return new Coordinate(0, 3);

                if (column > 5)
                    return new Coordinate(0, 6);
            }

            if (row > 2 && row < 6)
            {
                if (column < 3)
                    return new Coordinate(3, 0);

                if (column > 2 && column < 6)
                    return new Coordinate(3, 3);

                if (column > 5)
                    return new Coordinate(3, 6);
            }

            if (row > 5)
            {
                if (column < 3)
                    return new Coordinate(6, 0);

                if (column > 2 && column < 6)
                    return new Coordinate(6, 3);

                if (column > 5)
                    return new Coordinate(6, 6);
            }

            throw new Exception("Invalid coodinate");
        }
    }
}