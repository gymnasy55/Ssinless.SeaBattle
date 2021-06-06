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

        public int NumberBattleship {get; set; } = 0;
        public int NumberCruiser { get; set; } = 0;
        public int NumberDestroyer { get; set; } = 0;
        public int NumberBoat { get; set; } = 0;

        public Cell this[int y, int x] => Field[y, x];

        public bool Enabled
        {
            get => Field.Enabled;
            set => Field.Enabled = value;
        }

        public int DestroyedShips { get; set; }

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

        public bool EnablePlaceShip()
        {
            return SelectedShip.Type switch
            {
                ShipType.Battleship => NumberBattleship < Ship.MaxNumber(ShipType.Battleship),
                ShipType.Cruiser => NumberCruiser < Ship.MaxNumber(ShipType.Cruiser),
                ShipType.Destroyer => NumberDestroyer < Ship.MaxNumber(ShipType.Destroyer),
                ShipType.Boat => NumberBoat < Ship.MaxNumber(ShipType.Boat),
                _ => false,
            };
        }

        public void PlaceShip()
        {
            _ = SelectedShip.Type switch
            {
                ShipType.Battleship => NumberBattleship++,
                ShipType.Cruiser => NumberCruiser++,
                ShipType.Destroyer => NumberDestroyer++,
                ShipType.Boat => NumberBoat++
            };
        }
    }
}
