using System.Drawing;
using System.Windows.Forms;
using SeaBattle.Models;
using SeaBattle.Service;

namespace SeaBattle
{
    public static class Extensions
    {
        public static void SetIcon(this Form form)
        {
            form.Icon = Global.LOGO;
        }

        public static void AddField(this Form form, Field field, int startX)
        {
            int x = startX, y = Field.Gap;
            for (var i = 0; i < field.Cells.GetLength(0); i++)
            {
                for (var j = 0; j < field.Cells.GetLength(1); j++)
                {
                    field.Cells[i, j].SetPoint(x, y);
                    field.Cells[i, j].AddToForm(form);
                    x += Cell.Width + Field.Gap;
                }

                x = startX;
                y += Cell.Height + Field.Gap;
            }
        }
    }
}