using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Seabattle.Models;
using Seabattle.Views;

namespace Seabattle
{
    public class Game
    {
        public static Size DefaultUserFormClientSize { get; }
        public static Size DefaultUserFormMinimumSize { get; }

        static Game()
        {
            DefaultUserFormClientSize = new Size(Field.Width * (Cell.Width + Field.Gap) + 150,
                Field.Height * (Cell.Height + Field.Gap) + 60);
            DefaultUserFormMinimumSize = new Size(Field.Width * (Cell.Width + Field.Gap) + 160,
                Field.Height * (Cell.Height + Field.Gap) + 100);
        }

        private readonly Field _field1;
        private readonly Field _field2;

        private readonly UserForm _userForm1;
        private readonly UserForm _userForm2;

        public Game()
        {
            _field1 = new Field();

            _userForm1 = new UserForm(_field1)
            {
                ClientSize = Game.DefaultUserFormClientSize,
                MinimumSize = Game.DefaultUserFormMinimumSize
            };

            _field2 = new Field();

            _userForm2 = new UserForm(_field2)
            {
                ClientSize = Game.DefaultUserFormClientSize,
                MinimumSize = Game.DefaultUserFormMinimumSize
            };
        }

        public void Start()
        {
            _field1.AddToForm(_userForm1, Cell.DefaultXIndention, Cell.DefaultYIndention);

            foreach (var cell in (Cell[,])_field1)
            {
                cell.SetClickEvent(BtnClicked);
            }

            _userForm1.ShowDialog();

            _field2.AddToForm(_userForm2, Cell.DefaultXIndention, Cell.DefaultYIndention);

            foreach (var cell in (Cell[,])_field2)
            {
                cell.SetClickEvent(BtnClicked);
            }

            _userForm2.ShowDialog();
        }

        public void BtnClicked(object sender, EventArgs e)
        {
            var cell = sender as Cell;
            MessageBox.Show($"X: {cell.X}, Y:{cell.Y}");
        }
    }
}
