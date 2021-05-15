using System.Windows.Forms;
using SeaBattle.Models;

namespace SeaBattle.Views
{
    public partial class MenuForm : Form
    {
        public MenuForm()
        {
            InitializeComponent();
            this.SetIcon();
        }

        private void btnRules_Click(object sender, System.EventArgs e)
        {
            var rulesForm = new RulesForm();
            rulesForm.ShowDialog();
        }

        private void btnStart_Click(object sender, System.EventArgs e)
        {
            var game = new Game();
            game.Start();
        }
    }
}