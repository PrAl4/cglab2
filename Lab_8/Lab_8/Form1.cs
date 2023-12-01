using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Net.NetworkInformation;
using System.Runtime.CompilerServices;
using System.Windows.Forms;

namespace Lab_8
{
    enum Polyhedron { TETRAHEDRON = 0, HEXAHEDRON, OCTAHEDRON };
    enum Axis { X = 0, Y, Z };
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            Points.Center = new PointF(pictureBox1.Width / 2, pictureBox1.Height / 2);
            gr = pictureBox1.CreateGraphics();
            gr.Clear(Color.White);
        }

        Graphics gr;
        Polyhedron current_polyhedron_type;
        Axis current_axis;
        Polyhedrons current_polyhedron;
        GetPolyhedrons current_polyh;
        Projection cuurent_porojection;

        void draw_polyhedron(Polyhedrons polyhedron_)
        {
            Pen pen = new Pen(Color.Black, 2);
            foreach (var edge in polyhedron_.edges)
            {
                foreach (var line in edge.lines)
                {
                    gr.DrawLine(pen, line.leftP.GetPoint(), line.rightP.GetPoint());
                }
            }
        }

        private void draw_polyh_Click(object sender, EventArgs e)
        {
            if (current_polyhedron_type == Polyhedron.HEXAHEDRON || current_polyhedron_type == Polyhedron.TETRAHEDRON || current_polyhedron_type == Polyhedron.OCTAHEDRON)
            {
                current_polyhedron = GetPolyhedrons.Get_Polyhedron(current_polyhedron_type);
                draw_polyhedron(current_polyhedron);
            }
            else
                MessageBox.Show("Ни одна фигуры не выбрана");
        }

        private void load_polyn_Click(object sender, EventArgs e)
        {
            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                string file_name = openFileDialog1.FileName;
                if (File.Exists(file_name))
                {
                    current_polyhedron = Polyhedrons.ReadFromFile(file_name);
                    //where we must draw polyhedron
                    gr.Clear(Color.White);
                    draw_polyhedron(current_polyhedron);
                }
            }
        }

        private void save_polyh_Click(object sender, EventArgs e)
        {
            if (saveFileDialog1.ShowDialog() == DialogResult.OK)
            {
                current_polyhedron.SaveToFile(saveFileDialog1.FileName);
            }
        }

        private void Clear_but_Click(object sender, EventArgs e)
        {
            gr.Clear(Color.White);
        }

        private void choose_polyh_SelectedIndexChanged(object sender, EventArgs e)
        {

            if (choose_polyh.SelectedIndex == 0)
                current_polyhedron_type = Polyhedron.TETRAHEDRON;
            else if (choose_polyh.SelectedIndex == 1)
                current_polyhedron_type = Polyhedron.HEXAHEDRON;
            else if (choose_polyh.SelectedIndex == 2)
                current_polyhedron_type = Polyhedron.OCTAHEDRON;
            else
                MessageBox.Show("Не выбрана ни одна фигура");
        }

        private void choose_axis_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (choose_axis.SelectedIndex == 0)
                current_axis = Axis.X;
            else if (choose_axis.SelectedIndex == 1)
                current_axis = Axis.Y;
            else if (choose_axis.SelectedIndex == 2)
                current_axis = Axis.Z;
            else
                MessageBox.Show("Не выбрана ни одна ось");
        }

        private void choose_proj_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (choose_proj.SelectedIndex == 0)
                Points.proj = Projection.IZOMETRIC;
            else if (choose_proj.SelectedIndex == 1)
                Points.proj = Projection.AXONOMETRIC;
            else if (choose_proj.SelectedIndex == 2)
                Points.proj = Projection.PROSPECTIVE;
            else
                MessageBox.Show("Не выбрана ни одна проекция");
        }
    }
}
