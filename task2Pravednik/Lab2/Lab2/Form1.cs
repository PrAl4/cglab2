using Lab2.Properties;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;
using System.Windows.Forms.VisualStyles;

namespace Lab2
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            pictureBox1.Image = Properties.Resources.pic2;
            var bmp1 = pictureBox1.Image as Bitmap;
            Bitmap[] resul = task2(bmp1);
            pictureBox2.Image = resul[0];
            pictureBox3.Image = resul[1];
            pictureBox4.Image = resul[2];
            pictureBox1.Image = bmp1;
            chart1.Palette = ChartColorPalette.Fire;
            chart1.Titles.Add("Red");
            chart2.Palette = ChartColorPalette.Pastel;
            chart2.Titles.Add("Green");
            chart3.Palette = ChartColorPalette.Bright;
            chart3.Titles.Add("Blue");
            int mx = 0;
            int[] R = new int[256];
            int[] G = new int[256];
            int[] B = new int[256];
            for(int i = 0; i < bmp1.Width; i++)
            {
                for (int j = 0; j < bmp1.Height; j++)
                {
                    Color c = bmp1.GetPixel(i, j);
                    R[c.R]++;
                    G[c.G]++;
                    B[c.B]++;
                }
            }
            for (int i = 0; i < 256; i++)
            {
                if (R[i] > mx) mx = R[i];
                if (G[i] > mx) mx = G[i];
                if (B[i] > mx) mx = B[i];
            }
            Series s1 = chart1.Series.Add("Red");
            Series s2 = chart2.Series.Add("Green");
            Series s3 = chart3.Series.Add("Blue");
            for (int i = 0; i < 256; i++)
            {
                s1.Points.Add(R[i]);
                s2.Points.Add(G[i]);
                s3.Points.Add(B[i]);
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }


        static Bitmap[] task2(Bitmap bpm)
        {
            Bitmap[] res = new Bitmap[3]{
                new Bitmap(bpm.Width, bpm.Height),
                new Bitmap(bpm.Width, bpm.Height),
                new Bitmap(bpm.Width, bpm.Height)
            };
            for(int i = 0; i < bpm.Width; i++)
            {
                for(int j = 0; j < bpm.Height; j++)
                {
                    Color c = bpm.GetPixel(i, j);
                    res[0].SetPixel(i, j, Color.FromArgb(c.A, c.R, 0, 0));
                    res[1].SetPixel(i, j, Color.FromArgb(c.A, 0, c.G, 0));
                    res[2].SetPixel(i, j, Color.FromArgb(c.A, 0, 0, c.B));
                }
            }
            return res;
        }
    }
}
