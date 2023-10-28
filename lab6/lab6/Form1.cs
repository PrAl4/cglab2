using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Drawing.Drawing2D;

namespace lab6
{

    //Множество фигур
    public enum Polyhedron { TETRAHEDRON, HEXAHEDRON, OCTAHEDRON };

    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            Points.Center = new PointF(pictureBox1.Width / 2 , pictureBox1.Height / 2);
            gr = pictureBox1.CreateGraphics();
            gr.Clear(Color.White);
        }

        //Флаги оссей для проверки
        bool AxisX = false;
        bool AxisY = false;
        bool AxisZ = false;
        bool Axis = false;

        //Элемент множества фигур
        Polyhedron polyh;

        //Текущая фигуры
        Polyhedrons POLYHEN;

        //Тип проекции
        Projection projType;

        Graphics gr;


        //Кисти
        Pen Pen1 = new Pen(Color.Black, 3);

        //Лист точек для координатной оси
        List<Points> pnts = new List<Points>();


        //Кнопка отображения фигуры
        private void displayingShape_Click(object sender, EventArgs e)
        {
            //Проверка на то, чтобы хотя бы один вариант был выбран
            if(!Oct.Checked && !Geks.Checked && !Tetr.Checked)
            {
                throw new Exception("Ни одна фигура не выбрана!");
            }

            //Берем текущую фигуру в зависимости от типа 
            POLYHEN = GetPolyhedrons.Get_Polyhedron(polyh);
            Draw_Polyhedron(POLYHEN);
        }

        //Рисует ребро 
        void Draw_Line(Lines line)
        {
            //это не удаляйте, это для проверки отрисовки
            //MessageBox.Show(line.leftP.GetPoint().ToString());
           // MessageBox.Show(line.rightP.GetPoint().ToString());
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

        //Рисует координатную ось
        void Draw_Axis()
        {

            if (Axis)
            {

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

            if (!Axis)
            {
                pnts.Clear();
            }

        }

        //Кнопка отражения фигуру относительно выбраной координаты
        private void ReflectionShape_Click(object sender, EventArgs e)
        {
            Matrix res;

            if (AxisX)
            {
                res = new Matrix(4, 4).fillWithElements(1, 0, 0, 0, 0, 1, 0, 0, 0, 0, 0, -1, 0, 0, 0, 0, 1);

            }
            else if (AxisY)
            {
                res = new Matrix(4, 4).fillWithElements(1, 0, 0, 0, 0, -1, 0, 0, 0, 0, 0, 1, 0, 0, 0, 0, 1);

            }
            else if (AxisZ)
            {
                res = new Matrix(4, 4).fillWithElements(-1, 0, 0, 0, 0, 1, 0, 0, 0, 0, 0, 1, 0, 0, 0, 0, 1);
            }
            else
                throw new Exception("Ошибка отражения!");

            foreach(var pol in POLYHEN.edges)
            {
                foreach(var ln in pol.lines)
                {
                    //проходимся по всем линиям и отражаем точки по необходимой координате
                    Matrix temp = res * new Matrix(4, 1).fillWithElements(ln.leftP.getDoubleX, ln.leftP.getDoubleY, ln.leftP.getDoubleZ, 1);
                    ln.leftP = new Points(temp[0, 0], temp[1, 0], temp[2, 0]);
                    temp = res * new Matrix(4, 1).fillWithElements(ln.rightP.getDoubleX, ln.rightP.getDoubleY, ln.rightP.getDoubleZ, 1);
                    ln.rightP = new Points(temp[0, 0], temp[1, 0], temp[2, 0]);
                }
            }
            gr.Clear(Color.White);
            Draw_Polyhedron(POLYHEN);

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

        //Изменение выбора типа проекции
        private void projectionType_SelectedIndexChanged(object sender, EventArgs e)
        {
            string choice = projectionType.SelectedItem.ToString();
            if(choice == "Изометрия")
            {
                Points.proj = Projection.IZOMETRIC;
            }else if(choice == "Аксонометрия")
            {
                Points.proj = Projection.AXONOMETRIC;
            }else if(choice == "Перспектива")
            {
                Points.proj = Projection.PROSPECTIVE;
            }
        }

        //Показать координатную ось
        private void ShowAxis_Click(object sender, EventArgs e)
        {
            if (!Axis)
            {
                Axis = true;
                Draw_Axis();
            }
            else
            {
                Axis = false;
                Draw_Axis();
            }
        }

        //Очистить поле
        private void Clear_Click(object sender, EventArgs e)
        {
            gr.Clear(Color.White);
        }
    }
}
