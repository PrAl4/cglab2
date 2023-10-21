using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace pravednikLAB5Task2
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            gr.Clear(Color.White);
        }

        class line
        {
            public Point leftP;
            public Point rightP;
            public
            line(Point p1, Point p2)
            {
                leftP = p1;
                rightP = p2;
            }

        };

        static Bitmap bmp = new Bitmap(1000, 600);
        public Graphics gr = Graphics.FromImage(bmp);
        bool Mose_D = false;
        List<Point> points = new List<Point>();
        List<line> lines = new List<line>();
        double roughness;
        double depth;
        string roughness1;
        string depth1;
        void MU(object sen, MouseEventArgs e) { Mose_D = false; }
        void MD(object sen, MouseEventArgs e)
        {
            points.Add(new Point(e.X, e.Y));
        }

        void MouseClick(object sen, MouseEventArgs e)
        {
            if (Mose_D)
            {
                points.Add(e.Location);
                if (points.Count == 2)
                {
                    lines.Add(new line(points[0], points[1]));
                }
                gr.FillEllipse(blackBrush, e.X - 3, e.Y - 3, 7, 7);
            }
        }

        void DrawM()
        {
            depth = Double.Parse(depth1);
            roughness = Double.Parse(roughness1);
            for(int i = 1; i <= (int)depth; i++)
            {
                Random r = new Random();
                List<line> drawp = new List<line>();
                foreach(line x in lines)
                {
                    Point L = x.leftP;
                    Point R = x.rightP;
                    double j = Math.Abs(L.X - R.X) * Math.Abs(L.X - R.X) - Math.Abs(L.Y - R.Y) * Math.Abs(L.Y - R.Y);
                    j = Math.Sqrt(j);
                    int center = (L.X + R.X) / 2;
                    double height = (L.Y + R.Y) / 2 + (r.NextDouble() - 0.5) * roughness * j;
                    Point cen = new Point(center, (int)height);
                    drawp.Add(new line(L, cen));
                    drawp.Add(new line(cen, R));
                }
                lines = drawp;
            }
            foreach (line x in lines)
                Algorithm_Bras(x.leftP, x.rightP);
        }

        private void Draw_Click(object sender, EventArgs e)
        {
            DrawM();
        }

        private void Clear_Click(object sender, EventArgs e)
        {
            gr.Clear(Color.White);
            pictureBox1.Image = null;
            points.Clear();
            lines.Clear();
        }

        private void dpth_TextChanged(object sender, EventArgs e)
        {

            roughness1 = rghnss.Text;
        }

        private void rghnss_TextChanged(object sender, EventArgs e)
        {
            depth1 = dpth.Text;
        }

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
    }
}
