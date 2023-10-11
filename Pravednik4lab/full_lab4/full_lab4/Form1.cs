using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace full_lab4
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            gr.Clear(Color.White);
        }
        static Bitmap bmp = new Bitmap(1000, 400);

        public Graphics gr = Graphics.FromImage(bmp);

        List<Point> points = new List<Point>();
        List<Point> lines = new List<Point>();
        bool Mose_D = false;
        public int x0, y0;

        void MD(object sen, MouseEventArgs e)
        {
            points.Add(new Point(e.X, e.Y));
        }

        void MU(object sen, MouseEventArgs e) { Mose_D = false; }

        void MouseClick(object sen, MouseEventArgs e)
        {
            if(Mose_D)
                points.Add(new Point(e.X, e.Y));
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

        private void Clear_Click(object sender, EventArgs e)
        {
            gr.Clear(Color.White);
            pictureBox1.Image = null;
            points.Clear();
            lines.Clear();
        }

        private void line_Click(object sender, EventArgs e)
        {
            if (points.Count == 2)
            {
                Algorithm_Bras(points[0], points[1]);
                lines.Add(points[0]);
                lines.Add(points[1]);
                points.Clear();
            }
            else if(points.Count < 2)
            {
               MessageBox.Show("Точек недостаточно для построения линии.");
            }else if(points.Count > 2)
            {
                MessageBox.Show("Точек больше чем две. Попробуйте нарисовать полигон");
            }
        }

        private void Draw_Click(object sender, EventArgs e)
        {
            if (points.Count > 2)
            {
                for (int i = 0; i < points.Count() - 1; i++)
                {
                    Algorithm_Bras(points[i], points[i + 1]);
                    lines.Add(points[i]);
                    lines.Add(points[i+1]);
                }
                if (points[0] != points[points.Count - 1])
                    Algorithm_Bras(points[points.Count - 1], points[0]);
                points.Clear();
            }
            else if (points.Count == 2)
            {
                MessageBox.Show("Точек недостаточно для построения полигона. Попробуйте построить линию");
            }else if (points.Count < 2)
            {
                MessageBox.Show("Точек недостаточно для построения линии или полигона.");
            }
        }

        void InPolygon1()
        {
            int j = lines.Count - 1;
            bool flag = false;
            for(int i = 0; i < lines.Count(); i++)
            {
                if (lines[i].Y < points[0].Y && lines[j].Y >= points[0].Y
                    || lines[j].Y < points[0].Y && lines[i].Y >= points[0].Y)
                {
                    if (lines[i].X + (points[0].Y - lines[i].Y) / (lines[j].Y - lines[i].Y)
                        * (lines[j].X - lines[i].X) < points[0].X)
                    {
                        flag = !flag;
                    }
                }
                j = i;
            }
            if (flag)
            {
                MessageBox.Show("Точка принадлежит невыпуклому многоугольнику");
            }
            else
            {
                MessageBox.Show("Точка не принадлежит невыпуклому многоугольнику");
            }
        }

        void InPolygon2()
        {
            int j = lines.Count - 1;
            bool flag = false;
            for (int i = 0; i < lines.Count(); i++)
            {
                if (lines[i].Y < points[0].Y && lines[j].Y >= points[0].Y
                    || lines[j].Y < points[0].Y && lines[i].Y >= points[0].Y)
                {
                    if (lines[i].X + (points[0].Y - lines[i].Y) / (lines[j].Y - lines[i].Y)
                        * (lines[j].X - lines[i].X) < points[0].X)
                    {
                        flag = !flag;
                    }
                }
                j = i;
            }
            if (flag)
            {
                MessageBox.Show("Точка принадлежит выпуклому многоугольнику");
            }
            else
            {
                MessageBox.Show("Точка не принадлежит выпуклому многоугольнику");
            }
        }

        void Position_Relative_Line()
        {
            if (((points[0].X - lines[0].X) * (lines[1].Y - lines[0].Y) -
                (points[0].Y - lines[0].Y) * (lines[1].X - lines[0].X)) > 0) {
                MessageBox.Show("Слева");
            }else if (((points[0].X - lines[0].X) * (lines[1].Y - lines[0].Y) -
                (points[0].Y - lines[0].Y) * (lines[1].X - lines[0].X)) < 0)
            {
                MessageBox.Show("Справа");
            }
            else
            {
                MessageBox.Show("На линии");
            }
        }

        private void TestPoint_Click(object sender, EventArgs e)
        {
            if (radioButton1.Checked)
            {
                InPolygon2();
                points.Clear();
            } 
            if (radioButton2.Checked)
            {
                InPolygon1();
                points.Clear();
            }
            if (radioButton3.Checked)
            {
                Position_Relative_Line();
                points.Clear();
            }
        }
    }
}
