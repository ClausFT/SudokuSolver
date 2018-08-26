using System.Collections.Generic;
using System.Linq;

namespace SudokuSolver.Entities
{
    public class Cell
    {
        public int Number { get; set; }
        public Coordinate Coordinate { get; set; }
        public List<int> Candidates { get; set; }

        public bool IsEmpty => Number == 0;
        public bool IsSolved => !IsEmpty && !Candidates.Any();
        public bool IsLastCell => Coordinate.Row == 8 && Coordinate.Column == 8;

        public Cell(int row, int column, int number)
        {
            Candidates = new List<int>();
            Number = number;
            Coordinate = new Coordinate(row, column);
        }

        public Cell(int row, int column, int number, List<int> candidates)
        {
            Candidates = new List<int>();
            Number = number;
            Coordinate = new Coordinate(row, column);
            Candidates = candidates;
        }

        public Cell Clone()
        {
            return new Cell(Coordinate.Row, Coordinate.Column, Number, new List<int>(Candidates));
        }
    }
}