using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Lab3Prsvednik
{
    public partial class Form1 : Form
    {
        public Form1()
        {

            InitializeComponent();
            gr.Clear(Color.White);

        }


        static Bitmap bmp = new Bitmap(989, 382);

        public Graphics gr = Graphics.FromImage(bmp);
        Pen p = new Pen(Color.Black);
        bool Mose_D = false;
        public int x0, y0;

        void MD(object sen, MouseEventArgs e)
        {
            Mose_D = true;
            x0 = (int)e.X;
            y0 = (int)e.Y;
        }

        void MU(object sen, MouseEventArgs e) { Mose_D = false; }

        void MMove(object sen, MouseEventArgs e)
        {
            if (Mose_D)
            {
                if (radioButton1.Checked)
                {
                    Algorithm_Bras(x0, y0, e.X, e.Y);
                }
                else if (radioButton2.Checked)
                {
                    Algorithm_Vu(x0, y0, e.X, e.Y);
                }
            }
        }

        void DrawVu(int x, int y, float transparency)
        {
            Color c = bmp.GetPixel(x, y);
            bmp.SetPixel(x, y, Color.FromArgb(255, (int)(c.R * (1 - transparency)), (int)(c.G * (1 - transparency)), (int)(c.B * (1 - transparency))));
        }

        void Algorithm_Bras(int x0, int y0, int x1, int y1)
        {
            int dX = Math.Abs(x1 - x0), dY = -Math.Abs(y1 - y0);
            int sx, sy;
            if (x0 < x1)
                sx = 1;
            else
            {
                sx = -1;
            }
            if (y0 < y1)
                sy = 1;
            else
            {
                sy = -1;
            }
            int err = dX + dY;
            bmp.SetPixel(x1, y1, Color.Black);
            while (x0 != x1 || y0 != y1)
            {
                bmp.SetPixel(x0, y0, Color.Black);
                int err2 = err * 2;
                if (err2 >= dY)
                {
                    err += dY;
                    x0 += sx;
                }
                if (err2 <= dX)
                {
                    err += dX;
                    y0 += sy;
                }
            }
            pictureBox1.Image = bmp;
        }

        void Algorithm_Vu(int x0, int y0, int x1, int y1)
        {
            int xt0 = x0, yt0 = y0, xt1 = x1, yt1 = y1;
            int temp1, temp2;
            if (Math.Abs(x1 - x0) < Math.Abs(y1 - y0))
            {
                temp1 = x0;
                temp2 = x1;
                x0 = y0;
                y0 = temp1;
                x1 = y1;
                y1 = temp2;
            }
            if (x0 > x1)
            {
                temp1 = x0;
                temp2 = y0;
                x0 = x1;
                x1 = temp1;
                y0 = y1;
                y1 = temp2;
            }
            float dx = x1 - x0, dy = y1 - y0, tranc = dy / dx, y = y0 + tranc;
            for (var i = x0 + 1; i < x1 - 1; i++)
            {
                if (Math.Abs(yt1 - yt0) > Math.Abs(xt1 - xt0))
                {
                    DrawVu((int)(y), i, 1 - (y - (int)y));
                    DrawVu((int)(y) + 1, i, 1 - (y - (int)y));
                }
                else
                {
                    DrawVu(i, (int)y, 1 - (y - (int)y));
                    DrawVu(i, (int)y + 1, 1 - (y - (int)y));
                }
                y += tranc;
            }
            pictureBox1.Image = bmp;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            gr.Clear(Color.White);
            pictureBox1.Image = null;
        }
    }
}
