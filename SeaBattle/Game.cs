using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using SeaBattle.Models;
using SeaBattle.Service;
using SeaBattle.Views;

namespace SeaBattle
{
    public class Game
    {
        private readonly Field _field1;
        private readonly Field _field2;

        private readonly UserForm _userForm1;
        private readonly UserForm _userForm2;
        private readonly GameForm _gameForm;

        public Game()
        {
            _field1 = new Field();

            foreach (var cell in _field1.Cells)
            {
                cell.AddClickHandler(ButtonMouseDown);
            }

            _field2 = new Field();

            foreach (var cell in _field2.Cells)
            {
                cell.AddClickHandler(ButtonMouseDown);
            }

            _userForm1 = new UserForm();
            _userForm2 = new UserForm();

            _gameForm = new GameForm();
        }

        public void Start()
        {
            _userForm1.AddField(_field1, 14);
            _userForm1.ShowDialog();


            _userForm2.AddField(_field2, 14);
            _userForm2.ShowDialog();

            _gameForm.AddField(_field1, 14);
            _gameForm.AddField(_field2, 464);
            _gameForm.ShowDialog();
        }

        public void ButtonMouseDown(object sender, MouseEventArgs e)
        {
            var btn = sender as Button;
            btn.Text = btn.Text == "" ? "X" : "";
        }
    }
}
