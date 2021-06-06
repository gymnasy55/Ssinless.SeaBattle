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
        private readonly Timer _timer;

        private readonly Label _lblTimer;
        private readonly Label _lblPlayer;

        public BattleForm()
        {
            InitializeComponent();
            this.SetIcon();

            _timer = new Timer()
            {
                Enabled = false,
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
        }

        public new DialogResult ShowDialog()
        {
            _timer.Enabled = true;
            return base.ShowDialog();
        }

        private void TimerOnTick(object sender, EventArgs e)
        {
            _lblTimer.Text = $@"{Convert.ToInt32(_lblTimer.Text.Substring(0, _lblTimer.Text.Length - 2)) + 1} s";
        }

        public void SetPlayerText(string text)
        {
            _lblPlayer.Text = text;
        }

        private void BattleForm_Activated(object sender, EventArgs e)
        {
            _timer.Enabled = true;
        }

        private void BattleForm_Deactivate(object sender, EventArgs e)
        {
            _timer.Enabled = false;
        }
    }
}
