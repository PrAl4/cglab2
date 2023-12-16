using lab_9;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace lab_9
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
            Points.proj = Projection.PROSPECTIVE;
            Size size = pictureBox1.Size;
        }

        Graphics gr;
        Polyhedron current_polyhedron_type;
        Axis current_axis;
        Polyhedrons current_polyhedron;
        GetPolyhedrons current_polyh;
        Projection cuurent_porojection;
        public static List<Points> list_points;
        List<Lines> temp_list_lines;

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

        Polyhedrons NonFaceFaces(Polyhedrons polyh_nonface)
        {
            VectorNormals view = new VectorNormals(-0.5, -1.5, 2);
            current_polyhedron.CenterPol();
            bool flag = true;
            if (current_polyhedron_type == Polyhedron.TETRAHEDRON)
            {
                polyh_nonface = new Tetrahedron();
            }
            else if (current_polyhedron_type == Polyhedron.HEXAHEDRON)
            {
                polyh_nonface = new Hexahedron();
            }
            else if (current_polyhedron_type == Polyhedron.OCTAHEDRON)
            {
                polyh_nonface = new Octahedron();
            }
            else
            {
                flag = false;
                MessageBox.Show("ни одна фигура не выбрана");
            }
            if (flag)
            {
                foreach (var edge in current_polyhedron.edges)
                {
                    edge.NormalsV(current_polyhedron.center);
                    double angle = (edge.normals.X * view.X + edge.normals.Y * view.Y + edge.normals.Z * view.Z) /
                        (Math.Sqrt(edge.normals.X * edge.normals.X + edge.normals.Y * edge.normals.Y + edge.normals.Z * edge.normals.Z) +
                        Math.Sqrt(view.X * view.X + view.Y * view.Y + view.Z * view.Z));
                    double arc = Math.Acos(angle);
                    if (arc * 180 / Math.PI < 90)
                    {
                        polyh_nonface.addEdge(edge);
                    }
                }
            }
            return polyh_nonface;
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

        private void Clear_Click(object sender, EventArgs e)
        {
            gr.Clear(Color.White);
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
            else if (choose_proj.SelectedIndex == 3)
            {
                Points.proj = Projection.PARALLEL;
            }
            else
                MessageBox.Show("Не выбрана ни одна проекция");
        }
    }
}
