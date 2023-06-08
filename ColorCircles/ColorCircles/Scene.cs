using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ColorCircles
{
    public class Scene
    {
        public List <Circle> Circles = new List <Circle> ();
        public Scene() { 
            Circles = new List <Circle> ();
        }
        public void Draw (Graphics g)
        {
            foreach (Circle c in Circles)
            {
                c.Draw (g);
            }
        }
        public void AddCircle (Circle circle)
        {
            Circles.Add (circle);
        }

        internal void Select(Point location)
        {
            foreach(Circle c in Circles)
            {
                if (c.Touches(location))
                    c.IsSelected = !c.IsSelected;
            }
        }

        internal void DeleteSelected()
        {
            for (int i= Circles.Count - 1; i >= 0; i--)
            {
                if (Circles[i].IsSelected)
                    Circles.RemoveAt(i);
            }
        }
    }
}
