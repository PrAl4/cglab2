using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics.Eventing.Reader;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace lab7
{
    enum Polyhedron { TETRAHEDRON  = 0, HEXAHEDRON , OCTAHEDRON };
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
        Polyhedrons current_polyhedron;
        Projection cuurent_porojection;
        double v_XD;
        double v_YD;
        double v_ZD;
        double v_angle;
        bool flag_axis = false;

        void draw_polyhedron(Polyhedrons polyhedron_)
        {
            Pen pen = new Pen(Color.Black, 2);
            foreach(var edge in polyhedron_.edges)
            {
                foreach (var line in edge.lines)
                {
                    gr.DrawLine(pen, line.leftP.GetPoint(), line.rightP.GetPoint());
                }
            }
        }
        

        private void Download_from_file_Click(object sender, EventArgs e)
        {
            if(openFileDialog1.ShowDialog() == DialogResult.OK)
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

        private void Save_in_file_Click(object sender, EventArgs e)
        {
            if(saveFileDialog1.ShowDialog() == DialogResult.OK)
            {
                current_polyhedron.SaveToFile(saveFileDialog1.FileName);
            }
        }

        private void choose_polyhedron_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (choose_polyhedron.SelectedIndex == 0)
                current_polyhedron_type = Polyhedron.TETRAHEDRON;
            else if (choose_polyhedron.SelectedIndex == 1)
                current_polyhedron_type = Polyhedron.HEXAHEDRON;
            else if (choose_polyhedron.SelectedIndex == 2)
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

        void Draw_Axis()
        {

            List<Points> pnts = new List<Points>();
            if (!flag_axis){
                pnts.Add(new Points(0, 0, 0));
                pnts.Add(new Points(150, 0, 0));
                pnts.Add(new Points(0, 150, 0));
                pnts.Add(new Points(0, 0, 150));

                //Рисует ось Х
                gr.DrawLine(new Pen(new SolidBrush(Color.Blue), 2), pnts[0].GetPoint(), pnts[1].GetPoint());

                //Рисует ось У
                gr.DrawLine(new Pen(new SolidBrush(Color.Red), 2), pnts[0].GetPoint(), pnts[2].GetPoint());

                //Рисует ось Z
                gr.DrawLine(new Pen(new SolidBrush(Color.Green), 2), pnts[0].GetPoint(), pnts[3].GetPoint());
            }
            else
            {
                pnts.Add(new Points(0, 0, 0));
                pnts.Add(new Points(0, 0, 0));
                pnts.Add(new Points(0, 0, 0));
                pnts.Add(new Points(0, 0, 0));
                //Рисует ось Х
                gr.DrawLine(new Pen(new SolidBrush(Color.Blue), 2), pnts[0].GetPoint(), pnts[1].GetPoint());

                //Рисует ось У
                gr.DrawLine(new Pen(new SolidBrush(Color.Red), 2), pnts[0].GetPoint(), pnts[2].GetPoint());

                //Рисует ось Z
                gr.DrawLine(new Pen(new SolidBrush(Color.Green), 2), pnts[0].GetPoint(), pnts[3].GetPoint());
            }
                

        }

        private void choose_proection_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (choose_proection.SelectedIndex == 0)
                Points.proj = Projection.IZOMETRIC;
            else if (choose_proection.SelectedIndex == 1)
                Points.proj = Projection.AXONOMETRIC;
            else if (choose_proection.SelectedIndex == 2)
                Points.proj = Projection.PROSPECTIVE;
            else
                MessageBox.Show("Не выбрана ни одна проекция");
        }

        private void Scale_Click(object sender, EventArgs e)
        {
            scale(ref current_polyhedron, v_XD, v_YD, v_ZD);
            gr.Clear(Color.White);
            draw_polyhedron(current_polyhedron);
        }

        private void Shift_Click(object sender, EventArgs e)
        {
            shift(ref current_polyhedron, v_XD, v_YD, v_ZD);
            gr.Clear(Color.White);
            draw_polyhedron(current_polyhedron);
        }

        private void Rotation_Click(object sender, EventArgs e)
        {
            rotate(ref current_polyhedron, current_axis, v_angle);
            gr.Clear(Color.White);
            draw_polyhedron(current_polyhedron);
        }

        private void Clear_Click(object sender, EventArgs e)
        {
            gr.Clear(Color.White);
        }

        private void valueXDouble_TextChanged(object sender, EventArgs e)
        {
            v_XD = double.Parse(valueXDouble.Text);
        }

        private void ValueYDouble_TextChanged(object sender, EventArgs e)
        {
            v_YD = double.Parse(ValueYDouble.Text);
        }

        private void ValueZDouble_TextChanged(object sender, EventArgs e)
        {
            v_ZD = double.Parse(ValueZDouble.Text);
        }

        private void valueAngle_TextChanged(object sender, EventArgs e)
        {
            v_angle = double.Parse(valueAngle.Text);
        }

        private void draw_axiss_Click(object sender, EventArgs e)
        {
            Draw_Axis();
            flag_axis = !flag_axis;
        }
    }
}
