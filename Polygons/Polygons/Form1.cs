namespace Polygons
{
    public partial class Form1 : Form
    {
        public Scene Scene { get; set; }
        public Color color { get; set; }
        public Point CurrentPoint { get; set; }
        public Point PreviousPoint { get; set; }
        public Point StartPoint { get; set; }
        public Polygon CurrentPolygon { get; set; }
        public Color Color { get; set; }
        public double distance;
        public bool close { get; set; }
        public Form1()
        {
            InitializeComponent();
            Scene = new Scene();
            this.DoubleBuffered = true;
            close = false;
            Color = Color.Red;
        }

        private void Form1_Paint(object sender, PaintEventArgs e)
        {
            if (CurrentPolygon != null)
            {
                CurrentPolygon.Draw(e.Graphics);
            }
            Scene.Draw(e.Graphics);
            Pen squarePen = new Pen(Color.Black, 2);
            squarePen.DashStyle = System.Drawing.Drawing2D.DashStyle.DashDot;
            Pen pen = new Pen(Color.Black, 1);
            pen.DashStyle = System.Drawing.Drawing2D.DashStyle.Dash;
            if (close)
            {
                e.Graphics.DrawRectangle(squarePen, StartPoint.X - 5, StartPoint.Y - 5, 10, 10);
            }
            if (!StartPoint.IsEmpty)
            {
                e.Graphics.DrawLine(pen, PreviousPoint, CurrentPoint);
            }
            squarePen.Dispose();
            pen.Dispose();
            Invalidate();
        }

        private void Form1_MouseClick(object sender, MouseEventArgs e)
        {
            if (StartPoint == Point.Empty)
            {
                CurrentPolygon = new Polygon(Color);
                StartPoint = e.Location;
                PreviousPoint = e.Location;
                CurrentPolygon.AddPoint(StartPoint);
            }
            else
            {
                if (close)
                {
                    CurrentPolygon.IsClosed = true;
                    PreviousPoint = Point.Empty;
                    StartPoint = Point.Empty;
                    close = false;
                    if (CurrentPolygon.Points.Count >= 3)
                    {
                        Scene.AddPolygon(CurrentPolygon);
                    }
                }
                else
                {
                    CurrentPolygon.AddPoint(e.Location);
                    PreviousPoint = e.Location;
                }
                Invalidate();
            }
        }

        private void Form1_MouseMove(object sender, MouseEventArgs e)
        {
            if (StartPoint != Point.Empty)
            {
                distance = (CurrentPoint.X - StartPoint.X) * (CurrentPoint.X - StartPoint.X) + (CurrentPoint.Y - StartPoint.Y) * (CurrentPoint.Y - StartPoint.Y);
                close = distance <= 25;
            }
            CurrentPoint = e.Location;
            Invalidate();
        }

        private void colorToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ColorDialog cldg = new ColorDialog();
            if (cldg.ShowDialog() == DialogResult.OK)
            {
                Color = cldg.Color;
            }
        }

        private void Form1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Down)
            {
                if (Scene != null)
                {
                    Scene.Move(0, 5);
                }
            }
            if (e.KeyCode == Keys.Up)
            {
                if (Scene != null)
                {
                    Scene.Move(0, -5);
                }
            }
            if (e.KeyCode == Keys.Right)
            {
                if (Scene != null)
                {
                    Scene.Move(5, 0);
                }
            }
            if (e.KeyCode == Keys.Left)
            {
                if (Scene != null)
                {
                    Scene.Move(-5, 0);
                }
            }
            Invalidate();
        }
    }
}