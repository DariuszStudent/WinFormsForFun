using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DariuszWroniak_WZ_INiN1_2._2
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void cadetBlueToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.BackColor = Color.CadetBlue;
        }

        private void darkGrayToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.BackColor = Color.DarkGray;
        }

        private void darkSeaGreenToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.BackColor = Color.DarkSeaGreen;
        }

        private void pomocToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Gra ma na celu wyjaśnienie jednego z podstawowych algorytmów.\n" +
                "Wyszukiwanie Binarne.");
        }

        private void oAutorzeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Dariusz Wroniak WZ_INiN1_2.2");
        }

        private void wyjścieToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            System.IO.Stream str = Properties.Resources.sea;
            System.Media.SoundPlayer snd = new System.Media.SoundPlayer(str);

            if (checkBox1.Checked) snd.PlayLooping();
            else snd.Stop();
        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            System.Diagnostics.Process.Start("https://pl.wikipedia.org/wiki/Wyszukiwanie_binarne");
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Form2 openForm = new Form2();
            openForm.Show();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Form3 openForm = new Form3();
            openForm.Show();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Form5 openForm = new Form5();
            openForm.Show();
        }
    }
}
