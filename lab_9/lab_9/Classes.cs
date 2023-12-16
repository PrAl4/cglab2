﻿using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Net.NetworkInformation;
using System.Runtime.CompilerServices;
using System.Numerics;
using System.Drawing.Drawing2D;

namespace lab_9
{
    public enum Projection { IZOMETRIC, PROSPECTIVE, AXONOMETRIC, PARALLEL };

    //Класс точек 
    public class Points
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

        public static Size screen;
        public static double z_near;
        public static double z_far;
        public static double fov;

        //Матрицу изометрии брала отсюда
        //https://studfile.net/preview/903563/page:5/
        //Матрица изометрической проекции
        //public static Matrix IzometricMatrix = new Matrix(4, 4).fillWithElements(Math.Sqrt(1/2), -Math.Sqrt(1/6), 0, 0, 0, Math.Sqrt(2/3), 0, 0, -Math.Sqrt(1/2), -Math.Sqrt(1/6), 0, 0, 0, 0, 0, 1);
        //Эта матрица не работала, поэтому взяла другую:
        public static Matrix IzometricMatrix = new Matrix(3, 3).fillWithElements(Math.Sqrt(3), 0, -Math.Sqrt(3), 1, 2, 1, Math.Sqrt(2), -Math.Sqrt(2), Math.Sqrt(2)) * (1 / Math.Sqrt(6));


        //Матрица аксонометрической проекции (есть с этим сложности)
        public static Matrix AxonometricMatrix = new Matrix(4, 4).fillWithElements(1, 0, 0, 0, 0, 1, 0, 0, Math.Cos(Math.PI / 4), Math.Cos(Math.PI / 4), 0, 0, 0, 0, 0, 1);

        //Матрица перспективной проекции (взяла из лекции)
        public static Matrix ProspectiveMatrix = new Matrix(4, 4).fillWithElements(1, 0, 0, 0, 0, 1, 0, 0, 0, 0, 0, koef, 0, 0, 0, 1);

        //Матрица параллельной проекции
        static Matrix parallelMatrix;

        //Конструктор с вещественными координатами
        public Points(double x, double y, double z, double light = 1.0)
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

