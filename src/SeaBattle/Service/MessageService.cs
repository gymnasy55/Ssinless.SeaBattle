using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SeaBattle.Service
{
    public static class MessageService
    {
        public static void Info(string message)
        {
            MessageBox.Show(message, "Info", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
    }
}
