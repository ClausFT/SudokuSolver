using System.Linq;
using System.Text;

namespace SudokuSolver.Entities
{
    public class Map
    {
        public Cell[][] Cells { get; set; }
        public bool IsSolved => Cells.All(row => row.All(cell => !cell.IsEmpty));

        public Map()
        {
            Cells = new Cell[9][];
            for (int row=0; row<9; row++)
                Cells[row] = new Cell[9];
        }

        public override string ToString()
        {
            var sb = new StringBuilder();
            var cursorPrinted = false;
            bool firstRow = true;
            foreach (var row in Cells)
            {
                sb.Append(firstRow ? "┌───┬───┬───┬───┬───┬───┬───┬───┬───┐\n│" : "├───┼───┼───┼───┼───┼───┼───┼───┼───┤\n│");
                firstRow = false;
                foreach (var cell in row)
                {
                    if (cell == null && !cursorPrinted)
                    {
                        sb.Append(" _ │");
                        cursorPrinted = true;
                    }
                    else if (cell == null)
                        sb.Append("   │");
                    else
                        sb.Append(cell.Number == 0 ? "   │" : $" {cell.Number} │");
                }
                sb.Append("\n");
            }
            sb.Append("└───┴───┴───┴───┴───┴───┴───┴───┴───┘");
            return sb.ToString();
        }
        
        public Map Clone()
        {
            var clone = new Map();

            for (int row = 0; row < 9; row++)
            {
                for (int column = 0; column < 9; column++)
                {
                    clone.Cells[row][column] = Cells[row][column]?.Clone();
                }
            }

            return clone;
        }
    }
}