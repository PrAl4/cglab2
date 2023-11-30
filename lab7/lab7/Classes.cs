using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Net.NetworkInformation;
using System.Runtime.CompilerServices;

namespace lab7
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
        //public static Matrix IzometricMatrix = new Matrix(4, 4).fillWithElements(Math.Sqrt(1/2), -Math.Sqrt(1/6), 0, 0, 0, Math.Sqrt(2/3), 0, 0, -Math.Sqrt(1/2), -Math.Sqrt(1/6), 0, 0, 0, 0, 0, 1);
        //Эта матрица не работала, поэтому взяла другую:
        public static Matrix IzometricMatrix = new Matrix(3, 3).fillWithElements(Math.Sqrt(3), 0, -Math.Sqrt(3), 1, 2, 1, Math.Sqrt(2), -Math.Sqrt(2), Math.Sqrt(2)) * (1 / Math.Sqrt(6));


        //Матрица аксонометрической проекции (есть с этим сложности)
        public static Matrix AxonometricMatrix = new Matrix(4, 4).fillWithElements(1, 0, 0, 0, 0, 1, 0, 0, Math.Cos(Math.PI / 4), Math.Cos(Math.PI / 4), 0, 0, 0, 0, 0, 1);

        //Матрица перспективной проекции (взяла из лекции)
        public static Matrix ProspectiveMatrix = new Matrix(4, 4).fillWithElements(1, 0, 0, 0, 0, 1, 0, 0, 0, 0, 0, koef, 0, 0, 0, 1);

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
            else
            {
                Matrix temp = new Matrix(1, 4).fillWithElements(getDoubleX, getDoubleY, getDoubleZ, 1) * AxonometricMatrix;
                p.X = Center.X + (float)temp[0, 0];
                p.Y = Center.Y + (float)temp[0, 1] - 150;
                return p;
            }
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
    class Edges
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

        public Edges assLines(IEnumerable<Lines> lines)
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
                foreach(Lines line in edge.lines)
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
            if(name != null)
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
            while(name != null)
            {
                string[] line_parse = name.Split();
                foreach (string current_point in line_parse)
                {
                    if (current_point == "")
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

        public static Rotation getRotation(List<Points> center_line, int Div, int axis)
        {
            Rotation result = new Rotation();
            List<Points> center_ = center_line;
            int count = center_.Count();
            int divis = Div;
            double angle = (360.0 / count);
            result.addPoints(center_);
            for(int i = 1; i < divis; i++)
            {
                result.addPoints(Transformations.Rotate(center_, axis, angle * i));
            }
            for(int i = 0; i < divis; i++)
            {
                for(int j = 0; j < count; j++)
                {
                    int indx = i * count + j;
                    if(indx < divis * count)
                    {
                        int e = (indx + count) % result.Points.Count();
                        if((indx + 1) % count == 0)
                        {
                            result.add_edge(new Lines(result.Points[indx], result.Points[e]));
                        }
                        else
                        {
                            result.add_edge(new Lines(result.Points[indx], result.Points[indx + 1]));
                            result.add_edge(new Lines(result.Points[indx], result.Points[e]));
                            int temp_e = (indx + 1 + count) % result.Points.Count;
                            result.addEdge(new Edges().addLine(new Lines(result.Points[indx], result.Points[indx + 1])).addLine(new Lines(result.Points[indx + 1], result.Points[temp_e])).addLine(new Lines(result.Points[temp_e], result.Points[e])).addLine(new Lines(result.Points[e], result.Points[indx])));
                        }
                    }
                }
            }
            return result;
        }
    }

    class Rotation : Polyhedrons
    {
        List<Points> line_;
        List<Points> all_points;
        List<Lines> new_edges;
        Lines axis;
        int Divis;

        public Rotation()
        {
            all_points = new List<Points>();
            new_edges = new List<Lines>();
        }

        public Rotation(IEnumerable<Points> points) : this()
        {
            this.all_points.AddRange(points);
        }

        public Rotation(Lines axis_line, int Div, IEnumerable<Points> line) : this()
        {
            this.axis = axis_line;
            this.Divis = Div;
            this.line_.AddRange(line);
        }

        public List<Lines> get_edges
        {
            get => new_edges;
        }

        public Polyhedrons add_edge(Lines edge)
        {
            new_edges.Add(edge);
            return this;
        }

        public Rotation addPoint(Points p)
        {
            all_points.Add(p);
            return this;
        }

        public Rotation addPoints(IEnumerable<Points> points)
        {
            this.all_points.AddRange(points);
            return this;
        }

        public List<Points> Points
        {
            get => all_points;
        }

    }

    class Transformations
    {
        //
        public static double degreesToRadians(double angle)
        {
            return (Math.PI * angle) / 180.0;
        }

        //
        public static List<Points> Rotate(List<Points> center_lines, int axis, double angle)
        {
            List<Points> result;
            double sin_ = Math.Sin(degreesToRadians(angle));
            double cos_ = Math.Cos(degreesToRadians(angle));
            Matrix rot = new Matrix(0, 0);
            switch (axis)
            {
                case 0:
                    rot = new Matrix(4, 4).fillWithElements(1, 0, 0, 0, 0, cos_, -sin_, 0, 0, sin_, cos_, 0, 0, 0, 0, 1);
                    break;
                case 1:
                    rot = new Matrix(4, 4).fillWithElements(cos_, 0, sin_, 0, 0, 1, 0, 0, -sin_, 0, cos_, 0, 0, 0, 0, 1);
                    break;
                case 2:
                    rot = new Matrix(4, 4).fillWithElements(cos_, -sin_, 0, 0, sin_, cos_, 0, 0, 0, 0, 1, 0, 0, 0, 0, 1);
                    break;
            }
            result = transformPoints(rot, center_lines);
            return result;
        }

        //
        public static Points transformPoint(Matrix m, Points p)
        {
            var matrix_points = m * new Matrix(4, 1).fillWithElements(p.getDoubleX, p.getDoubleY, p.getDoubleZ, 1);
            return new Points(matrix_points[0, 0], matrix_points[1, 0], matrix_points[2, 0]);
        }

        //
        public static List<Points> transformPoints(Matrix m, List<Points> all_p)
        {
            List<Points> temp = all_p;
            List<Points> result = new List<Points>();
            foreach (var p in temp)
            {
                Points temp_p = transformPoint(m, p);
                result.Add(temp_p);
            }
            return result;
        }

    }


}
