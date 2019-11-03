using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace kolejne_memo
{
    public partial class Form1 : Form
    {
        Random zmienna = new Random();
        List<string> obrazek = new List<string>()
            { "[", "[", ".", ".", "T", "T", "I",
            "Q", "Q", "P", "P", "6", "6", "A", "A"
            };
        Label pierwszyobrazek, drugiobrazek;
        private object tableLayoutPanel1;

        public Form1()
        {
            InitializeComponent();
            przypisanieobrazkow();
        }

        private void InitializeComponent()
        {
            throw new NotImplementedException();
        }

        private void przypisanieobrazkow()
        {
            Label label;
            int losowaliczba;

            for (int i = 0; i < tableLayoutPanel1.Controls.Count; i++)
            {
                if (tableLayoutPanel1.Controls[i] is Label)
                    label = (Label) .Controls[i];
                else
                    continue;
                losowaliczba = zmienna.Next(0, obrazek.Count);
                label.Text = obrazek[losowaliczba];

                obrazek.RemoveAt(losowaliczba);
            }


        }
    }


}
