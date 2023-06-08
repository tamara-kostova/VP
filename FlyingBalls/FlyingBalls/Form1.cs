using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters.Binary;

namespace FlyingBalls
{
    public partial class Form1 : Form
    {
        public Scene Scene { get; set; }
        int seconds;
        int height;
        int width;
        public Form1()
        {
            InitializeComponent();
            Scene = new Scene();
            this.DoubleBuffered = true;
            seconds = 0;
            width = Width;
            height = Height;
            timer1.Start();
        }
        private void Form1_Paint(object sender, PaintEventArgs e)
        {
            Scene.Draw(e.Graphics);
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            hit.Text = String.Format("Hit: {0}", Scene.hit);
            missed.Text = String.Format("Missed: {0}", Scene.missed);
            Scene.Move();
            Scene.Check(width);
            if (seconds % 10 == 0)
            {
                Scene.AddBall(height);
            }
            seconds++;
            Invalidate();
        }

        private void Form1_MouseClick(object sender, MouseEventArgs e)
        {
            Scene.Click(e.Location);
        }

        private void toolStripStatusLabel1_Paint(object sender, PaintEventArgs e)
        {
            //missed.Text = String.Format("Hit: {0}, Missed: {0}", Scene.hit, Scene.missed);
        }

        private void statusStrip1_Paint(object sender, PaintEventArgs e)
        {
            hit.Text = String.Format("Hit: {0}", Scene.hit);
            missed.Text = String.Format("Missed: {0}", Scene.missed);
            Invalidate();
        }

        private void newToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Scene = new Scene();
        }

        private void openToolStripMenuItem_Click(object sender, EventArgs e)
        {
            OpenFileDialog ofd = new OpenFileDialog();
            ofd.Title = "Open Project";
            if (ofd.ShowDialog() == DialogResult.OK)
            {
                FileStream fs = new FileStream(ofd.FileName, FileMode.Open);
                IFormatter iformatter = new BinaryFormatter();
                Scene = (Scene)iformatter.Deserialize(fs);
            }
        }

        private void saveToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SaveFileDialog ofd = new SaveFileDialog();
            ofd.Title = "Save Project";
            if (ofd.ShowDialog() == DialogResult.OK)
            {
                FileStream fs = new FileStream(ofd.FileName, FileMode.OpenOrCreate);
                IFormatter iformatter = new BinaryFormatter();
                iformatter.Serialize(fs, Scene);
            }
        }

        private void Form1_Resize(object sender, EventArgs e)
        {
            width = this.Width;
            height = this.Height;
        }
    }
}