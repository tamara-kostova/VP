using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SlidingBalls
{
    public class Scene
    {
        public List <Ball> Balls { get; set; }
        int dx;
        int dy;
        int speed = 10;
        int touched;
        Random random = new Random();
        int width;
        int height;
        public Scene(int Width, int Height)
        {
            Balls = new List <Ball>();
            dx = 0;
            dy = 0;
            touched = -1;
            width = Width;
            height = Height;
        }
        public void Draw (Graphics g)
        {
            foreach (Ball b in Balls)
            {
                b.Draw (g);
            }
        }
        public void AddBall(Ball b)
        {
            Balls.Add (b);
        }

        public bool Click(Point location)
        {
            if (touched!=-1) return false;
            for (int i=0; i<Balls.Count; i++)
            {
                if (Balls[i].Touches(location) && Balls[i].Color.Equals(Color.Red)){
                    touched = i;
                    break;
                }
            }
            if (touched != -1)
            {
                int nasoka = random.Next(4);
                if (nasoka == 0) dx = speed;
                else if (nasoka == 1) dy = speed;
                else if (nasoka == 2) dx = -speed;
                else dy = -speed;
                return true;
            }
            return false;
        }

        public bool Move()
        {
            Balls[touched].Center = new Point(Balls[touched].Center.X + dx, Balls[touched].Center.Y + dy);
            for (int i= Balls.Count-1; i>=0; i--) { 
                if (Balls[i].Color.Equals(Color.Green) && Balls[i].Touches(Balls[touched]))
                {
                    Balls.RemoveAt(i);
                    if (i < touched)
                        touched--;
                }
            }
            if (Balls[touched].OutOfBounds(width, height))
            {
                Balls.RemoveAt(touched);
                touched = -1;
                dx = 0;
                dy = 0;
                return true;
            }
            return false;
        }
    }

}
