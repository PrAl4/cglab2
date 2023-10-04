using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlTypes;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using FastBitmaps;

namespace WindowsFormsApp3
{
    public partial class Task3 : Form
    {
        private Bitmap bitmap;
        private Graphics graphics;
        private Point start;
        private Point end;

        private int pointСount = 0;

        int STRETCH = 1;

        enum Type
        {
            NONE,
            BRESENHAM,
            WU
        }

        Type type = Type.BRESENHAM;
        public Task3()
        {
            InitializeComponent();
            STRETCH = with_bar.Value;
            bitmap = new Bitmap(pictureBox1.Width / STRETCH, pictureBox1.Height / STRETCH);
            pictureBox1.Image = bitmap;
            UpdateLabel();
        }

        //АЛГОРИТМ БРЕЗЕНХЕМА
        private void DrawLineBresenham(int x0, int x1, int y0, int y1)
        {
            label1.Text = $"Брезенхем {start.X}, {end.X}, {start.Y}, {end.Y}";
            int dx = Math.Abs(x1 - x0);
            int sx = x0 < x1 ? 1 : -1;
            int dy = -Math.Abs(y1 - y0);
            int sy = y0 < y1 ? 1 : -1;
            int error = dx + dy;

            while (true)
            {
                bitmap.SetPixel(x0, y0, Color.Black);
                if (x0 == x1 && y0 == y1) break;
                int e2 = 2 * error;
                if (e2 >= dy)
                {
                    if (x0 == x1) break;
                    error += dy;
                    x0 += sx;
                }
                if (e2 <= dx)
                {
                    if (y0 == y1) break;
                    error += dx;
                    y0 += sy;
                }
            }



            pictureBox1.Image = bitmapStretched();
        }

        //АЛГОРИТМ ВУ
        private void DrawLineWU(double x0, double x1, double y0, double y1)
        {
            label1.Text = $"ВУ {start.X}, {end.X}, {start.Y}, {end.Y}";
            bool steep = Math.Abs(y1 - y0) > Math.Abs(x1 - x0);

            if (steep)
            {
                Swap(ref x0, ref y0);
                Swap(ref x1, ref y1);
            }
            if (x0 > x1)
            {
                Swap(ref x0, ref x1);
                Swap(ref y0, ref y1);
            }

            double dx = x1 - x0;
            double dy = y1 - y0;
            double gradient = dy / dx;

            double xEnd = round(x0);
            double yEnd = y0 + gradient * (xEnd - x0);
            double xGap = rfpart(x0 + 0.5);
            double xPixel1 = xEnd;
            double yPixel1 = ipart(yEnd);

            if (steep)
            {
                plot(yPixel1, xPixel1, rfpart(yEnd) * xGap);
                plot(yPixel1 + 1, xPixel1, fpart(yEnd) * xGap);
            }
            else
            {
                plot(xPixel1, yPixel1, rfpart(yEnd) * xGap);
                plot(xPixel1, yPixel1 + 1, fpart(yEnd) * xGap);
            }
            double intery = yEnd + gradient;

            xEnd = round(x1);
            yEnd = y1 + gradient * (xEnd - x1);
            xGap = fpart(x1 + 0.5);
            double xPixel2 = xEnd;
            double yPixel2 = ipart(yEnd);
            if (steep)
            {
                plot(yPixel2, xPixel2, rfpart(yEnd) * xGap);
                plot(yPixel2 + 1, xPixel2, fpart(yEnd) * xGap);
            }
            else
            {
                plot(xPixel2, yPixel2, rfpart(yEnd) * xGap);
                plot(xPixel2, yPixel2 + 1, fpart(yEnd) * xGap);
            }

            if (steep)
            {
                for (int x = (int)(xPixel1 + 1); x <= xPixel2 - 1; x++)
                {
                    plot(ipart(intery), x, rfpart(intery));
                    plot(ipart(intery) + 1, x, fpart(intery));
                    intery += gradient;
                }
            }
            else
            {
                for (int x = (int)(xPixel1 + 1); x <= xPixel2 - 1; x++)
                {
                    plot(x, ipart(intery), rfpart(intery));
                    plot(x, ipart(intery) + 1, fpart(intery));
                    intery += gradient;
                }
            }

            pictureBox1.Image = bitmapStretched();
        }
        void Swap<T>(ref T first, ref T second)
        {
            T temp = first;
            first = second;
            second = temp;
        }

