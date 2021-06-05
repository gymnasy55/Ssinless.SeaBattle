using System;
using System.Drawing;
using System.Windows.Forms;

namespace Seabattle.Models
{
    public class Cell
    {
        #region Cell as static class

        public static int Width { get; }
        public static int Height { get; }
        public static int DefaultXIndention { get; }
        public static int DefaultYIndention { get; }

        static Cell()
        {
            Width = Height = 40;
            DefaultXIndention = DefaultYIndention = 13;
        }

        #endregion

        #region Button Properties

        private readonly Button _button;
        public static implicit operator Button(Cell cell) => cell._button;

        public int Left
        {
            get => _button.Left;
            set => _button.Left = value;
        }

        public int Top
        {
            get => _button.Top;
            set => _button.Top = value;
        }

        #endregion

        public int X { get; }
        public int Y { get; }
        public bool IsShip { get; set; }
        public bool IsDestroyed { get; set; }

        public Cell(int y, int x)
        {
            X = x;
            Y = y;
            IsShip = IsDestroyed = false;

            _button = new Button
            {
                TextAlign = ContentAlignment.MiddleCenter,
                Width = Width,
                Height = Height,
                FlatStyle = FlatStyle.Flat,
                AutoSize = false,
                Font = new Font("Arial", 16F, FontStyle.Bold, GraphicsUnit.Point, (byte)204),
                BackColor = Color.LightGray,
                ForeColor = Color.Black,
                Text = ""
            };
        }

        public void SetClickEvent(EventHandler eventHandler) =>
            _button.Click += (sender, args) => eventHandler?.Invoke(this, args);
    }
}
