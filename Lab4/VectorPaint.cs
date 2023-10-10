using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;

namespace WindowsFormsApp1
{
  
    public partial class VectorPaint : UserControl
    {
        private List<Polygon> _polygons = new List<Polygon>();  //общее кол-во полигонов на холсте
        private Polygon cur_edit_polygon = null;                //текущий полигон с котором выполнятется поворот, масштабировани
        private int count_vertex = 0;                           //кол-во вершин
        private Bitmap _bitmap;
        private Graphics _graphics;

        private Pen pen_edge = new Pen(Color.Green, 3f);
        private Brush brush_vertes = new SolidBrush(Color.Black);
        private STATE g_state = STATE.NONE;
       
        public VectorPaint()
        {

            InitializeComponent();
            _bitmap = new Bitmap(canvas12.Width, canvas12.Height);
            _graphics = Graphics.FromImage(_bitmap);
            _graphics.Clear(Color.White);
            canvas12.Image = _bitmap;

            UpdateUI();

        }

        private void btn_add_polygon_Click(object sender, System.EventArgs e)
        {
            if (g_state == STATE.NONE)
            {
                g_state = STATE.ADDING_POLYGON;
                _polygons.Add(new Polygon());
                UpdateUI();
            }
            else status.Text = "Ошибка добавления полигона";

        }

        private void btn_apply_Click(object sender, System.EventArgs e)
        {
            if (g_state == STATE.ADDING_POLYGON)
            {
                g_state = STATE.NONE;
                if (_polygons.Last().Size == 0) _polygons.Remove(_polygons.Last());
                ReCount();
                UpdateUI();
            }
            else status.Text = "Ошибка приминения полигона";
        }

        private void btn_clear_Click(object sender, System.EventArgs e)
        {
            g_state = STATE.NONE;
            ClearPoligons();
            UpdateUI();
        }

        private enum STATE
        {
            NONE,                   // IDLE
            ADDING_POLYGON,         // состояние добавления полигона
            EDITING_POLYGON,        // состояние изменения полигона
            MOVE_POLYGON,           // состояние перемещение полигона
            ROTATE_POLYGON,         // состояние вращение полигона
            SCALE_POLYGON,          // состояние масштабирование полигона
        }

        private void UpdateUI()
        {
            ClearCanvas();
            switch (g_state)
            {
                case STATE.NONE: canvas12.Select(); break;
                case STATE.ADDING_POLYGON: btn_add_polygon.Select(); break;
            }
            cur_info.Text = "полигонов: " + _polygons.Count + " вершин: " + count_vertex;

            if (_polygons.Count > 0) DrawAll();
        }

        private void ClearCanvas()
        {
            _graphics.Clear(Color.White);
            canvas12.Invalidate();
        }

        private void ClearPoligons()
        {
            _polygons.Clear();
            ReCount();
        }

        private void DrawAll()
        {
            foreach (var polygon in _polygons)
            {
                if (polygon.Size == 1)
                {
                    DrawVertexes(polygon);
                }
                if (polygon.Size > 1)
                {
                    DrawEdges(polygon);
                    DrawVertexes(polygon);
                }
            }
            canvas12.Image = _bitmap;
            canvas12.Invalidate();
        }

        private void DrawVertexes(Polygon polygon)
        {
            Vertex start = polygon.Front;

            _graphics.FillEllipse(brush_vertes, polygon.Front.x - with_bar.Value / 2, polygon.Front.y - with_bar.Value / 2, with_bar.Value, with_bar.Value);
            polygon.Advance(Vertex.ROTATION.CLOCKWISE);

            while (polygon.Front != start)
            {
                _graphics.FillEllipse(brush_vertes, polygon.Front.x - with_bar.Value / 2, polygon.Front.y - with_bar.Value / 2, with_bar.Value, with_bar.Value);
                polygon.Advance(Vertex.ROTATION.CLOCKWISE);
            }
        }

        private void DrawEdges(Polygon polygon)
        {
            Vertex start = polygon.Front;

            _graphics.DrawLine(pen_edge, start.x, start.y, start.Next.x, start.Next.y);
            polygon.Advance(Vertex.ROTATION.CLOCKWISE);

            while (polygon.Front != start)
            {
                _graphics.DrawLine(pen_edge, polygon.Front.x, polygon.Front.y, polygon.Front.Next.x, polygon.Front.Next.y);
                polygon.Advance(Vertex.ROTATION.CLOCKWISE);
            }
        }

        private void btn_color_Click(object sender, System.EventArgs e)
        {
            Button button = (sender as Button);
            if (colorDialog1.ShowDialog() == DialogResult.Cancel)
                return;
            pen_edge.Color = colorDialog1.Color;
            button.BackColor = colorDialog1.Color;
            UpdateUI();
        }

        private void btn_color_2_Click(object sender, System.EventArgs e)
        {
            Button button = (sender as Button);
            if (colorDialog1.ShowDialog() == DialogResult.Cancel)
                return;
            brush_vertes = new SolidBrush(colorDialog1.Color);
            button.BackColor = colorDialog1.Color;
            UpdateUI();
        }

        private void with_bar_ValueChanged(object sender, System.EventArgs e)
        {
            if (g_state == STATE.NONE)
            {
                pen_edge.Width = (sender as TrackBar).Value;
                UpdateUI();
            }
        }

        private void canvas_MouseClick(object sender, MouseEventArgs e)
        {
            if (g_state == STATE.ADDING_POLYGON)
            {
                _polygons.Last().Insert(new Point2D(e.X, e.Y));
                _graphics.FillEllipse(brush_vertes, e.X - with_bar.Value / 2, e.Y - with_bar.Value / 2, with_bar.Value, with_bar.Value);
                canvas12.Invalidate();
            }
        }

        private void canvas_MouseDown(object sender, MouseEventArgs e)
        {

        }

        private void canvas_MouseUp(object sender, MouseEventArgs e)
        {

        }

        private void canvas_MouseMove(object sender, MouseEventArgs e)
        {

        }

        private void ReCount()
        {
            count_vertex = 0;
            foreach (var item in _polygons)
            {
                count_vertex += item.Size;
            }
        }

        private void status_Click(object sender, System.EventArgs e)
        {

        }

        private void btn_clear_Click_1(object sender, System.EventArgs e)
        {

        }
    }
}
