using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
//LE KELL TÖLTENI MOODLE-BŐL!!!
namespace BinaryFile
{
    public partial class Form1 : Form
    {
        int sX, sY;
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_MouseDown(object sender, MouseEventArgs e)
        {
            sX = e.X;
            sY = e.Y;
        }

        private void Form1_MouseUp(object sender, MouseEventArgs e)
        {
            Panel p = new Panel();
            p.Top = sY;
            p.Left = sX;
            p.Width = Math.Abs(e.X - sX);
            p.Height = Math.Abs(e.Y - sY);
            p.BackColor = Color.Black;
            p.Click += P_Click;
            this.Controls.Add(p);

        }

        private void Btn_Save_Click(object sender, EventArgs e)
        {
            SaveFileDialog sfd = new SaveFileDialog();
            if (sfd.ShowDialog() == DialogResult.OK)
            {
                using (FileStream fs = new FileStream(sfd.FileName, FileMode.OpenOrCreate)
                    using (BinaryWriter bw = new BinaryWriter(fs))
                {
                    foreach (object o in this.Controls)
                    {

                    }
                }
            }
        }

        private void P_Click(object sender, EventArgs e)
        {
            ColorDialog cd = new ColorDialog();
            if (cd.ShowDialog() == DialogResult.OK)
            {
                ((Panel)sender).BackColor = cd.Color;
            }
        }
    }
}
