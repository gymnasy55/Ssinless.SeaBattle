using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Seabattle.Models
{
    public class User
    {
        public Field Field { get; }

        public Ship SelectedShip { get; set; }

        public Cell this[int y, int x] => Field[y, x];

        public bool Enabled
        {
            get => Field.Enabled;
            set => Field.Enabled = value;
        }

        public int Score { get; set; }

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

        public void ForEach(Action<Cell> action) => Field.ForEach(action);

        public User()
        {
            Field = new Field();
            SelectedShip = new Ship();
        }
    }
}
