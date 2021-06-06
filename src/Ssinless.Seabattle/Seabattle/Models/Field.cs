using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Seabattle.Models
{
    public class Field
    {
        public static int Width { get; }
        public static int Height { get; }
        public static int Gap { get; }

        static Field()
        {
            Width = Height = 10;
            Gap = 2;
        }

        private readonly Cell[,] _cells;

        public Cell this[int y, int x] => _cells[y, x];

        public bool Enabled
        {
            get => _cells.Cast<Cell>().Any(cell => cell.Enabled);
            set
            {
                foreach (var cell in _cells)
                {
                    if (!cell.IsChecked || !value) cell.Enabled = value;
                }
            }
        }

        public int CellsIsShip
        {
            get
            {
                var result = 0;

                ForEach(cell =>
                {
                    if (cell.IsShip) result++;
                });

                return result;
            }
        }

        public void ForEach(Action<Cell> action)
        {
            foreach (var cell in _cells) action(cell);
        }

        public bool IsFieldCell(int y, int x) => x >= 0 && y >= 0 && x < Width && y < Height;

        public bool IsShip(int y, int x) => IsFieldCell(y, x) && this[y, x].IsShip;

        public bool ExistShipsNear(int y, int x) => 
            IsShip(y - 1, x) || IsShip(y + 1, x) || IsShip(y - 1, x - 1) || IsShip(y - 1, x + 1) || IsShip(y + 1, x - 1) || IsShip(y + 1, x + 1) || IsShip(y, x - 1) || IsShip(y, x + 1);

        public Field()
        {
            _cells = new Cell[Field.Height, Field.Width];

            for (var i = 0; i < Field.Height; i++)
                for (var j = 0; j < Field.Width; j++)
                    _cells[i, j] = new Cell(i, j);
        }
    }
}
