using System.Drawing;
using System.Windows.Forms;

namespace SeaBattle.Models
{
    public class Cell
    {
        public static int Width { get; }
        public static int Height { get; }

        private readonly Button _button;

        public bool IsChecked { get; set; }

        static Cell()
        {
            Width = 40;
            Height = 40;
        }

        public Cell()
        {
            IsChecked = false;
            
            _button = new Button
            {
                TextAlign = ContentAlignment.MiddleCenter,
                Width = Cell.Width,
                Height = Cell.Height,
                FlatStyle = FlatStyle.Flat,
                AutoSize = false,
                Font = new Font("Arial", 16F, FontStyle.Bold, GraphicsUnit.Point, ((byte)(204))),
                BackColor = Color.LightGray,
                ForeColor = Color.Black,
                Text = "",
                TabStop = false
            };
        }

        public void SetPoint(int x, int y)
        {
            _button.Left = x;
            _button.Top = y;
        }

        public void AddToForm(Form form)
        {
            form.Controls.Add(_button);
        }

        public void AddClickHandler(MouseEventHandler handler)
        {
            _button.MouseDown += handler;
        }
    }
}
