using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lab6
{

    //Множество проекций
    public enum Projection { IZOMETRIC, PROSPECTIVE, AXONOMETRIC };

    //Класс точек 
    class Points
    {

        // Координаты
        double x;
        double y;
        double z;

        //Коэффициент отдаления от экрана ( его можно менять)
        const double koef = 0.001;

        //Объект множества проекций (по дефолту изометрия)
        public static Projection proj = Projection.IZOMETRIC;

        //Точка центра для перспективы
        public static PointF Center;

        //Матрицу изометрии брала отсюда
        //https://studfile.net/preview/903563/page:5/
        //Матрица изометрической проекции
        public static Matrix IzometricMatrix = new Matrix(4, 4).fillWithElements(Math.Sqrt(1/2), -Math.Sqrt(1/6), 0, 0, 0, Math.Sqrt(2/3), 0, 0, -Math.Sqrt(1/2), -Math.Sqrt(1/6), 0, 0, 0, 0, 0, 1);

        //Матрица аксонометрической проекции
        public static Matrix AxonometricMatrix = new Matrix(4, 4).fillWithElements();

        //Матрица перспективной проекции (взяла из лекции)
        public static Matrix ProspectiveMatrix = new Matrix(4, 4).fillWithElements(1, 0, 0, 0, 0, 1, 0, 0, 0, 0, koef, 0, 0, 0, 0, 1);

        //Конструктор с вещественными координатами
        public Points(double x, double y, double z)
        {
            this.x = x;
            this.y = y;
            this.z = z;
        }

        //Конструктор с целочисленными координатами
        public Points(int x, int y, int z)
        {
            this.x = x;
            this.y = y;
            this.z = z;
        }

        //Взятие целочисленной координаты
        public int getIntX { get => (int)x; set => x = value; }
        public int getIntY { get => (int)y; set => y = value; }
        public int getIntZ { get => (int)z; set => z = value; }

        //Взятие вещественной координаты
        public double getDoubleX { get => x; set => x = value; }
        public double getDoubleY { get => y; set => y = value; }
        public double getDoubleZ { get => z; set => z = value; }

        //Взятие два д точки на плоскости
        public PointF GetPoint()
        {
            PointF p = new PointF();
            if (proj == Projection.IZOMETRIC)
            {
                Matrix coord = new Matrix(1, 4).fillWithElements(getDoubleX, getDoubleY, getDoubleZ, 1);
                Matrix temp = new Matrix(4, 4).fillWithElements(1, 0, 0, 0, 0, 1, 0, 0, 0, 0, 0, 0, 0, 0, 0, 1) * IzometricMatrix * coord;
                p.X = Center.X + (float)temp[0, 0];
                p.Y = Center.Y + (float)temp[0, 1];
                return p;
            }
            else //(proj == Projection.PROSPECTIVE)
            {
                Matrix temp = new Matrix(1, 4).fillWithElements(getDoubleX, getDoubleY, getDoubleZ, 1) * ProspectiveMatrix * (1 / (koef * getDoubleZ + 1));
                p.X = Center.X + (float)temp[0, 0];
                p.Y = Center.Y + (float)temp[0, 1];
                return p;
            }
            //}
            //else
            //{

            //}
        }
    }

    //Класс ребер
    class Lines
    {
        //Точки ребра
        public Points leftP;
        public Points rightP;

        //Конструктор
        public Lines(Points leftP, Points rightP)
        {
            this.leftP = leftP;
            this.rightP = rightP;
        }

        //Взятие левой и правой точек
        public Points getLP { get => leftP; set => leftP = value; }
        public Points getRP { get => rightP; set => rightP = value; }

    }

    //Класс граней
    class  Edges
    {
        //Лист ребер, которые составляют грань
        List<Lines> edge;

        //Конструктор
        public Edges()
        {
            edge = new List<Lines>();
        }

        //
        public List<Lines> lines
        {
            get => edge;
            set => edge = value;
        }

        //Добавление ребра в грань
        public Edges addLine(Lines line)
        {
            edge.Add(line);
            return this;
        }

        //Поиск центра грани 
        public Points Center()
        {
            double x = 0;
            double y = 0;
            double z = 0;
            foreach(Lines line in edge)
            {
                x += line.rightP.getDoubleX;
                y += line.rightP.getDoubleY;
                z += line.rightP.getDoubleZ;
            }
            x /= edge.Count;
            y /= edge.Count;
            z /= edge.Count;
            return new Points(x, y, z);
        }
    }

    //Многогранник
    class Polyhedrons
    {
        //Лист граней
        List<Edges> polyhedrons;

        //Конструктор
        public Polyhedrons()
        {
            polyhedrons = new List<Edges>();
        }

        //Гет функция получения фигуры
        public List<Edges> edges
        {
            get => polyhedrons;
            set => polyhedrons = value;
        }

        //Добавить грань в фигуру 
        public Polyhedrons addEdge(Edges edge)
        {
            polyhedrons.Add(edge);
            return this;
        }

    }


    //Класс тэтраэрда
    class Tetrahedron : Polyhedrons
    {

    }

    //Класс гексаэдра
    class Hexahedron : Polyhedrons
    {

    }

    //Класс октаэдра
    class Octahedron : Polyhedrons
    {

    }

    //Класс, с помощью которого мы будем отображать фигуры
    class GetPolyhedrons
    {

        //Общая точка координат для построения
        public double GP = 300;

        //Функция построения тэтраэрда
        public Tetrahedron GetTetrahedron()
        {
            return new Tetrahedron();
        }

        //Функция построения гексаэдра
        public Hexahedron GetHexahedron()
        {
            return new Hexahedron();
        }

        //Функция построения октаэдра
        public Octahedron GetOctahedron()
        {
            return new Octahedron();
        }
    }

}
