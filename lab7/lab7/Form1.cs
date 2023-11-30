using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace lab7
{
    enum Polyhedron { TETRAHEDRON  = 0, HEXAHEDRON , OCTAHEDRON };
    public partial class Form1 : Form
    {
        List<Points> RootationPoints = new List<Points>();
        int division;

        public Form1()
        {
            InitializeComponent();
            gr.Clear(Color.White);
        }

        static Bitmap bmp = new Bitmap(880, 650);
        public Graphics gr = Graphics.FromImage(bmp);

        void Algorithm_Bras(Point p1, Point p2)
        {
            int x0 = (int)p1.X, y0 = (int)p1.Y, y1 = (int)p2.Y, x1 = (int)p2.X;
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

        

        private void Download_from_file_Click(object sender, EventArgs e)
        {

        }

        private void Save_in_file_Click(object sender, EventArgs e)
        {

        }

        private void choose_polyhedron_SelectedIndexChanged(object sender, EventArgs e)
        {
            switch()
        }

        private void choose_axis_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}
