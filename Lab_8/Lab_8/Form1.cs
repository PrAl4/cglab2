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
using System.Reflection;
using System.Numerics;

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
            Points.proj = Projection.PROSPECTIVE;
            Size size = pictureBox1.Size;
            Points.setProjection(size, 1, 100, 45);
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

        public void drawView(VectorNormals v,  Points center)
        {
            Pen pen = new Pen(Color.Red, 2);
            gr.DrawLine(pen, new Points(v.X, v.Y, v.Z).GetPoint(), center.GetPoint());
        }

        Polyhedrons NonFaceFaces(Polyhedrons polyh_nonface)
        {
            VectorNormals view = new VectorNormals(-1, -1.05, 10);
            current_polyhedron.CenterPol();
            drawView(view, current_polyhedron.center);
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
                    double angle = (edge.normals.X * view.X + edge.normals.Y * view.Y + edge.normals.Z * view.Z)/
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

        void rotate(ref Polyhedrons polyh, Axis ax, double angle)
        {
            angle = Math.PI * angle / 180.0;
            Matrix rotate_ = new Matrix(0, 0);
            if (ax == Axis.X)
            {
                rotate_ = new Matrix(4, 4).fillWithElements(1, 0, 0, 0, 0, Math.Cos(angle), -Math.Sin(angle), 0, 0, Math.Sin(angle), Math.Cos(angle), 0, 0, 0, 0, 1);
            }
            else if (ax == Axis.Y)
            {
                rotate_ = new Matrix(4, 4).fillWithElements(Math.Cos(angle), 0, Math.Sin(angle), 0, 0, 1, 0, 0, -Math.Sin(angle), 0, Math.Cos(angle), 0, 0, 0, 0, 1);
            }
            else if (ax == Axis.Z)
            {
                rotate_ = new Matrix(4, 4).fillWithElements(Math.Cos(angle), -Math.Sin(angle), 0, 0, Math.Sin(angle), Math.Cos(angle), 0, 0, 0, 0, 1, 0, 0, 0, 0, 1);
            }
            foreach (var edge in polyh.edges)
            {
                foreach (var line in edge.lines)
                {
                    var p1 = line.leftP;
                    var p2 = line.rightP;
                    var temp_p1 = rotate_ * new Matrix(4, 1).fillWithElements(p1.getDoubleX, p1.getDoubleY, p1.getDoubleZ, 1);
                    var temp_p2 = rotate_ * new Matrix(4, 1).fillWithElements(p2.getDoubleX, p2.getDoubleY, p2.getDoubleZ, 1);
                    line.leftP = new Points(temp_p1[0, 0], temp_p1[1, 0], temp_p1[2, 0]);
                    line.rightP = new Points(temp_p2[0, 0], temp_p2[1, 0], temp_p2[2, 0]);
                }
            }
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
            else if (choose_proj.SelectedIndex == 3)
            {
                Points.proj = Projection.PARALLEL;
            }
            else
                MessageBox.Show("Не выбрана ни одна проекция");
        }

        private void Rotation_Click(object sender, EventArgs e)
        {
            gr.Clear(Color.White);
            rotate(ref current_polyhedron, current_axis, 45);
            //Polyhedrons p = NonFaceFaces(current_polyhedron);
            draw_polyhedron(current_polyhedron);
        }

        private void NonFaceButton_Click(object sender, EventArgs e)
        {
            gr.Clear(Color.White);
            Polyhedrons p = NonFaceFaces(current_polyhedron);
            draw_polyhedron(p);
        }
    }
}
