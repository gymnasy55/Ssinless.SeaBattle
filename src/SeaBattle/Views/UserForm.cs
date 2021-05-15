using System.Windows.Forms;
using SeaBattle.Models;

namespace SeaBattle.Views
{
    public partial class UserForm : Form
    {
        public UserForm()
        {
            InitializeComponent();
            this.SetIcon();
        }

        private void btnNext_Click(object sender, System.EventArgs e)
        {
            Close();
        }
    }
}
