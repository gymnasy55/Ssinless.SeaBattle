using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Seabattle.Models
{
    public class Ship
    {
        public ShipType Type { get; set; }
        public ShipOrientation Orientation { get; set; }

        public Ship(ShipType type = ShipType.None, ShipOrientation orientation = ShipOrientation.Horizontal & ShipOrientation.Vertical)
        {
            Type = type;
            Orientation = orientation;
        }

        public override string ToString() =>
            (Type, Orientation) switch
            {
                (ShipType.Battleship, ShipOrientation.Horizontal) => "Horizontal Battleship",
                (ShipType.Battleship, ShipOrientation.Vertical) => "Vertical Battleship",
                (ShipType.Cruiser, ShipOrientation.Horizontal) => "Horizontal Cruiser",
                (ShipType.Cruiser, ShipOrientation.Vertical) => "Vertical Cruiser",
                (ShipType.Destroyer, ShipOrientation.Horizontal) => "Horizontal Destroyer",
                (ShipType.Destroyer, ShipOrientation.Vertical) => "Vertical Destroyer",
                (ShipType.Boat, ShipOrientation.Vertical & ShipOrientation.Horizontal) => "Boat",
                _ => "Nothing"
            };
    }
}
