namespace SudokuSolver.Entities
{
    public class CellMapPair
    {
        public Cell Cell { get; set; }
        public Map Map { get; set; }

        public CellMapPair(Cell cell, Map map)
        {
            Cell = cell;
            Map = map;
        }
    }
}