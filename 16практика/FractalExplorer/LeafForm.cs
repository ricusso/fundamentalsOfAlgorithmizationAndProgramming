using System;
using System.Drawing;
using System.Windows.Forms;

namespace FractalExplorer
{
    public class LeafForm : Form
    {
        private PictureBox pictureBox;
        private Timer timer;
        private int level = 1;

        public LeafForm()
        {
            this.Text = "Лист";
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
            if (level > 5) level = 1; 
            pictureBox.Invalidate();
        }

        private void PictureBox_Paint(object sender, PaintEventArgs e)
        {
            Graphics g = e.Graphics;
            g.Clear(Color.White);

            DrawFractalLeaf(g, 250, 400, 80, level, 0);
        }

        private void DrawFractalLeaf(Graphics g, float x, float y, float size, int depth, float angle)
        {
            if (depth <= 0) return;

            Pen pen = new Pen(Color.Green, depth);

            float endX = x + (float)Math.Cos(angle * Math.PI / 180) * size;
            float endY = y + (float)Math.Sin(angle * Math.PI / 180) * size;
            g.DrawLine(pen, x, y, endX, endY);

            if (depth > 1)
            {
                DrawFractalLeaf(g, endX, endY, size * 0.6f, depth - 1, angle - 45);
                DrawFractalLeaf(g, endX, endY, size * 0.6f, depth - 1, angle + 45);
                DrawFractalLeaf(g, endX, endY, size * 0.4f, depth - 1, angle - 30);
                DrawFractalLeaf(g, endX, endY, size * 0.4f, depth - 1, angle + 30);
            }

            pen.Dispose();
        }
    }
}