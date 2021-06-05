using System;
using System.Windows.Forms;
using Seabattle.Models;

namespace Seabattle.Views
{
    public partial class UserForm : Form
    {
        public event Action<Ship> ShipChanged;

        public UserForm()
        {
            InitializeComponent();
            this.SetIcon();

            ShipChanged = null;
        }

        public void SetSelectedShipText(string text) => lblSelected.Text = $"Selected:\n{text}.";

        #region Ship Changed Methods

        private void btnBattleshipHorizontal_Click(object sender, EventArgs e) => 
            ShipChanged?.Invoke(new Ship(ShipType.Battleship, ShipOrientation.Horizontal));

        private void btnBattleshipVertical_Click(object sender, EventArgs e) => 
            ShipChanged?.Invoke(new Ship(ShipType.Battleship, ShipOrientation.Vertical));

        private void btnCruiserHorizontal_Click(object sender, EventArgs e) => 
            ShipChanged?.Invoke(new Ship(ShipType.Cruiser, ShipOrientation.Horizontal));

        private void btnCruiserVertical_Click(object sender, EventArgs e) => 
            ShipChanged?.Invoke(new Ship(ShipType.Cruiser, ShipOrientation.Vertical));

        private void btnDestroyerHorizontal_Click(object sender, EventArgs e) => 
            ShipChanged?.Invoke(new Ship(ShipType.Destroyer, ShipOrientation.Horizontal));

        private void btnDestroyerVertical_Click(object sender, EventArgs e) => 
            ShipChanged?.Invoke(new Ship(ShipType.Destroyer, ShipOrientation.Vertical));

        private void btnBoat_Click(object sender, EventArgs e) =>
            ShipChanged?.Invoke(new Ship(ShipType.Boat, ShipOrientation.Vertical & ShipOrientation.Horizontal));

        #endregion

        private void btnNext_Click(object sender, EventArgs e)
        {
            ShipChanged?.Invoke(new Ship());
            Close();
        }
    }
}
