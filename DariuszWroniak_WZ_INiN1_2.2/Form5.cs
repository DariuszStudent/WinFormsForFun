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
    public partial class Form5 : Form
    {
        int bigger { get; set; }
        int win { get; set; }
        int smaller { get; set; }
        int score { get; set; }
        int[] tablica { get; set; }
        int licznik { get; set; }
        bool startGame { get; set; }
        bool fail { get; set; }

        public Form5()
        {
            InitializeComponent();
            fail = true;
        }

        private void textBox1_KeyPress(object sender, KeyPressEventArgs e)
        {
            Program.justNumbers(e);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                bigger = int.Parse(textBox1.Text);
            }
            catch (Exception)
            {
                MessageBox.Show("Program nie będzie działał, maxymalna liczba: 2.147.483.647");
            }

            fail = true;
            smaller = 1;
            score = 0;
            startGame = true;
            textBox2.Text = ("");

            Random rnd = new Random();
            win = rnd.Next(smaller, bigger + 1);

            tablica = new int[bigger];

            for (int i = 0; i < tablica.Length; i++)
            {
                tablica[i] = i + 1;
            }

            label4.Text = win.ToString();

            label2.Text = ("Gratuluję, zacząłeś zabawę, znajdź liczbę\nw przedziale od " + smaller + " do " + bigger);

            label3.Text = ("");
            label5.Text = ("");
        }

        private int algorytm(int szukana, int[] tablica)
        {
            var low = 0;
            var bigger = tablica.Length - 1;
            licznik = 0;

            while (low <= bigger)
            {
                licznik++;
                var mid = (low + bigger) / 2;
                var quess = tablica[mid];
                if (quess == szukana) return licznik;
                if (quess > szukana) bigger = mid - 1;
                if (quess < szukana) low = mid + 1;
            }
            return -1;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (startGame && textBox2.Text.Length > 0)
            {
                var userNumberWin = default(int);

                try
                {
                    userNumberWin = int.Parse(textBox2.Text);
                }
                catch (Exception)
                {
                    fail = false;
                    MessageBox.Show("Program nie będzie działał, maxymalna liczba: 2.147.483.647");
                }

                if (fail)
                {
                    var licznik = algorytm(win, tablica);

                    label2.Text = ("Podaj liczbę całkowitą od" + smaller + " do " + bigger);
                    button1.Text = ("Reset gry");

                    if (userNumberWin <= bigger && userNumberWin >= smaller)
                    {
                        label2.Text = ("Podałeś liczbę: " + userNumberWin);
                        if (userNumberWin == win)
                        {
                            score++;
                            label2.Text = ("Wygrałeś gratuluje!");
                            label2.Text = ("Zrobiłeś to w: " + score + " podejściu");
                            label3.Text = ("Komputer: " + licznik + "\n" +
                                "Użytkownik: " + score);
                            if (licznik == score) label5.Text = ("Brawo, remis z algorytmem");
                            if (licznik < score) label5.Text = ("Przykro mi, przegrałeś z algorytmem");
                            if (licznik > score) label5.Text = ("Wygrałeś z algorytmem!");
                            fail = false;
                        }
                        if (userNumberWin > win)
                        {
                            bigger = userNumberWin - 1;
                            label2.Text = ("Twoja liczba jest za duża\n" +
                                "Podaj liczbę całkowitą od " + smaller + " do " + bigger);
                            score++;
                        }
                        if (userNumberWin < win)
                        {
                            smaller = userNumberWin + 1;
                            label2.Text = ("Twoja liczba jest za mała\n" +
                                "Podaj liczbę całkowitą od " + smaller + " do " + bigger);
                            score++;
                        }
                    }
                    else label2.Text = ("Nie podałeś liczby w zakresie od \n" + smaller + " do " + bigger);
                }
            }
        }

        private void textBox2_KeyPress(object sender, KeyPressEventArgs e)
        {
            Program.justNumbers(e);
            char a = e.KeyChar;

            if (a == 13)
            {
                button2_Click(sender, e);
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            if (label4.Visible) label4.Visible = false;
            else label4.Visible = true;
        }

        private void button3_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
