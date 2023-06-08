namespace ColorCircles
{
    public partial class Form1 : Form
    {
        public Scene Scene { get; set; }
        public Point PreviousPoint { get; set; }
        public Point CurrentPoint { get; set; }
        public int radius { get; set; }
        public Color color { get; set; }
        public Form1()
        {
            InitializeComponent();
            Scene = new Scene();
            this.DoubleBuffered = true;
            color = Color.Red;
        }

        private void Form1_Paint(object sender, PaintEventArgs e)
        {
            Scene.Draw(e.Graphics);
            if (!PreviousPoint.IsEmpty)
            {
                Pen linepen = new Pen(Color.Black, 1);
                linepen.DashStyle = System.Drawing.Drawing2D.DashStyle.DashDot;
                e.Graphics.DrawEllipse(linepen, PreviousPoint.X - radius, PreviousPoint.Y - radius, 2 * radius, 2 * radius);
                linepen.Dispose();
            }
        }

        private void Form1_MouseClick(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                if (PreviousPoint == Point.Empty)
                {
                    PreviousPoint = e.Location;
                }
                else
                {
                    Scene.AddCircle(new Circle(PreviousPoint, radius, color));
                    PreviousPoint = Point.Empty;
                    CurrentPoint = Point.Empty;
                }
            }
            else
            {
                Scene.Select(e.Location);
            }
            Invalidate();
        }

        private void Form1_MouseMove(object sender, MouseEventArgs e)
        {
            CurrentPoint = e.Location;
            radius = (int)Math.Sqrt((CurrentPoint.X - PreviousPoint.X) * (CurrentPoint.X - PreviousPoint.X) + (CurrentPoint.Y - PreviousPoint.Y) * (CurrentPoint.Y - PreviousPoint.Y));
            Invalidate();
        }

        private void Form1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape)
            {
                CurrentPoint = Point.Empty;
                PreviousPoint = Point.Empty;
            }
            else if (e.KeyCode == Keys.Delete)
            {
                Scene.DeleteSelected();
            }
            Invalidate();
        }
    }
}