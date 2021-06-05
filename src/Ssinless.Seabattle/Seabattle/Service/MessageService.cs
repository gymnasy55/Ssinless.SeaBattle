using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Seabattle.Service
{
    public static class MessageService
    {
        public static void Info(string info) =>
            MessageBox.Show(info, @"Information", MessageBoxButtons.OK, MessageBoxIcon.Information);

        public static void Warning(string warning) =>
            MessageBox.Show(warning, @"Information", MessageBoxButtons.OK, MessageBoxIcon.Warning);

        public static void Error(string error) =>
            MessageBox.Show(error, @"Information", MessageBoxButtons.OK, MessageBoxIcon.Error);
    }
}
