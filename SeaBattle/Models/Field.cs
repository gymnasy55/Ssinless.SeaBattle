using System.Windows.Forms;

namespace SeaBattle.Models
{
    public class Field
    {
        public static int Width { get; }
        public static int Height { get; }
        public static int Gap { get; }

        public Cell[,] Cells { get; set; }

        static Field()
        {
            Width = 10;
            Height = 10;
            Gap = 2;
        }

        public Field()
        {
            Cells = new Cell[Height, Width];

            for (var i = 0; i < Height; i++)
            {
                for (var j = 0; j < Width; j++)
                {
                    Cells[i, j] = new Cell();
                }
            }
        }
    }
}
