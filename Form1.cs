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
        Random random = new Random();
        List<string> icons = new List<string>()
        {"[", "[",".", ".", "T", "T", "I", "I",
            "Q", "Q", "P", "P", "6", "6", "A", "A"
        };
        Label firstclicked, secondclicked;
        public Form1()
        {
            InitializeComponent();
            AssignIconsToSquares();
        }

        private void label1_Click(object sender, EventArgs e)
        {
            if (firstclicked != null && secondclicked != null)
                return;

            Label clickedLabel = sender as Label;

            if (clickedLabel == null)
                return;
            if (clickedLabel.ForeColor == Color.White)
                return;

            if (firstclicked == null) 
            {
                firstclicked = clickedLabel;
                firstclicked.ForeColor = Color.White;
                return;
            }

            secondclicked = clickedLabel;
            secondclicked.ForeColor = Color.White;

            check();

            if (firstclicked.Text == secondclicked.Text)
            {
                firstclicked = null;
                secondclicked = null;
            }
            else

                 timer1.Start();
        }

        private void check()
        {
            Label label;
            for (int i=0; i< tableLayoutPanel1.Controls.Count; i++)
            {
                label = tableLayoutPanel1.Controls[i] as Label;
                if (label != null && label.ForeColor == label.BackColor)
                    return;

            }
            MessageBox.Show("Brawo! Dopasowałeś wszystkie obrazki.");
            Close();
        }
        private void timer1_Tick(object sender, EventArgs e)
        {
            timer1.Stop();

            firstclicked.ForeColor = firstclicked.BackColor;
            secondclicked.ForeColor = secondclicked.BackColor;

            firstclicked = null;
            secondclicked = null;
        }

        private void AssignIconsToSquares()
        { Label label;
            int randomnumber;
            for(int i = 0; i<tableLayoutPanel1.Controls.Count; i++)
            { if (tableLayoutPanel1.Controls[i] is Label)
                    label = (Label)tableLayoutPanel1.Controls[i];
                else
                    continue;
                randomnumber = random.Next(0, icons.Count);
                label.Text = icons[randomnumber];
                icons.RemoveAt(randomnumber);
            }
        }
    }
}
