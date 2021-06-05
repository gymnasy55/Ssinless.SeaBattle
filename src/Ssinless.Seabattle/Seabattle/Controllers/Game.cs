using System;
using System.Drawing;
using System.Linq.Expressions;
using System.Windows.Forms;
using Seabattle.Models;
using Seabattle.Views;

namespace Seabattle.Controllers
{
    public class Game
    {
        public static Size DefaultUserFormClientSize { get; }
        public static Size DefaultUserFormMinimumSize { get; }
        public static Size DefaultGameFormClientSize { get; }
        public static Size DefaultGameFormMinimumSize { get; }

        static Game()
        {
            DefaultUserFormClientSize = new Size(Field.Width * (Cell.Width + Field.Gap) + 150,
                Field.Height * (Cell.Height + Field.Gap) + 60);
            DefaultUserFormMinimumSize = new Size(Field.Width * (Cell.Width + Field.Gap) + 160,
                Field.Height * (Cell.Height + Field.Gap) + 100);

            DefaultGameFormClientSize = new Size(DefaultUserFormClientSize.Width * 2 - 125, DefaultUserFormClientSize.Height);
            DefaultGameFormMinimumSize = new Size(DefaultUserFormMinimumSize.Width * 2 - 125, DefaultUserFormMinimumSize.Height);
        }

        private readonly Field _field1;
        private readonly Field _field2;

        private readonly UserForm _userForm1;
        private readonly UserForm _userForm2;

        private readonly BattleForm _battleForm;

        public Game()
        {
            _field1 = new Field();

            _userForm1 = new UserForm()
            {
                ClientSize = Game.DefaultUserFormClientSize,
                MinimumSize = Game.DefaultUserFormMinimumSize
            };

            _field2 = new Field();

            _userForm2 = new UserForm()
            {
                ClientSize = Game.DefaultUserFormClientSize,
                MinimumSize = Game.DefaultUserFormMinimumSize
            };

            _battleForm = new BattleForm(_field1, _field2)
            {
                ClientSize = Game.DefaultGameFormClientSize,
                MinimumSize = Game.DefaultGameFormMinimumSize
            };
        }

        public void Start()
        {
            _field1.AddToForm(_userForm1, Cell.DefaultXIndention, Cell.DefaultYIndention);

            _field1.ForEach(cell => cell.SetClickEvent(BtnClickedOnUserForm, _field1));

            _userForm1.ShowDialog();

            _field2.AddToForm(_userForm2, Cell.DefaultXIndention, Cell.DefaultYIndention);

            _field2.ForEach(cell => cell.SetClickEvent(BtnClickedOnUserForm, _field2));

            _userForm2.ShowDialog();

            _field1.AddToForm(_battleForm, Cell.DefaultXIndention, Cell.DefaultYIndention);
            _field2.AddToForm(_battleForm, Cell.DefaultXIndention + Game.DefaultUserFormClientSize.Width, Cell.DefaultYIndention);

            _field1.ForEach(cell =>
            {
                cell.Text = "";
                cell.SetClickEvent(BtnClickedOnBattleForm, _field1);
            });
            _field2.ForEach(cell =>
            {
                cell.Text = "";
                cell.SetClickEvent(BtnClickedOnBattleForm, _field2);
            });

            _battleForm.Start();
        }

        public void BtnClickedOnUserForm(object sender, EventArgs e, Field field)
        {
            var cell = (Cell) sender;
            cell.IsShip = true;
            cell.Text = "X";
        }

        public void BtnClickedOnBattleForm(object sender, EventArgs e, Field field)
        {
            var cell = (Cell) sender;

            if (cell.IsShip)
            {
                cell.Text = "X";
                cell.IsDestroyed = true;
                cell.IsChecked = true;
                cell.SetClickEvent(null, null);
                return;
            }

            cell.Text = "•";
            cell.IsChecked = true;

            cell.SetClickEvent(null, null);

            _battleForm.ChangePlayer();
        }
    }
}
