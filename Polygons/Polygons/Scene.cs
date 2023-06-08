using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Polygons
{
    public class Scene
    {
        public List <Polygon> Polygons { get; set; }
        public Scene()
        {
            Polygons = new List <Polygon>();
        }
        public void Draw (Graphics g)
        {
            foreach (Polygon polygon in Polygons)
            {
                polygon.Draw (g);
            }
        }

        internal void AddPolygon(Polygon CurrentPolygon)
        {
            Polygons.Add(CurrentPolygon);
        }
        public void Move (int dx, int dy)
        {
            foreach (Polygon polygon in Polygons)
            {
                polygon.Move (dx, dy);
            }
        }
    }
}
