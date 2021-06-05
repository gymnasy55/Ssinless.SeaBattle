using System;
using System.Drawing;
using System.Windows.Forms;
using Seabattle.Models;
using Seabattle.Service;
using Seabattle.Views;

namespace Seabattle.Controllers
{
    public class Game
    {
        private static Size DefaultUserFormClientSize { get; }
        private static Size DefaultUserFormMinimumSize { get; }

        private static Size DefaultBattleFormClientSize { get; }
        private static Size DefaultBattleFormMinimumSize { get; }

        static Game()
        {
            DefaultUserFormClientSize = new Size(Field.Width * (Cell.Width + Field.Gap) + 150,
                Field.Height * (Cell.Height + Field.Gap) + 60);
            DefaultUserFormMinimumSize = new Size(Field.Width * (Cell.Width + Field.Gap) + 160,
                Field.Height * (Cell.Height + Field.Gap) + 100);

            DefaultBattleFormClientSize = new Size(DefaultUserFormClientSize.Width * 2 - 125, DefaultUserFormClientSize.Height);
            DefaultBattleFormMinimumSize = new Size(DefaultUserFormMinimumSize.Width * 2 - 125, DefaultUserFormMinimumSize.Height);
        }

        private readonly User _user1;
        private readonly User _user2;

        private User _currentUser;

        private readonly UserForm _userForm1;
        private readonly UserForm _userForm2;

        private readonly BattleForm _battleForm;

        public Game()
        {
            _user1 = new User();
            _user2 = new User();

            _userForm1 = Game.InitializeUserForm();
            _userForm2 = Game.InitializeUserForm();

            _battleForm = new BattleForm
            {
                ClientSize = Game.DefaultBattleFormClientSize,
                MinimumSize = Game.DefaultBattleFormMinimumSize
            };
        }

        private static UserForm InitializeUserForm() =>
            new UserForm
            {
                ClientSize = Game.DefaultUserFormClientSize,
                MinimumSize = Game.DefaultUserFormMinimumSize
            };

        public void Start()
        {
            SetupUser(_user1, _userForm1);
            _userForm1.ShowDialog();

            SetupUser(_user2, _userForm2);
            _userForm2.ShowDialog();

            SetupBattle(_user1, _user2, _battleForm);
            _battleForm.ShowDialog();
        }

        private void SetupUser(User user, UserForm form)
        {
            form.AddField(user, Cell.DefaultXIndention, Cell.DefaultYIndention);
            form.ShipChanged += ship =>
            {
                user.SelectedShip = ship;
                form.SetSelectedShipText(ship.ToString());
            };

            user.ForEach(cell => cell.SetClickEvent(BtnClickedOnUserForm, user));
        }

        private void BtnClickedOnUserForm(object sender, EventArgs e, User user)
        {
            var cell = (Cell) sender;
            cell.Mark();
        }

        private void SetupBattle(User user1, User user2, BattleForm form)
        {
            form.AddField(user1, Cell.DefaultXIndention, Cell.DefaultYIndention);
            form.AddField(user2, Cell.DefaultXIndention + Game.DefaultUserFormClientSize.Width, Cell.DefaultYIndention);

            user1.ForEach(cell =>
            {
                cell.Text = "";
                cell.SetClickEvent(BtnClickedOnBattleForm, user2);
            });
            user2.ForEach(cell =>
            {
                cell.Text = "";
                cell.SetClickEvent(BtnClickedOnBattleForm, user1);
            });

            _currentUser = user2;
            ChangePlayer();
        }

        private void BtnClickedOnBattleForm(object sender, EventArgs e, User user)
        {
            var cell = (Cell) sender;

            if (cell.Open())
            {
                user.Score++;
                if (CheckWin())
                {
                    MessageService.Info(_currentUser == _user1 ? "User 1 won" : "User 2 won");
                    Application.Restart();
                }
            } 
            else ChangePlayer();
        }

        private void ChangePlayer()
        {
            if (_currentUser == _user2)
            {
                _user2.Enabled = true;
                _user1.Enabled = false;
                _battleForm.SetPlayerText("User 1");
                _currentUser = _user1;
                return;
            }

            _user2.Enabled = false;
            _user1.Enabled = true;
            _battleForm.SetPlayerText("User 2");
            _currentUser = _user2;
        }

        private bool CheckWin() => _user1.Score == _user2.CellsIsShip || _user2.Score == _user1.CellsIsShip;
    }
}
