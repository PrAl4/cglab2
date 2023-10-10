using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WindowsFormsApp1
{
    public class Vertex : Point2D
    {
        protected Vertex _next;
        protected Vertex _prev;

        public Vertex() : base()
        {
            _next = this;
            _prev = this;
        }
        public Vertex(float x, float y) : base(x, y)
        {
            _next = this;
            _prev = this;
        }
        public Vertex(Point2D p) : base(p.x, p.y)
        {
            _next = this;
            _prev = this;
        }

        public Vertex Next
        {
            get { return _next; }
        }
        public Vertex Prev
        {
            get { return _prev; }
        }
        public Point2D Point
        {
            get { return this; }
        }

        public Vertex Neighbor(ROTATION r)
        {
            return r == ROTATION.CLOCKWISE ? Next : Prev;
        }
        public Vertex Insert(Vertex v)
        {
            Vertex tmp = _next;
            v._next = tmp;
            v._prev = this;
            this._next = v;
            tmp._prev = v;
            return v;
        }
        public Vertex Remove()
        {
            _prev._next = _next;
            _next._prev = _prev;
            _next = _prev = this;
            return this;
        }
        public void Splise(Vertex b)
        {
            Vertex a = this;
            Vertex an = a._next;
            Vertex bn = b._next;
            a._next = bn;
            b._next = an;
            an._prev = b;
            bn._prev = a;
        }
        public Vertex Split(Vertex v)
        {
            Vertex vp = v._prev.Insert(new Vertex(v.Point));
            Insert(new Vertex(Point));

            Splise(vp);
            return vp;
        }
        public enum ROTATION
        {
            CLOCKWISE,
            COUNTER_CLOCKWISE
        }
    }
}
