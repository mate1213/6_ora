using System;
using System.Drawing;
using System.IO;
using System.Windows.Forms;

namespace RajzoloApp
{
    public partial class Form1 : Form
    {
        int sX, sY;
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            OpenFileDialog ofd = new OpenFileDialog();
            if (ofd.ShowDialog() == DialogResult.OK)
            {
                using (FileStream fs = new FileStream(ofd.FileName, FileMode.Open))
                {
                    using (BinaryReader br = new BinaryReader(fs))
                    {
                        long size = fs.Length;
                        while (br.BaseStream.Position < size)
                        {
                            Panel p = new Panel();
                            p.Top = br.ReadInt32();
                            p.Left = br.ReadInt32();
                            p.Width = br.ReadInt32();
                            p.Height = br.ReadInt32();
                            p.BackColor = Color.FromArgb(br.ReadInt32());
                            this.Controls.Add(p);
                        }
                    }
                }
            }
        }

        private void Form1_MouseUp(object sender, MouseEventArgs e)
        {
            Panel p = new Panel();

            p.Top = sY;
            p.Left = sX;
            p.Width = Math.Abs(sX - e.X);
            p.Height = Math.Abs(sY - e.Y);

            p.BackColor = Color.Black;
            p.Click += P_Click;
            this.Controls.Add(p);
        }

        private void P_Click(object sender, EventArgs e)
        {
            ColorDialog cd = new ColorDialog();
            if (cd.ShowDialog() == DialogResult.OK)
            {
                ((Panel)sender).BackColor = cd.Color;
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            SaveFileDialog sfd = new SaveFileDialog();
            if (sfd.ShowDialog() == DialogResult.OK)
            {
                using (FileStream fs = new FileStream(sfd.FileName, FileMode.OpenOrCreate))
                {
                    using (BinaryWriter bw = new BinaryWriter(fs))
                    {
                        foreach (object o in this.Controls)
                        {
                            if (o is Panel)
                            {
                                bw.Write(((Panel)o).Top);
                                bw.Write(((Panel)o).Left);
                                bw.Write(((Panel)o).Width);
                                bw.Write(((Panel)o).Height);
                                bw.Write(((Panel)o).BackColor.ToArgb());
                            }
                        }
                    }
                }
            }
        }

        private void Form1_MouseDown(object sender, MouseEventArgs e)
        {
            sX = e.X;
            sY = e.Y;
        }
    }
}
