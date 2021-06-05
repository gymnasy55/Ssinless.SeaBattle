using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Reflection;
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

        public Control View => _button;

        public string Text
        {
            get => _button.Text;
            set => _button.Text = value;
        }

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

        public bool Enabled
        {
            get => _button.Enabled;
            set => _button.Enabled = value;
        }

        #endregion

        private readonly List<EventHandler> _clickHandlers;

        private event EventHandler Click
        {
            add
            {
                _button.Click += value;
                _clickHandlers.Add(value);
            }
            remove => _button.Click -= value;
        }

        public int X { get; }
        public int Y { get; }

        public bool IsShip { get; set; }
        public bool IsDestroyed { get; set; }
        public bool IsChecked { get; set; }

        public Cell(int y, int x)
        {
            _clickHandlers = new List<EventHandler>();
            X = x;
            Y = y;
            IsShip = IsChecked = IsDestroyed = false;

            _button = new Button
            {
                TextAlign = ContentAlignment.MiddleCenter,
                Width = Width,
                Height = Height,
                FlatStyle = FlatStyle.Flat,
                AutoSize = false,
                Font = new Font("Arial", 16F, FontStyle.Bold, GraphicsUnit.Point, (byte) 204),
                BackColor = Color.LightGray,
                ForeColor = Color.Black,
                Text = "",
                TabStop = false
            };
        }

        public void Mark()
        {
            IsShip = true;
            Text = "X";
        }

        public bool Open()
        {
            if (IsShip)
            {
                Text = "X";
                IsDestroyed = true;
                IsChecked = true;
                SetClickEvent(null, null);
                return true;
            }

            Text = "•";
            IsChecked = true;

            SetClickEvent(null, null);
            return false;
        }

        public void SetClickEvent(Action<object, EventArgs, User> eventHandler, User user)
        {
            foreach (var handler in _clickHandlers) Click -= handler;
            _clickHandlers.Clear();

            Click += (sender, args) => eventHandler?.Invoke(this, args, user);
        }
    }
}
