using System;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace TextEditor
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void открытьToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                if (string.IsNullOrEmpty(openFileDialog1.FileName)) return;

                // Чтение текстового файла
                try
                {
                    using (var reader = new StreamReader(
                        openFileDialog1.FileName, Encoding.GetEncoding(1251)))
                    {
                        textBox1.Text = reader.ReadToEnd();
                    }
                }
                catch (FileNotFoundException ex)
                {
                    MessageBox.Show(ex.Message + "\nНет такого файла",
                        "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                }
                catch (Exception ex)
                {
                    // отчет о других ошибках
                    MessageBox.Show(ex.Message,
                        "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                }
            }
        }

        private void сохранитьКакToolStripMenuItem_Click(object sender, EventArgs e)
        {
            saveFileDialog1.FileName = openFileDialog1.FileName;
            if (saveFileDialog1.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    using (var writer = new StreamWriter(
                        saveFileDialog1.FileName, false, Encoding.GetEncoding(1251)))
                    {
                        writer.Write(textBox1.Text);
                    }
                }
                catch (Exception ex)
                {
                    // отчет о других ошибках
                    MessageBox.Show(ex.Message,
                        "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                }
            }
        }

        private void выходToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            textBox1.Clear();
            openFileDialog1.FileName = @"data\Text2.txt";
            openFileDialog1.Filter =
                "Текстовые файлы (*.txt)|*.txt|All files (*.*)|*.*";
            saveFileDialog1.Filter =
                "Текстовые файлы (*.txt)|*.txt|All files (*.*)|*.*";
        }
    }
}