using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace apka
{
    public partial class Form1 : Form
    {
        Random zmienna = new Random(); //lista obrazków
        List<string> obrazki = new List<string>()
        {"[", "[",".", ".", "T", "T", "I", "I",
            "Q", "Q", "P", "P", "6", "6", "A", "A"
        };
        Label pierwszy, drugi;
        public Form1()
        {
            InitializeComponent();
            obrazkiikwadraty();
        }

        private void label1_Click(object sender, EventArgs e) //zmiana z zakrytych na odkryte
        {
            if (pierwszy != null && drugi != null)
                return;

            Label wybrany = sender as Label;

            if (wybrany == null)
                return;
            if (wybrany.ForeColor == Color.White)
                return;

            if (pierwszy == null) 
            {
                pierwszy = wybrany;
                pierwszy.ForeColor = Color.White;
                return;
            }

            drugi = wybrany;
            drugi.ForeColor = Color.White;

            wygrana();

            if (pierwszy.Text == drugi.Text) //jeśli pasują zostają
            {
                pierwszy = null;
                drugi = null;
            }
            else

                 timer1.Start();
        }

        private void wygrana() //sprawdzenie czy dopasowano wszystkie obrazki
        {
            Label sprawdzenie;
            for (int i=0; i< tableLayoutPanel1.Controls.Count; i++)
            {
                sprawdzenie = tableLayoutPanel1.Controls[i] as Label;
                if (sprawdzenie != null && sprawdzenie.ForeColor == sprawdzenie.BackColor)
                    return;

            }
            MessageBox.Show("Brawo! Wygrałeś.");
            Close();
        }
        private void timer1_Tick(object sender, EventArgs e) //chowanie obrazków po kliknięciu
        {
            timer1.Stop();

            pierwszy.ForeColor = pierwszy.BackColor;
            drugi.ForeColor = drugi.BackColor;

            pierwszy = null;
            drugi = null;
        }

        private void obrazkiikwadraty() //przypisanie obrazków do kwadratów
        { Label plansza;
            int numer;
            for(int i = 0; i<tableLayoutPanel1.Controls.Count; i++)
            { if (tableLayoutPanel1.Controls[i] is Label)
                    plansza = (Label)tableLayoutPanel1.Controls[i]; 
               
                else
                    continue;
                numer = zmienna.Next(0, obrazki.Count);
                plansza.Text = obrazki[numer];
                obrazki.RemoveAt(numer);
            }
        }
    }
}
