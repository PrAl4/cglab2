using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms.VisualStyles;

namespace WindowsFormsApp1
{
    public  class Point2D : IComparable
    {
        public float x;
        public float y;

        public Point2D()
        {
            this.x = 0.0f;
            this.y = 0.0f;
        }

        public Point2D(float x, float y)
        {
            this.x = x;
            this.y = y;
        }

        public static Point2D operator +(Point2D lhs, Point2D rhs)
        {
            return new Point2D(lhs.x + rhs.x, lhs.y + rhs.y);
        }
        public static Point2D operator -(Point2D lhs, Point2D rhs)
        {
            return new Point2D(lhs.x - rhs.x, lhs.y - rhs.y);
        }
        public static float DotProduct(Point2D lhs, Point2D rhs)
        {
            return lhs.x * rhs.x + lhs.y * rhs.y;
        }
        public static Point2D operator *(Point2D lhs, float rhs)
        {
            return new Point2D(lhs.x * rhs, lhs.y * rhs);
        }
        public static Point2D operator *(float lhs, Point2D rhs)
        {
            return new Point2D(lhs * rhs.x, lhs * rhs.y);
        }
        public static bool operator <(Point2D lhs, Point2D rhs)
        {
            return (lhs.x < rhs.x) || ((lhs.x == rhs.x) && (lhs.y < rhs.y));
        }
        public static bool operator >(Point2D lhs, Point2D rhs)
        {
            return (lhs.x > rhs.x) || ((lhs.x == rhs.x) && (lhs.y > rhs.y));
        }
        public static bool operator ==(Point2D lhs, Point2D rhs)
        {
            return (lhs.x == rhs.x) && (lhs.y == rhs.y);
        }
        public static bool operator !=(Point2D lhs, Point2D rhs)
        {
            return !(lhs == rhs);
        }

        public double Lenth()
        {
            return Math.Sqrt(x * x + y * y);
        }
        public double Cos()
        {
            return x / Lenth();
        }
        public double Sin()
        {
            return y / Lenth();
        }

        public static double SinAB(Point2D a, Point2D b)
        {
            return a.Cos() * b.Sin() - a.Sin() * b.Cos();
        }
        public static double SignAB(Point2D a, Point2D b)
        {
            return a.x * b.y - a.y * b.x;
        }

        public ORIENTATION Classify(Point2D p0, Point2D p1)
        {
            Point2D p2 = this;
            Point2D a = p1 - p0;  //исходный вектор p0p1
            Point2D b = p2 - p0;  //вектор образованый текущей точной p0p2
            double sa = SignAB(a, b);
            if (sa > 0.0) return ORIENTATION.LEFT;
            if (sa < 0.0) return ORIENTATION.RIGHT;
            if ((a.x * b.x < 0.0) || (a.y * b.y < 0.0)) return ORIENTATION.BEHIND;
            if (a.Lenth() < b.Lenth()) return ORIENTATION.BEYOND;
            if (p2 == p0) return ORIENTATION.ORIGIN;
            if (p2 == p1) return ORIENTATION.DESTINITON;
            return ORIENTATION.BETWEEN;
        }

        public ORIENTATION Classify(Edge edge)
        {
            return Classify(edge.origin, edge.dest);
        }

        public double PolarAngle()
        {
            if (x == 0.0 && y == 0.0) return -1;
            if (x == 0.0) return (y > 0.0) ? 90 : 270;
            double theta = Math.Atan2(y, x); // в радианах
            theta *= 360 / (2 * Math.PI);    // перевод в градусы
            if (x > 0.0) return (y >= 0.0) ? theta : theta + 360.0; // 1 и 4 коор. четверти
            else return theta + 180;                                // 2 и 3 коор. четверти
        }

        public virtual double distance(Edge edge)
        {
            throw new NotImplementedException();
        }

        public PointF ToPointF()
        {
            return new PointF(x, y);
        }

        public int CompareTo(object o)
        {
            if (o == null) return 1;

            Point2D other = o as Point2D;
            if (this.y < other.y) return -1;
            else if (this.y == other.y && this.x < other.x) return -1;
            else if (this.y == other.y && this.x > other.x) return 1;
            else return 1;
        }

        public override bool Equals(object o)
        {
            if (o == null) return false;

            Point2D other = o as Point2D;
            return this.x == other.x && this.y == other.y;
        }

        public override int GetHashCode()
        {
            int hashCode = 1502939027;
            hashCode = hashCode * -1521134295 + x.GetHashCode();
            hashCode = hashCode * -1521134295 + y.GetHashCode();
            return hashCode;
        }

        public enum ORIENTATION
        {
            LEFT,           // слева
            RIGHT,          // справа
            BEYOND,         // впереди
            BEHIND,         // позади
            BETWEEN,        // мужду
            ORIGIN,         // начало
            DESTINITON,     // конец
        }
    }
}
