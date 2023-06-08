using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters.Binary;

namespace SlidingBalls
{
    public partial class Form1 : Form
    {
        public Scene Scene { get; set; }
        Random random;
        public Form1()
        {
            InitializeComponent();
            Scene = new Scene(Width, Height);
            random = new Random();
            this.DoubleBuffered = true;
        }

        private void Form1_Paint(object sender, PaintEventArgs e)
        {
            Scene.Draw(e.Graphics);
        }

        private void Form1_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            int boja = random.Next(2);
            if (boja == 0)
            {
                Scene.AddBall(new Ball(e.Location, Color.Green));
            }
            else
            {
                Scene.AddBall(new Ball(e.Location, Color.Blue));
            }
            toolStripStatusLabel1.Text = String.Format("active: {0}", Scene.Balls.Count);

            Invalidate();
        }

        private void Form1_MouseClick(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
            {
                Scene.AddBall(new Ball(e.Location, Color.Red));
            }
            else
            {
                if (Scene.Click(e.Location))
                    timer1.Start();
            }
            toolStripStatusLabel1.Text = String.Format("active: {0}", Scene.Balls.Count);

            Invalidate();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            if (Scene.Move())
            {
                timer1.Stop();
            }
            Invalidate();
        }

        private void statusStrip1_Paint(object sender, PaintEventArgs e)
        {
            toolStripStatusLabel1.Text = String.Format("active: {0}", Scene.Balls.Count);
        }

        private void newToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Scene = new Scene(Width, Height);
        }

        private void openToolStripMenuItem_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                FileStream fs = new FileStream(openFileDialog.FileName, FileMode.Open);
                IFormatter iformatter = new BinaryFormatter();
                Scene = (Scene)iformatter.Deserialize(fs);
            }
        }

        private void saveToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SaveFileDialog saveFileDialog = new SaveFileDialog();
            if (saveFileDialog.ShowDialog() == DialogResult.OK)
            {
                FileStream fs = new FileStream(saveFileDialog.FileName, FileMode.OpenOrCreate);
                IFormatter iformatter = new BinaryFormatter();
                iformatter.Serialize(fs, Scene);
            }
        }
    }
}