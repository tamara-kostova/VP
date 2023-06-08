using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Polygons
{
    public class Polygon
    {
        public List <Point> Points { get; set; }
        public Color Color { get; set; }
        public bool IsClosed { get; set; }
        public Polygon(Color color)
        {
            Points = new List<Point>();
            Color = color;
        }
        public void Draw (Graphics g)
        {
            if (Points.Count > 1)
            {
                Brush b = new SolidBrush(Color);
                Pen p = new Pen(b);
                if (IsClosed)
                {
                    g.FillPolygon(b, Points.ToArray());
                }
                else
                    g.DrawLines(p, Points.ToArray());
                b.Dispose();
                p.Dispose();
            }
        }

        internal void AddPoint(Point location)
        {
            Points.Add(location);
        }
        public void Move (int dx, int dy)
        {
            for (int i=0; i<Points.Count; i++)
            {
                Points[i] = new Point(Points[i].X+dx, Points[i].Y + dy);
            }
        }
    }
}
