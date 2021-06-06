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

                if (ship.Type == ShipType.None
                    && (user.NumberBattleship < Ship.MaxNumber(ShipType.Battleship)
                        || user.NumberCruiser < Ship.MaxNumber(ShipType.Cruiser)
                        || user.NumberCruiser < Ship.MaxNumber(ShipType.Cruiser)
                        || user.NumberCruiser < Ship.MaxNumber(ShipType.Cruiser)))
                {
                    MessageService.Warning("Enter proper number of ships!");
                    return false;
                }

                return true;
            };

            user.ForEach(cell => cell.SetClickEvent(BtnClickedOnUserForm, user));
        }

        private void SetupBattle(User user1, User user2, BattleForm form)
        {
            form.AddField(user1, Cell.DefaultXIndention, Cell.DefaultYIndention);
            form.AddField(user2, Cell.DefaultXIndention + Game.DefaultUserFormClientSize.Width, Cell.DefaultYIndention);

            user1.ForEach(cell =>
            {
                cell.Text = "";
                cell.SetClickEvent(BtnClickedOnBattleForm, user1);
            });
            user2.ForEach(cell =>
            {
                cell.Text = "";
                cell.SetClickEvent(BtnClickedOnBattleForm, user2);
            });

            _currentUser = user2;
            user2.Enabled = false;
            user1.Enabled = true;
            ChangePlayer();
        }

        private void BtnClickedOnUserForm(object sender, EventArgs e, User user)
        {
            var cell = (Cell) sender;
            if (EnablePlaceShip(user, cell))
                PlaceShip(user, cell);
        }

        private void BtnClickedOnBattleForm(object sender, EventArgs e, User user)
        {
            var cell = (Cell) sender;

            if (cell.Open())
            {
                if (IsShipDestoyed(user, cell))
                    OpenAroundShip(user, cell);
                user.DestroyedShips++;
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
            _user1.Enabled = !_user1.Enabled;
            _user2.Enabled = !_user2.Enabled;

            if (_currentUser == _user2)
            {
                _battleForm.SetPlayerText("User 1");
                _currentUser = _user1;
                return;
            }

            _battleForm.SetPlayerText("User 2");
            _currentUser = _user2;
        }

        private bool CheckWin() => _user2.DestroyedShips >= _user2.CellsIsShip || _user1.DestroyedShips >= _user1.CellsIsShip;

        private void PlaceShip(User user, Cell startCell)
        {
            user.PlaceShip();
            for(int i = 0; i < user.SelectedShip.Size.Height; i++)
                for(int j = 0; j < user.SelectedShip.Size.Width; j++)
                    user[startCell.Y + i, startCell.X + j].Mark();
        }

        private bool EnablePlaceShip(User user, Cell startCell)
        {
            for (int i = 0; i < user.SelectedShip.Size.Height; i++)
                for (int j = 0; j < user.SelectedShip.Size.Width; j++)
                    if (!user.Field.IsFieldCell(startCell.Y + i, startCell.X + j) || user.Field.ExistShipsNear(startCell.Y + i, startCell.X + j))
                        return false;
            return user.EnablePlaceShip();
        }

        private void OpenAroundShip(User user, Cell cell)
        {
            OpenAroundShipDirected(user, cell, 1);
            OpenAroundShipDirected(user, cell, -1);
        }

        private void OpenAroundShipDirected(User user, Cell cell, int direction)
        {
            if (user.Field.IsShip(cell.Y, cell.X + direction))
                OpenAroundShipDirected(user, user[cell.Y, cell.X + direction], direction);

            if (user.Field.IsShip(cell.Y + direction, cell.X))
                OpenAroundShipDirected(user, user[cell.Y + direction, cell.X], direction);

            OpenAroundCell(user, cell);
        }

        private void OpenAroundCell(User user, Cell cell)
        {
            for(int i = cell.Y - 1; i <= cell.Y + 1; i++)
                for(int j = cell.X - 1; j <= cell.X + 1; j++)
                    if (user.Field.IsFieldCell(i, j))
                        user[i, j].Open();
        }

        private bool IsShipDestoyed(User user, Cell cell)
        {
            return IsShipDestoyedDirected(user, cell, 1) && IsShipDestoyedDirected(user, cell, -1);
        }

        private bool IsShipDestoyedDirected(User user, Cell cell, int direction)
        {
            if (!cell.IsDestroyed)
                return false;

            if (user.Field.IsShip(cell.Y, cell.X + direction))
                return IsShipDestoyedDirected(user, user[cell.Y, cell.X + direction], direction);

            if (user.Field.IsShip(cell.Y + direction, cell.X))
                return IsShipDestoyedDirected(user, user[cell.Y + direction, cell.X], direction);

            return true;
        }
    }
}
