using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Threading;

namespace Game
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        Button first, second;
        int count = 0;
        int i = 0;
        int iconindex;
        int wincount = 0;
        Random rnd = new Random();
        List<string> list = new List<string>()
        {
            "A", "B", "C", "D", "E", "F", "G", "H", "I", "J", "K", "L", "M", "N", "O", "P", "R", "S", "T", "U",
            "A", "B", "C", "D", "E", "F", "G", "H", "I", "J", "K", "L", "M", "N", "O", "P", "R", "S", "T", "U"
        };
        private void Form1_Load(object sender, EventArgs e)
        {
            foreach (Button item in Controls.OfType<Button>())
            {
                if (item != btn_start)
                    item.Text = "";
            }
        }

        private async void btn_start_Click(object sender, EventArgs e)
        {
            if (i == 0)
            {
                foreach (Button item in Controls.OfType<Button>())
                {
                    if (item != btn_start)
                    {
                        iconindex = rnd.Next(list.Count);
                        item.Text = list[iconindex];
                        list.RemoveAt(iconindex);
                    }
                }
                await Task.Delay(3000);
    
                foreach (Button item in Controls.OfType<Button>())
                {
                    if (item != btn_start)
                    {
                        item.ForeColor = item.BackColor;
                    }
                }
                i++;
            }
        }

        private async void button_click(object sender, EventArgs e)
        {
            Button btn = sender as Button;

            if (first == null)
            {
                first = btn;
                first.ForeColor = Color.Black;
                return;
            }
            else
            {
                second = btn;
                second.ForeColor = Color.Black;
            }
            if (first.Text == second.Text)
            {
                first = null;
                second = null;
                wincount++;
                if (wincount == 20)
                    MessageBox.Show("You Are Win!");
            }
            else
            {
                count++;
                moves.Text = count.ToString();
                await Task.Delay(1000);
                first.ForeColor = first.BackColor;
                second.ForeColor = second.BackColor;
                first = null;
                second = null;
            }
        }
    }
}