        private void plot(double x, double y, double c)
        {
            int alpha = (int)(c * 255);
            if (alpha > 255) alpha = 255;
            if (alpha < 0) alpha = 0;
            Color color = Color.FromArgb(alpha, Color.Black);
            if ((int)x >= 0 && (int)x < bitmap.Width && (int)y >= 0 && (int)y < bitmap.Width)
            {
                bitmap.SetPixel((int)x, (int)y, color);
            }
        }

        int ipart(double x) { return (int)x; }

        int round(double x) { return ipart(x + 0.5); }

        double fpart(double x)
        {
            if (x < 0) return (1 - (x - Math.Floor(x)));
            return (x - Math.Floor(x));
        }

        double rfpart(double x)
        {
            return 1 - fpart(x);
        }

        private void pictureBox1_MouseClick(object sender, MouseEventArgs e)
        {
            if (type != Type.NONE)
            {
                if (pointСount == 0)
                {
                    start = e.Location;
                    ++pointСount;
                }
                else
                {
                    end = e.Location;
                    switch (type)
                    {
                        case Type.BRESENHAM: DrawLineBresenham(start.X / STRETCH, end.X / STRETCH, start.Y / STRETCH, end.Y / STRETCH); break;
                        case Type.WU: DrawLineWU(start.X / STRETCH, end.X / STRETCH, start.Y / STRETCH, end.Y / STRETCH); break;
                    }
                    pointСount = 0;
                }
            }
        }

        private void button_alg1_Click(object sender, EventArgs e)
        {
            type = Type.BRESENHAM;
            UpdateLabel();
        }

        private void button_alg2_Click(object sender, EventArgs e)
        {
            type = Type.WU;
            UpdateLabel();
        }

        private void UpdateLabel()
        {
            if (pointСount == 0)
            {
                switch (type)
                {
                    case Type.NONE: label1.Text = "Выберите алгоритм"; break;
                    case Type.BRESENHAM: label1.Text = "Алгоритм Брезенхема"; break;
                    case Type.WU: label1.Text = "Алгоритм ВУ"; break;
                }
            }
            else
            {
                switch (type)
                {
                    case Type.NONE: label1.Text = "Ошибка!"; break;
                    case Type.BRESENHAM: label1.Text = "Построение (алгоритм Брезенхема)"; break;
                    case Type.WU: label1.Text = "Построение (алгоритм ВУ)"; break;
                }
            }
        }
        private Bitmap bitmapStretched()
        {
            int newWidth = (bitmap.Width * STRETCH);
            int newHeight = (bitmap.Height * STRETCH);
            Bitmap scaledBitmap = new Bitmap(newWidth, newHeight);
            using (Graphics g = Graphics.FromImage(scaledBitmap))
            {
                g.InterpolationMode = System.Drawing.Drawing2D.InterpolationMode.NearestNeighbor;
                g.DrawImage(bitmap, 0, 0, newWidth, newHeight);
            }
            return scaledBitmap;
        }
        private void with_bar_Scroll(object sender, EventArgs e)
        {
            STRETCH = with_bar.Value;
            bitmap = new Bitmap(pictureBox1.Width / STRETCH, pictureBox1.Height / STRETCH);
        }

        private void btn_clear_Click(object sender, EventArgs e)
        {
            bitmap = new Bitmap(pictureBox1.Width / STRETCH, pictureBox1.Height / STRETCH);
            pictureBox1.Image = bitmap;
        }

        private void Task3_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (e.CloseReason == CloseReason.UserClosing)
            {
                e.Cancel = true;
                Hide();

            }
        }

        private void Task3_Load(object sender, EventArgs e)
        {

        }

        private void Task3_Load_1(object sender, EventArgs e)
        {

        }
    }
}
