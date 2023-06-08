using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FlyingBalls
{
    public class Ball
    {
        public Point Center { get; set; }
        public static int Radius { get; set; } = 30;
        public int State { get; set; }
        Random random = new Random();
        public Ball(int height) { 
            Center = new Point(-Radius,random.Next(2*Radius,height-2*Radius));
            State = random.Next(3);
        }
        public void Draw (Graphics g)
        {
            Color Color = Color.White;
            if (State == 0)
            {
                Color = Color.Red;
            }
            else if (State == 1)
            {
                Color = Color.Green;
            }
            else
            {
                Color = Color.Blue;
            }
            Brush b = new SolidBrush(Color);
            g.FillEllipse(b, Center.X-Radius, Center.Y-Radius,2*Radius,2*Radius);
            b.Dispose();
        }

        public void Move()
        {
            Center = new Point(Center.X + 10, Center.Y);
        }
        public bool Touches (Point location)
        {
            return (Center.X - location.X) * (Center.X - location.X) + (Center.Y - location.Y) * (Center.Y - location.Y) <= Radius * Radius;
        }
        public bool OutOfBounds (int width)
        {
            return Center.X - Radius > width;
        }
    }
}
