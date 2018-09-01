using System;
using System.Collections.Generic;
using System.Linq;
using SudokuSolver.Entities;

namespace SudokuSolver.Helpers
{
    public class InputHelper
    {
        private readonly Stack<Map> _inputHistory;
        private Map _currentMap;
        private Coordinate _currentCoordinate;
        private bool _isFinished;

        public InputHelper()
        {
            _isFinished = false;
            _inputHistory = new Stack<Map>();
            _currentMap = new Map();
            _currentCoordinate = new Coordinate(0,0);
        }

        public Map HandleInput()
        {
            var map = new Map();
            Console.WriteLine("Enter map row by row (press Enter for empty cell): ");
            Console.WriteLine(map);

            while (!_isFinished)
            {
                map = HandleKeyChar(Console.ReadKey());
                Console.Clear();
                Console.WriteLine("Enter map row by row (press Enter for empty cell): ");
                Console.WriteLine(map);
            }

            return map;
        }

        public Map HandleKeyChar(ConsoleKeyInfo input)
        {
            if (input.Key == ConsoleKey.Backspace)
            {
                if (!_inputHistory.Any())
                    return _currentMap;

                _currentCoordinate = _currentCoordinate.GetPreviousCoordinate();
                _currentMap = _inputHistory.Pop();
                return _currentMap;
            }

            int value;
            if (input.Key == ConsoleKey.Enter)
                value = 0;
            else
            {
                if (!int.TryParse(input.KeyChar.ToString(), out value))
                    return _currentMap;
            }
                

            _inputHistory.Push(_currentMap.Clone());
            
            var cell = new Cell(_currentCoordinate.Row, _currentCoordinate.Column, value);
            _currentMap.Cells[_currentCoordinate.Row][_currentCoordinate.Column] = cell;

            if (_currentCoordinate.Row == 8 && _currentCoordinate.Column == 8)
            {
                _isFinished = true;
                return _currentMap;
            }

            _currentCoordinate = _currentCoordinate.GetNextCoordinate();
            return _currentMap;
        }
    }
}