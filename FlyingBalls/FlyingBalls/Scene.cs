using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FlyingBalls
{
    public class Scene
    {
        public List<Ball> Balls { get; set; }
        public int hit;
        public int missed;
        public Scene()
        {
            Balls = new List<Ball>();
            hit = 0;
            missed = 0;
        }
        public void Draw(Graphics g)
        {
            foreach (Ball b in Balls)
            {
                b.Draw(g);
            }
        }

        public void AddBall(int Height)
        {
            Balls.Add(new Ball(Height));
        }

        public void Move()
        {
            foreach (Ball b in Balls)
            {
                b.Move();
            }
        }

        public void Click(Point location)
        {
            foreach (Ball b in Balls)
            {
                if (b.Touches(location))
                {
                    b.State++;
                }
            }
            for (int i = Balls.Count - 1; i >= 0; i--)
            {
                if (Balls[i].State == 3)
                {
                    hit++;
                    Balls.RemoveAt(i);
                }
            }
        }

        public void Check(int width)
        {
            for (int i = Balls.Count - 1; i >= 0; i--)
            {
                if (Balls[i].OutOfBounds(width))
                {
                    missed++;
                    Balls.RemoveAt(i);
                }
            }
        }
    }
}
