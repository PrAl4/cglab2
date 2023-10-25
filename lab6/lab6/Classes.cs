using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lab6
{
    //Класс точек 
    class Points
    {

        // Координаты
        double x;
        double y;
        double z;

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

    }
}
