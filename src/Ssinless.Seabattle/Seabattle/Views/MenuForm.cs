using System.Windows.Forms;

namespace Seabattle.Views
{
    public partial class MenuForm : Form
    {
        public MenuForm()
        {
            InitializeComponent();
            this.SetIcon();
        }

        private void btnStart_Click(object sender, System.EventArgs e)
        {
            var game = new Game();
            game.Start();
        }
    }
}
