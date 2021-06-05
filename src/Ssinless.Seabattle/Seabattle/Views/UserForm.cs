using System;
using System.Windows.Forms;
using Seabattle.Models;

namespace Seabattle.Views
{
    public partial class UserForm : Form
    {
        private readonly Field _field;

        private (ShipType type, ShipOrientation orientation) _selectedShip;

        public event Action ShipChanged;

        public UserForm(Field field)
        {
            InitializeComponent();
            this.SetIcon();
            _field = field;

            ShipChanged = SetSelected;
        }

        private void SetSelected()
        {
            var chosenShip = _selectedShip switch
            {
                (ShipType.Battleship, ShipOrientation.Horizontal) => "Horizontal Battleship",
                (ShipType.Battleship, ShipOrientation.Vertical) => "Vertical Battleship",
                (ShipType.Cruiser, ShipOrientation.Horizontal) => "Horizontal Cruiser",
                (ShipType.Cruiser, ShipOrientation.Vertical) => "Vertical Cruiser",
                (ShipType.Destroyer, ShipOrientation.Horizontal) => "Horizontal Destroyer",
                (ShipType.Destroyer, ShipOrientation.Vertical) => "Vertical Destroyer",
                (ShipType.Boat, ShipOrientation.Vertical & ShipOrientation.Horizontal) => "Boat",
                _ => "Nothing"
            };

            lblSelected.Text = $"Selected:\n{chosenShip}.";
        }

        #region Ship Changed Methods

        private void btnBattleshipHorizontal_Click(object sender, EventArgs e)
        {
            _selectedShip = (ShipType.Battleship, ShipOrientation.Horizontal);
            ShipChanged?.Invoke();
        }

        private void btnBattleshipVertical_Click(object sender, EventArgs e)
        {
            _selectedShip = (ShipType.Battleship, ShipOrientation.Vertical);
            ShipChanged?.Invoke();
        }

        private void btnCruiserHorizontal_Click(object sender, EventArgs e)
        {
            _selectedShip = (ShipType.Cruiser, ShipOrientation.Horizontal);
            ShipChanged?.Invoke();
        }

        private void btnCruiserVertical_Click(object sender, EventArgs e)
        {
            _selectedShip = (ShipType.Cruiser, ShipOrientation.Vertical);
            ShipChanged?.Invoke();
        }

        private void btnDestroyerHorizontal_Click(object sender, EventArgs e)
        {
            _selectedShip = (ShipType.Destroyer, ShipOrientation.Horizontal);
            ShipChanged?.Invoke();
        }

        private void btnDestroyerVertical_Click(object sender, EventArgs e)
        {
            _selectedShip = (ShipType.Destroyer, ShipOrientation.Vertical);
            ShipChanged?.Invoke();
        }

        private void btnBoat_Click(object sender, EventArgs e)
        {
            _selectedShip = (ShipType.Boat, ShipOrientation.Vertical & ShipOrientation.Horizontal);
            ShipChanged?.Invoke();
        }

        #endregion

        private void btnNext_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
