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
        Camera cam = new Camera();

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
                    //строим вектор нормали для каждой грани
                    VectorNormals vn = new VectorNormals(cam.PointView(edge.Center())).MadeNormalazed();
                    //
                    VectorNormals v_first_line = new VectorNormals(edge.lines.First().get_coord());
                    VectorNormals v_last_line = new VectorNormals(edge.lines.Last().get_reverse_coord());
                    VectorNormals v_norm = v_first_line * v_last_line;
                    Points p_view = new Points(v_norm.X, v_norm.Y, v_norm.Z);
                    VectorNormals v_view_normal = new VectorNormals(cam.PointView(p_view)).MadeNormalazed();
                    double mult_scalar = v_view_normal.X * vn.X + v_view_normal.Y * vn.Y + v_view_normal.Z * vn.Z;

                    if (mult_scalar > 0)
                    {
                        polyh_nonface.addEdge(edge);
                    }
                }
            }
            return polyh_nonface;
        }

        public void draw_camera()
        {
            Pen pen1 = new Pen(Color.Blue, 2);
            Pen pen2 = new Pen(Color.Red, 2);
            Pen pen3 = new Pen(Color.Green, 2);

            gr.DrawLine(pen1, cam.position.GetPoint(), (new Points(cam.position.getDoubleX + cam.direction.X * 150, cam.position.getDoubleY + cam.direction.Y * 150, cam.position.getDoubleZ + cam.direction.Z * 150)).GetPoint());
            gr.DrawLine(pen2, cam.position.GetPoint(), (new Points(cam.position.getDoubleX + cam.right.X * 150, cam.position.getDoubleY + cam.right.Y * 150, cam.position.getDoubleZ + cam.right.Z * 150)).GetPoint());
            gr.DrawLine(pen3, cam.position.GetPoint(), (new Points(cam.position.getDoubleX + cam.up.X * 150, cam.position.getDoubleY + cam.up.Y * 150, cam.position.getDoubleZ + cam.up.Z * 150)).GetPoint());
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
            else if(choose_proj.SelectedIndex == 3)
            {
                Points.proj = Projection.PARALLEL;
            }else
                MessageBox.Show("Не выбрана ни одна проекция");
        }

        double r = 0.0;
        double u = 0.0;
        double b = 0.0;
        private void LeftRight_Scroll(object sender, EventArgs e)
        {
            r = LeftRight.Value;
            cam.moving(r, u, b);
        }


        private void UpDown_Scroll(object sender, EventArgs e)
        {
            u = UpDown.Value;
            cam.moving(r, u, b);
        }

        private void BackForward_Scroll(object sender, EventArgs e)
        {
            b = BackForward.Value;
            cam.moving(r, u, b);
        }

        private void NonFaceButton_Click(object sender, EventArgs e)
        {
            Polyhedrons p = NonFaceFaces(current_polyhedron);
            gr.Clear(Color.White);
            draw_polyhedron(p);
            draw_camera();
            MessageBox.Show(r.ToString() + "  " + u.ToString() + "  " + b.ToString());
        }
    }
}
