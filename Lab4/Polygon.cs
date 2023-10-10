using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static WindowsFormsApp1.Vertex;

namespace WindowsFormsApp1
{
    public class Polygon
    {
        private Vertex _v;
        private int _size;
        private void Resize()
        {
            if (_v == null) _size = 0;
            else
            {
                Vertex v = _v.Next;
                for (_size = 1; v != _v; v = v.Next, _size++) ;
            }
        }

        public Polygon()
        {
            _v = null;
            _size = 0;
        }
        public Polygon(Vertex v)
        {
            _v = v;
            Resize();
        }
        public Polygon(Polygon p)
        {
            _size = p._size;
            if (_size == 0) _v = null;
            else
            {
                _v = new Vertex(p.Point);
                for (int i = 1; i < _size; i++)
                {
                    p.Advance(ROTATION.CLOCKWISE);
                    _v = _v.Insert(new Vertex(p.Point));
                }
            }
            p.Advance(ROTATION.CLOCKWISE);
            _v = _v.Next;
        }

        public Point2D Point
        {
            get { return _v.Point; }
        }
        public int Size
        {
            get { return _size; }
        }
        public Vertex Front
        {
            get { return _v; }
        }
        public Edge Edge()
        {
            return new Edge(Point, _v.Next.Point);
        }

        public Vertex Next
        {
            get { return _v.Next; }
        }
        public Vertex Prev
        {
            get { return _v.Next; }
        }
        public Vertex Neighbor(ROTATION r)
        {
            return _v.Neighbor(r);
        }

        public Vertex Advance(ROTATION r)
        {
            _v = _v.Neighbor(r);
            return _v;
        }
        public Vertex SetV(Vertex v)
        {
            _v = v;
            return _v;
        }
        public Vertex Insert(Point2D p)
        {
            if (_size++ == 0) _v = new Vertex(p);
            else _v = _v.Insert(new Vertex(p));
            return _v;
        }
        public void Remove()
        {
            _v = (--_size == 0) ? null : _v.Prev;
        }
        public Polygon Split(Vertex v)
        {
            Vertex vp = _v.Split(v);
            Resize();
            return new Polygon(vp);
        }
        public Polygon RotateEdge()
        {
            if (_size >= 2)
            {
                var edited_edge = Edge().Rotation90();
                Point.x = edited_edge.origin.x;
                Point.y = edited_edge.origin.y;
                Next.Point.x = edited_edge.dest.x;
                Next.Point.y = edited_edge.dest.y;
            }
            return this;
        }
    }
}
