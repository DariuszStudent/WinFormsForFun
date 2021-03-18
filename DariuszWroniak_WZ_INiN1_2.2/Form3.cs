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
    public partial class Form3 : Form
    {
        public Form3()
        { 
            InitializeComponent();
        }

        private void textBox1_KeyPress(object sender, KeyPressEventArgs e)
        {
            Program.justNumbers(e);
        }

        private void textBox2_KeyPress(object sender, KeyPressEventArgs e)
        {
            Program.justNumbers(e);
        }

        private void textBox3_KeyPress(object sender, KeyPressEventArgs e)
        {
            Program.justNumbers(e);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (textBox1.Text.Length > 0 && textBox2.Text.Length > 0)
            {
                var a = default(int);
                var szukana = default(int);

                try
                {
                    a = int.Parse(textBox1.Text);
                }
                catch (Exception)
                {
                    MessageBox.Show("Program nie będzie działał, maxymalna liczba: 2.147.483.647");
                }

                try
                {
                    szukana = int.Parse(textBox2.Text);
                }
                catch (Exception)
                {
                    MessageBox.Show("Program nie będzie działał, maxymalna liczba: 2.147.483.647");
                }


                var tablica = new int[a];

                for (int i = 0; i < tablica.Length; i++)
                {
                    tablica[i] = i + 1;
                }

                var licznik = 0;

                textBox3.Text = algorytm(szukana, tablica, licznik).ToString();
                if (textBox3.Text == "-1") textBox3.Text = ("Złe dane");
            }
        }

        private int algorytm(int szukana, int[] tablica, int licznik)
        {
            var low = 0;
            var high = tablica.Length - 1;

            while (low <= high)
            {
                licznik++;
                var mid = (low + high) / 2;
                var quess = tablica[mid];
                if (quess == szukana) return licznik;
                if (quess > szukana) high = mid - 1;
                if (quess < szukana) low = mid + 1;
            }
            return -1;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Form4 openForm = new Form4();
            openForm.Show();
        }
    }
}
