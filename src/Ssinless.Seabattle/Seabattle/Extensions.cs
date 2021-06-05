using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Seabattle.Models;
using Seabattle.Resources;

namespace Seabattle
{
    public static class Extensions
    {
        public static void SetIcon(this Form form)
        {
            form.Icon = Global.Logo2;
        }

        public static void AddField(this Form form, User user, int left, int top)
        {
            int x = left, y = top;

            for (var i = 0; i < Field.Height; i++)
            {
                for (var j = 0; j < Field.Width; j++)
                {
                    user[i, j].Left = x;
                    user[i, j].Top = y;
                    form.Controls.Add(user[i, j].View);

                    x += Field.Gap + Cell.Width;
                }

                y += Field.Gap + Cell.Height;
                x = left;
            }
        }
    }
}
