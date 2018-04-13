using System;
using System.Windows.Forms;

namespace SzovSzerk
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (saveFileDialog1.ShowDialog() == DialogResult.OK)
            {
                FileSaver.SaveData(saveFileDialog1.FileName, richTextBox1.Text);
            }            
        }

        private void button2_Click(object sender, EventArgs e)
        {
            OpenFileDialog ofd = new OpenFileDialog();
            if (ofd.ShowDialog() == DialogResult.OK)
            {
                string outText;
                if (FileSaver.LoadData(ofd.FileName, out outText))
                {
                    richTextBox1.Clear();
                    richTextBox1.Text = outText;
                }
            }
        }
    }
}
