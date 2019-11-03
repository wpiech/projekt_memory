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
