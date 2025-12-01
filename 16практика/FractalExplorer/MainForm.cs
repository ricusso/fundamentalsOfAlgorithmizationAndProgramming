using System;
using System.Drawing;
using System.Windows.Forms;

namespace FractalExplorer
{
    public class MainForm : Form
    {
        public MainForm()
        {
            this.Text = "FractalExplorer";
            this.Size = new Size(300, 200);
            this.StartPosition = FormStartPosition.CenterScreen;

            Button btnLeaf = new Button();
            btnLeaf.Text = "Лист";
            btnLeaf.Location = new Point(80, 50);
            btnLeaf.Size = new Size(120, 30);
            btnLeaf.Click += BtnLeaf_Click;

            Button btnTree = new Button();
            btnTree.Text = "Дерево";
            btnTree.Location = new Point(80, 100);
            btnTree.Size = new Size(120, 30);
            btnTree.Click += BtnTree_Click;

            this.Controls.Add(btnLeaf);
            this.Controls.Add(btnTree);
        }

        private void BtnLeaf_Click(object sender, EventArgs e)
        {
            LeafForm leafForm = new LeafForm();
            leafForm.Show();
        }

        private void BtnTree_Click(object sender, EventArgs e)
        {
            TreeForm treeForm = new TreeForm();
            treeForm.Show();
        }
    }
}