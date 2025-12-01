using System;
using System.Drawing;
using System.Windows.Forms;

namespace FractalExplorer
{
    public class TreeForm : Form
    {
        private PictureBox pictureBox;
        private Timer timer;
        private int level = 1;

        public TreeForm()
        {
            this.Text = "Дерево";
            this.Size = new Size(600, 600);
            this.StartPosition = FormStartPosition.CenterScreen;

            pictureBox = new PictureBox();
            pictureBox.Size = new Size(500, 500);
            pictureBox.Location = new Point(50, 50);
            pictureBox.BorderStyle = BorderStyle.FixedSingle;
            pictureBox.BackColor = Color.White;
            pictureBox.Paint += PictureBox_Paint;

            timer = new Timer();
            timer.Interval = 1000;
            timer.Tick += Timer_Tick;
            timer.Start();

            this.Controls.Add(pictureBox);
        }

        private void Timer_Tick(object sender, EventArgs e)
        {
            level++;
            if (level > 6) level = 1; 
            pictureBox.Invalidate();
        }

        private void PictureBox_Paint(object sender, PaintEventArgs e)
        {
            Graphics g = e.Graphics;
            g.Clear(Color.White);

            DrawFractalTree(g, 250, 450, 100, -90, level);
        }

        private void DrawFractalTree(Graphics g, float x, float y, float length, float angle, int depth)
        {
            if (depth <= 0) return;

            float x2 = x + (float)Math.Cos(angle * Math.PI / 180) * length;
            float y2 = y + (float)Math.Sin(angle * Math.PI / 180) * length;

            Pen pen = new Pen(Color.Brown, depth);
            g.DrawLine(pen, x, y, x2, y2);
            pen.Dispose();

            if (depth > 1)
            {
                DrawFractalTree(g, x2, y2, length * 0.7f, angle - 25, depth - 1);
                DrawFractalTree(g, x2, y2, length * 0.7f, angle + 25, depth - 1);

                if (depth > 2)
                {
                    DrawFractalTree(g, x2, y2, length * 0.4f, angle - 15, depth - 2);
                    DrawFractalTree(g, x2, y2, length * 0.4f, angle + 15, depth - 2);
                }
            }
        }
    }
}