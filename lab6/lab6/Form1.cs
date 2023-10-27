using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace lab6
{

    //Множество фигур
    public enum Polyhedron { TETRAHEDRON, HEXAHEDRON, OCTAHEDRON };

    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            gr.Clear(Color.White);
        }

        //Флаги оссей для проверки
        bool AxisX = false;
        bool AxisY = false;
        bool AxisZ = false;

        //Элемент множества фигур
        Polyhedron polyh;

        //Текущая фигуры
        Polyhedrons POLYHEN;

        //Экран отображения
        static Bitmap bmp = new Bitmap(1050, 680);
        public Graphics gr = Graphics.FromImage(bmp);

        //Кисти
        SolidBrush blackBrush = new SolidBrush(Color.Black);
        Pen Pen1 = new Pen(Color.Black, 1);


        //Кнопка отображения фигуры
        private void displayingShape_Click(object sender, EventArgs e)
        {
            //Проверка на то, чтобы хотя бы один вариант был выбран
            if(!Oct.Checked && !Geks.Checked && !Tetr.Checked)
            {
                throw new Exception("Ни одна фигура не выбрана!");
            }

        }

        //Рисует ребро 
        void Draw_Line(Lines line)
        {
            gr.DrawLine(Pen1, line.leftP.GetPoint(), line.rightP.GetPoint());
        }

        //Рисует грань 
        void Draw_Edge(Edges edge)
        {
            foreach(Lines line in edge.lines)
            {
                Draw_Line(line);
            }
        }

        //Рисует фигуру
        void Draw_Polyhedron(Polyhedrons p)
        {
            foreach(Edges edge in p.edges)
            {
                Draw_Edge(edge);
            }
        }

        //Кнопка отражения фигуру относительно выбраной координаты
        private void ReflectionShape_Click(object sender, EventArgs e)
        {

        }

        //Кнопка масштабирования фигуры
        private void sclaing_Click(object sender, EventArgs e)
        {

        }

        //нопка вращения фигуры относительно оси, проходящей через центр и выбранной координаты
        private void RotationAxis_Click(object sender, EventArgs e)
        {

        }

        //Вращение относительно произвольной и выбранной координаты
        private void RotationArbitary_Click(object sender, EventArgs e)
        {

        }

        //Изминение выбора тетраэдра
        private void Tetr_CheckedChanged(object sender, EventArgs e)
        {
            polyh = Polyhedron.TETRAHEDRON;
        }

        //Извинение выбора гексаэдра
        private void Geks_CheckedChanged(object sender, EventArgs e)
        {
            polyh = Polyhedron.HEXAHEDRON;
        }

        //Изменение выбора октаэдра
        private void Oct_CheckedChanged(object sender, EventArgs e)
        {
            polyh = Polyhedron.OCTAHEDRON;
        }

        //Проверка на выбранную ось
        private void coordinates_SelectedIndexChanged(object sender, EventArgs e)
        {
            string choice = coordinates.SelectedItem.ToString();
            if (choice == "X")
            {
                AxisX = true;
                AxisY = false;
                AxisZ = false;
            }else if(choice == "Y")
            {
                AxisX = false;
                AxisY = true;
                AxisZ = false;
            }else if(choice == "Z")
            {
                AxisX = false;
                AxisY = false;
                AxisZ = true;
            }
            
        }
    }
}
