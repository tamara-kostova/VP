using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ColorCircles
{
    public class Circle
    {
        public Point Center { get; set; }
        public int Radius { get; set; }
        public Color Color { get; set; }
        public bool IsSelected { get; set; }
        public Circle(Point center, int radius, Color color) {
            Center = center;
            Radius = radius;
            Color = color;
            IsSelected = false;
        }
        public void Draw (Graphics g)
        {
            Brush brush = new SolidBrush (Color);
            g.FillEllipse(brush,Center.X-Radius,Center.Y-Radius,2*Radius,2*Radius);
            if (IsSelected)
            {
                Pen pen = new Pen(Color.Black,3);
                g.DrawEllipse(pen, Center.X - Radius, Center.Y - Radius, 2 * Radius, 2 * Radius);
                pen.Dispose();
            }
            brush.Dispose();
        }

        internal bool Touches(Point location)
        {
            return (location.X - Center.X) * (location.X - Center.X) + (location.Y - Center.Y) * (location.Y - Center.Y) <= Radius * Radius;
        }
    }
}
