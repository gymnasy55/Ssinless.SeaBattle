using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Seabattle.Models;

namespace Seabattle.Views
{
    public partial class BattleForm : Form
    {
        private enum User
        {
            User1,
            User2
        }

        private readonly Timer _timer;

        private readonly Label _lblTimer;
        private readonly Label _lblPlayer;

        private User _user;

        private readonly Field _field1;
        private readonly Field _field2;

        public BattleForm(Field field1, Field field2)
        {
            InitializeComponent();
            this.SetIcon();

            _timer = new Timer()
            {
                Enabled = true,
                Interval = 1000
            };

            _timer.Tick += TimerOnTick;

            _lblTimer = new Label
            {
                Left = Field.Width * (Cell.Width + Field.Gap) + Cell.DefaultXIndention + 2,
                Top = Cell.DefaultYIndention,
                TextAlign = ContentAlignment.MiddleCenter,
                Width = 146,
                Height = 25,
                BorderStyle = BorderStyle.Fixed3D,
                AutoSize = false,
                Font = new Font("Arial", 16F, FontStyle.Bold, GraphicsUnit.Point, (byte)204),
                ForeColor = Color.DeepPink,
                Text = "0 s"
            };


            _lblPlayer = new Label
            {
                Left = Field.Width * (Cell.Width + Field.Gap) + Cell.DefaultXIndention + 2,
                Top = _lblTimer.Top + _lblTimer.Height + 2,
                TextAlign = ContentAlignment.MiddleCenter,
                Width = 146,
                Height = 25,
                BorderStyle = BorderStyle.Fixed3D,
                AutoSize = false,
                Font = new Font("Arial", 16F, FontStyle.Bold, GraphicsUnit.Point, (byte)204),
                ForeColor = Color.Black,
                Text = "User 1"
            };

            Controls.Add(_lblTimer);
            Controls.Add(_lblPlayer);

            _field1 = field1;
            _field2 = field2;

            
        }

        public void Start()
        {
            _user = User.User2;
            ChangePlayer();
            ShowDialog();
        }

        private void TimerOnTick(object sender, EventArgs e)
        {
            _lblTimer.Text = $"{Convert.ToInt32(_lblTimer.Text.Substring(0, _lblTimer.Text.Length - 2)) + 1} s";
        }

        public void ChangePlayer()
        {
            _user = _user switch
            {
                User.User1 => User.User2,
                User.User2 => User.User1,
                _ => User.User1
            };

            switch (_user)
            {
                case User.User1:
                    _lblPlayer.Text = "User 1";
                    _field1.Enabled = false;
                    _field2.Enabled = true;
                    break;
                case User.User2:
                    _lblPlayer.Text = "User 2";
                    _field1.Enabled = true;
                    _field2.Enabled = false;
                    break;
                default:
                    throw new ArgumentOutOfRangeException();
            }
        }
    }
}
