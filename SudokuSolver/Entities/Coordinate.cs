namespace SudokuSolver.Entities
{
    public class Coordinate
    {
        public int Row { get; set; }
        public int Column { get; set; }

        public Coordinate(int row, int column)
        {
            Row = row;
            Column = column;
        }

        public Coordinate GetNextCoordinate()
        {
            return Column == 8 ? new Coordinate(Row + 1, 0) : new Coordinate(Row, Column + 1);
        }

        public Coordinate GetPreviousCoordinate()
        {
            if (Row == 0 && Column == 0)
                return this;

            return Column == 0 ? new Coordinate(Row - 1, 8) : new Coordinate(Row, Column - 1);
        }
    }
}