        public Points(Points p)
        {
            this.x = p.x;
            this.y = p.y;
            this.z = p.z;
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
                Matrix coord = new Matrix(3, 1).fillWithElements(getDoubleX, getDoubleY, getDoubleZ);
                Matrix temp = new Matrix(3, 3).fillWithElements(1, 0, 0, 0, 1, 0, 0, 0, 0, 0, 0, 1) * IzometricMatrix * coord;
                p.X = Center.X + (float)temp[0, 0];
                p.Y = Center.Y + (float)temp[1, 0] - 150;
                return p;
            }
            else if (proj == Projection.PROSPECTIVE)
            {
                Matrix temp = new Matrix(1, 4).fillWithElements(getDoubleX, getDoubleY, getDoubleZ, 1) * ProspectiveMatrix * (1 / (koef * getDoubleZ + 1));
                p.X = Center.X + (float)temp[0, 0] - 100;
                p.Y = Center.Y + (float)temp[0, 1] - 150;
                return p;
            }
            else if (proj == Projection.AXONOMETRIC)
            {
                Matrix temp = new Matrix(1, 4).fillWithElements(getDoubleX, getDoubleY, getDoubleZ, 1) * AxonometricMatrix;
                p.X = Center.X + (float)temp[0, 0];
                p.Y = Center.Y + (float)temp[0, 1] - 150;
                return p;
            }
            else
            {
                return new PointF(Center.X + (float)getDoubleX, Center.Y + (float)getDoubleY);
            }
        }

    }

    //Класс ребер
    public class Lines
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

        public Points get_left
        {
            get => leftP;
            set => leftP = value;
        }

        public Points get_right
        {
            get => rightP;
            set => rightP = value;
        }

        public Points get_coord()
        {
            return new Points(leftP.getDoubleX - rightP.getDoubleX, leftP.getDoubleY - rightP.getDoubleY, leftP.getDoubleZ - rightP.getDoubleZ);
        }

        public Points get_reverse_coord()
        {
            return new Points(rightP.getDoubleX - leftP.getDoubleX, rightP.getDoubleY - leftP.getDoubleY, rightP.getDoubleZ - leftP.getDoubleZ);
        }

    }

    //Класс граней
    public class Edges
    {
        //Лист ребер, которые составляют грань
        List<Lines> edge;
        public VectorNormals normals;

        //Конструктор
        public Edges()
        {
            edge = new List<Lines>();
            normals = new VectorNormals(0, 0, 0);
        }

        //
        public List<Lines> lines
        {
            get => edge;
            set => edge = value;
        }

        public Edges(IEnumerable<Lines> lines) : this()
        {
            this.edge.AddRange(lines);
        }

        //Добавление ребра в грань
        public Edges addLine(Lines line)
        {
            edge.Add(line);
            return this;
        }

        public Edges addLines(IEnumerable<Lines> lines)
        {
            this.edge.AddRange(lines);
            return this;
        }

        //Поиск центра грани 
        public Points Center()
        {
            double x = 0;
            double y = 0;
            double z = 0;
            foreach (Lines line in edge)
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

        public bool OnSide(VectorNormals v, double Dist, Points cen, Points veiw)
        {
            double scal1 = (veiw.getDoubleX + v.X) * v.X + (veiw.getDoubleY + v.Y) * v.Y + (veiw.getDoubleZ + v.Z) * v.Z + Dist;
            double scal2 = v.X * cen.getDoubleX + v.Y * cen.getDoubleY + v.Z * cen.getDoubleZ + Dist;
            return scal1 * scal2 > 0;
        }

        public void NormalsV(Points center)
        {
            VectorNormals v1 = new VectorNormals(edge[1].get_coord());
            VectorNormals v2 = new VectorNormals(edge[0].get_reverse_coord());
            normals = (v2 * v1).MadeNormalazed();
            double dist = -(edge[1].leftP.getDoubleX * normals.X + edge[1].leftP.getDoubleY * normals.Y + edge[1].leftP.getDoubleZ * normals.Z);
            if (OnSide(normals, dist, center, edge[1].leftP))
            {
                normals.X *= -1;
                normals.Y *= -1;
                normals.Z *= -1;
            }
        }

    }

    //Многогранник
    public class Polyhedrons
    {
        //Лист граней
        List<Edges> polyhedrons;
        public Points center;

        //Конструктор
        public Polyhedrons()
        {
            polyhedrons = new List<Edges>();
        }

        public Polyhedrons(IEnumerable<Edges> edges) : this()
        {
            this.polyhedrons.AddRange(edges);
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

        public void CenterPol()
        {
            double sx = 0.0;
            double sy = 0.0;
            double sz = 0.0;
            foreach (var ed in edges)
            {
                sx += ed.Center().getDoubleX;
                sy += ed.Center().getDoubleY;
                sz += ed.Center().getDoubleZ;
            }
            center = new Points(sx / edges.Count, sy / edges.Count, sz / edges.Count);
            for (int i = 0; i < edges.Count; i++)
            {
                edges[i].NormalsV(center);
            }
        }

        public Polyhedrons addEdges(IEnumerable<Edges> edges)
        {
            this.edges.AddRange(edges);
            return this;
        }

        //Название фигуры
        public virtual String PolyhedronName()
        {
            return "POLYHEDRON";
        }

        //Сохранение в файл 
        public void SaveToFile(string file_name)
        {
            File.WriteAllText(file_name, String.Empty);
            StreamWriter s_w = new StreamWriter(file_name);
            s_w.WriteLine(this.PolyhedronName());
            foreach (Edges edge in this.edges)
            {
                foreach (Lines line in edge.lines)
                {
                    s_w.WriteLine(line.leftP.getDoubleX + "," + line.leftP.getDoubleY + "," + line.leftP.getDoubleZ + ";" + line.rightP.getDoubleX + "," + line.rightP.getDoubleY + "," + line.rightP.getDoubleZ + " ");
                }
                s_w.WriteLine();
            }
            s_w.Close();
        }

        public static Polyhedrons ReadFromFile(string file_name)
        {
            Polyhedrons result = new Polyhedrons();
            StreamReader s_r = new StreamReader(file_name);
            List<Lines> lines = new List<Lines>();
            string name = s_r.ReadLine();
            if (name != null)
            {
                switch (name)
                {
                    case "TETRAHEDRON":
                        result = new Tetrahedron();
                        break;
                    case "HEXAHEDRON":
                        result = new Hexahedron();
                        break;
                    case "OCTAHEDRON":
                        result = new Octahedron();
                        break;
                    default:
                        throw new Exception("Error");
                }
            }
            name = s_r.ReadLine();
            while (name != null)
            {
                string[] line_parse = name.Split();
                foreach (string current_point in line_parse)
                {
                    if (current_point == "")
                        continue;
                    if (current_point == "n")
                        break;
                    string[] array_lines = current_point.Split(';');
                    var left_point = array_lines[0].Split(',');
                    var right_point = array_lines[1].Split(',');
                    lines.Add(new Lines(new Points(int.Parse(left_point[0]), int.Parse(left_point[1]), int.Parse(left_point[2])), new Points(int.Parse(right_point[0]), int.Parse(right_point[1]), int.Parse(right_point[2]))));
                }
                result.addEdge(new Edges(lines));
                lines = new List<Lines>();
                name = s_r.ReadLine();
            }
            s_r.Close();
            return result;
        }

    }


    //Класс тэтраэрда
    class Tetrahedron : Polyhedrons
    {
        public override String PolyhedronName()
        {
            return "TETRAHEDRON";
        }
    }

    //Класс гексаэдра
    class Hexahedron : Polyhedrons
    {
        public override String PolyhedronName()
        {
            return "HEXAHEDRON";
        }
    }

    //Класс октаэдра
    class Octahedron : Polyhedrons
    {
        public override String PolyhedronName()
        {
            return "OCTAHEDRON";
        }
    }

    //Класс, с помощью которого мы будем отображать фигуры
    class GetPolyhedrons
    {

        //Общая точка координат для построения
        public static double GP = 150;

        //
        public static Polyhedrons Get_Polyhedron(Polyhedron pol)
        {
            if (pol == Polyhedron.TETRAHEDRON)
            {
                return GetTetrahedron();
            }
            if (pol == Polyhedron.HEXAHEDRON)
            {
                return GetHexahedron();
            }
            if (pol == Polyhedron.OCTAHEDRON)
            {
                return GetOctahedron();
            }
            else
            {
                throw new Exception("Внимание: не выбрана ни одна фигура!");
            }
        }

        //Функция построения тэтраэрдач
        public static Tetrahedron GetTetrahedron()
        {
            Tetrahedron tetr = new Tetrahedron();

            //Тэтраэдр = 4 точки и 4 грани, соответственно
            Points p1 = new Points(0, 0, 0);
            Points p2 = new Points(GP, 0, GP);
            Points p3 = new Points(GP, GP, 0);
            Points p4 = new Points(0, GP, GP);

            //Добавляем грани все со всем (paint помог)
            tetr.addEdge(new Edges().addLine(new Lines(p1, p3)).addLine(new Lines(p3, p2)).addLine(new Lines(p2, p1)));
            tetr.addEdge(new Edges().addLine(new Lines(p1, p4)).addLine(new Lines(p4, p3)).addLine(new Lines(p3, p1)));
            tetr.addEdge(new Edges().addLine(new Lines(p1, p4)).addLine(new Lines(p4, p2)).addLine(new Lines(p2, p1)));
            tetr.addEdge(new Edges().addLine(new Lines(p2, p3)).addLine(new Lines(p3, p4)).addLine(new Lines(p4, p2)));

            return tetr;
        }

        //Функция построения гексаэдра
        public static Hexahedron GetHexahedron()
        {
            Hexahedron hexa = new Hexahedron();

            //8 точек, и 6 граней, соответственно
            Points p1 = new Points(0, 0, 0);
            Points p2 = new Points(GP, 0, 0);
            Points p3 = new Points(0, 0, GP);
            Points p4 = new Points(0, GP, 0);
            Points p5 = new Points(GP, 0, GP);
            Points p6 = new Points(GP, GP, 0);
            Points p7 = new Points(0, GP, GP);
            Points p8 = new Points(GP, GP, GP);

            //Сложные вычисления, где какую точку помещать, сделанные с помощью paint
            hexa.addEdge(new Edges().addLine(new Lines(p1, p2)).addLine(new Lines(p2, p5)).addLine(new Lines(p5, p3)).addLine(new Lines(p3, p1)));
            hexa.addEdge(new Edges().addLine(new Lines(p1, p2)).addLine(new Lines(p2, p6)).addLine(new Lines(p6, p4)).addLine(new Lines(p4, p1)));
            hexa.addEdge(new Edges().addLine(new Lines(p7, p4)).addLine(new Lines(p4, p1)).addLine(new Lines(p1, p3)).addLine(new Lines(p3, p7)));
            hexa.addEdge(new Edges().addLine(new Lines(p2, p5)).addLine(new Lines(p5, p8)).addLine(new Lines(p8, p6)).addLine(new Lines(p6, p2)));
            hexa.addEdge(new Edges().addLine(new Lines(p3, p5)).addLine(new Lines(p5, p8)).addLine(new Lines(p8, p7)).addLine(new Lines(p7, p3)));
            hexa.addEdge(new Edges().addLine(new Lines(p6, p8)).addLine(new Lines(p8, p7)).addLine(new Lines(p7, p4)).addLine(new Lines(p4, p6)));

            return hexa;
        }

        //Функция построения октаэдра
        public static Octahedron GetOctahedron()
        {
            Octahedron octa = new Octahedron();

            //Берем уже готовый гексаэдр (он же куб), чтобы не писать заново все точки
            Hexahedron h = GetHexahedron();

            //Берем каждый раз середину каждой грани гексаэдра
            Points p1 = h.edges[0].Center();
            Points p2 = h.edges[1].Center();
            Points p3 = h.edges[2].Center();
            Points p4 = h.edges[3].Center();
            Points p5 = h.edges[4].Center();
            Points p6 = h.edges[5].Center();

            //Paint делает дела
            octa.addEdge(new Edges().addLine(new Lines(p1, p5)).addLine(new Lines(p5, p4)).addLine(new Lines(p4, p1)));
            octa.addEdge(new Edges().addLine(new Lines(p4, p6)).addLine(new Lines(p6, p5)).addLine(new Lines(p5, p4)));
            octa.addEdge(new Edges().addLine(new Lines(p6, p3)).addLine(new Lines(p3, p5)).addLine(new Lines(p5, p6)));
            octa.addEdge(new Edges().addLine(new Lines(p3, p1)).addLine(new Lines(p1, p5)).addLine(new Lines(p5, p3)));
            octa.addEdge(new Edges().addLine(new Lines(p1, p2)).addLine(new Lines(p2, p4)).addLine(new Lines(p4, p1)));
            octa.addEdge(new Edges().addLine(new Lines(p4, p2)).addLine(new Lines(p2, p6)).addLine(new Lines(p6, p4)));
            octa.addEdge(new Edges().addLine(new Lines(p6, p2)).addLine(new Lines(p2, p3)).addLine(new Lines(p3, p6)));
            octa.addEdge(new Edges().addLine(new Lines(p3, p2)).addLine(new Lines(p2, p1)).addLine(new Lines(p1, p3)));

            return octa;
        }
    }

    public class VectorNormals
    {
        public double X;
        public double Y;
        public double Z;

        public VectorNormals(double x, double y, double z, bool is_normalized = false)
        {
            double normalizated = 0.0;
            if (is_normalized)
            {
                normalizated = Math.Sqrt(x * x + y * y + z * z);
            }
            else
            {
                normalizated = 1.0;
            }

            this.X = x / normalizated;
            this.Y = y / normalizated;
            this.Z = z / normalizated;
        }

        public VectorNormals(Points p, bool is_normalized = false)
        {
            this.X = p.getDoubleX;
            this.Y = p.getDoubleY;
            this.Z = p.getDoubleZ;
        }

        public VectorNormals MadeNormalazed()
        {
            double normalizated = Math.Sqrt(X * X + Y * Y + Z * Z);
            this.X /= normalizated;
            this.Y /= normalizated;
            this.Z /= normalizated;
            return this;
        }

        public double GetDoubleX
        {
            get => X;
            set => X = value;
        }

        public double GetDoubleY
        {
            get => Y;
            set => Y = value;
        }

        public double GetDoubleZ
        {
            get => Z;
            set => Z = value;
        }

        public static VectorNormals operator +(VectorNormals v1, VectorNormals v2)
        {
            return new VectorNormals(v1.X + v2.X, v1.Y + v2.Y, v1.Z + v2.Z);
        }

        public static VectorNormals operator -(VectorNormals v1, VectorNormals v2)
        {
            return new VectorNormals(v1.X - v2.X, v1.Y - v2.Y, v1.Z - v2.Z);
        }

        public static VectorNormals operator *(VectorNormals v1, VectorNormals v2)
        {
            return new VectorNormals(v1.Y * v2.Z - v1.Z * v2.Y, v1.Z * v2.X - v1.X * v2.Z, v1.X * v2.Y - v1.Y * v2.X);
        }

        public static VectorNormals operator *(VectorNormals v, double a)
        {
            return new VectorNormals(v.X * a, v.Y * a, v.Z * a);
        }

        public static double GetCos(VectorNormals v1, VectorNormals v2)
        {
            double scal = v1.GetDoubleX * v2.GetDoubleX + v1.GetDoubleY * v2.GetDoubleY + v1.GetDoubleZ * v2.GetDoubleZ;
            double l1 = Math.Sqrt(v1.GetDoubleX * v1.GetDoubleX + v1.GetDoubleY * v1.GetDoubleY + v1.GetDoubleZ * v1.GetDoubleZ);
            double l2 = Math.Sqrt(v2.GetDoubleX * v2.GetDoubleX + v2.GetDoubleY * v2.GetDoubleY + v2.GetDoubleZ * v2.GetDoubleZ);
            return scal / l1 / l2;
        }
    }

    public class Vertex : Points
    {
        public VectorNormals normals;

        public Vertex(Points p) : base(p) { }
        public Vertex(int x, int y, int z, double light = 1.0) : base(x, y, z, light) { }
    }

    public class Light
    {
        Points position;

        public Light(Points position)
        {
            this.position = position;
        }

        public Points GetPosition
        {
           get => position;
        }

        public void Moving(double shift_x, double shift_y, double shift_z)
        {
            position.getDoubleX += shift_x;
            position.getDoubleY += shift_y;
            position.getDoubleZ += shift_z;
        }
    }

    public class Lighting
    {
        public static double GetLight(Vertex ver, Light light)
        {
            var nornal = ver.normals;
            var ray = new VectorNormals(ver.getDoubleX = light.GetPosition.getDoubleX,
                ver.getDoubleY - light.GetPosition.getDoubleY,
                ver.getDoubleZ - light.GetPosition.getDoubleZ);
            return Math.Max(VectorNormals.GetCos(nornal, ray), 0.0);
        }

        public static double Intensens(double light)
        {
            return (light + 1) / 2;
        }

        public static VectorNormals Normals(List<Edges> edges, Polyhedrons polyh)
        {
            VectorNormals result = new VectorNormals(0, 0, 0);
            foreach(var edge in edges)
            {
                result.GetDoubleX += edge.normals.GetDoubleX;
                result.GetDoubleY += edge.normals.GetDoubleY;
                result.GetDoubleZ += edge.normals.GetDoubleZ;
            }
            result.GetDoubleX /= edges.Count;
            result.GetDoubleY /= edges.Count;
            result.GetDoubleZ /= edges.Count;
            return result;
        }

        public static void Lambert(Polyhedrons p, Light light)
        {
            Dictionary<Vertex, VectorNormals> norm = new Dictionary<Vertex, VectorNormals>();
            for(int i = 0; i < p.edges.Count; i++)
            {
                Edges edge = p.edges[i];
            }
        }
    }
}
