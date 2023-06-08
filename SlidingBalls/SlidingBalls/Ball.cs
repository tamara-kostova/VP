using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SlidingBalls
{
    public class Ball
    {
        public static int Radius { get; set; } = 30;
        public Point Center { get; set; }
        public Color Color { get; set; }
        public Ball (Point center, Color color)
        {
            Center = center;
            Color = color;
        }
        public void Draw (Graphics g)
        {
            Brush b = new SolidBrush (Color);
            g.FillEllipse(b, Center.X - Radius, Center.Y - Radius, 2 * Radius, 2 * Radius);
            b.Dispose();
        }
        public bool Touches (Point location)
        {
            return (Center.X - location.X) * (Center.X - location.X) + (Center.Y - location.Y) * (Center.Y - location.Y) <= Radius * Radius;
        }
        public bool Touches(Ball ball)
        {
            return (Center.X - ball.Center.X) * (Center.X - ball.Center.X) + (Center.Y - ball.Center.Y) * (Center.Y - ball.Center.Y) <= 4 * Radius * Radius;
        }

        public bool OutOfBounds(int width, int height)
        {
            return Center.X - Radius > width || Center.X + Radius < 0 || Center.Y + Radius < 0 || Center.Y - Radius > height;
        }
    }
}
