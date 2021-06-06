using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Seabattle.Models
{
    public class Ship
    {
        public static int MaxNumber(ShipType type) =>
            type switch
            {
                ShipType.Battleship => 1,
                ShipType.Cruiser => 2,
                ShipType.Destroyer => 3,
                ShipType.Boat => 4,
                _ => 0
            };

        public ShipType Type { get; set; }
        public ShipOrientation Orientation { get; set; }

        public (int Height, int Width) Size =>
            (Type, Orientation) switch
            {
                (ShipType.Battleship, ShipOrientation.Horizontal) => (1, 4),
                (ShipType.Battleship, ShipOrientation.Vertical) => (4, 1),
                (ShipType.Cruiser, ShipOrientation.Horizontal) => (1, 3),
                (ShipType.Cruiser, ShipOrientation.Vertical) => (3, 1),
                (ShipType.Destroyer, ShipOrientation.Horizontal) => (1, 2),
                (ShipType.Destroyer, ShipOrientation.Vertical) => (2, 1),
                (ShipType.Boat, ShipOrientation.Vertical & ShipOrientation.Horizontal) => (1, 1),
                _ => (0, 0)
            };

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
