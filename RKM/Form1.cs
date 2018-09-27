using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace RKM
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void textBoxLeft_KeyPress(object sender, KeyPressEventArgs e)
        {
            char number = e.KeyChar;
            if (!Char.IsDigit(number) && number != 8 && number != 46)
            {
                e.Handled = true;
            }
        }

        private void textBoxRight_KeyPress(object sender, KeyPressEventArgs e)
        {
            char number = e.KeyChar;

            if (!Char.IsDigit(number) && number != 8 && number != 46)
            {
                e.Handled = true;
            }
        }

        private void textBoxNmax_KeyPress(object sender, KeyPressEventArgs e)
        {
            char number = e.KeyChar;

            if (!Char.IsDigit(number) && number != 8 && number != 46)
            {
                e.Handled = true;
            }
        }

        private void textBoxH_KeyPress(object sender, KeyPressEventArgs e)
        {
            char number = e.KeyChar;

            if (!Char.IsDigit(number) && number != 8 && number != 46)
            {
                e.Handled = true;
            }
        }

        private void textBoxU0_KeyPress(object sender, KeyPressEventArgs e)
        {
            char number = e.KeyChar;

            if (!Char.IsDigit(number) && number != 8 && number != 46)
            {
                e.Handled = true;
            }
        }

        private void textBoxA_KeyPress(object sender, KeyPressEventArgs e)
        {
            char number = e.KeyChar;

            if (!Char.IsDigit(number) && number != 8 && number != 46)
            {
                e.Handled = true;
            }
        }

        private void textBoxB_KeyPress(object sender, KeyPressEventArgs e)
        {
            char number = e.KeyChar;

            if (!Char.IsDigit(number) && number != 8 && number != 46)
            {
                e.Handled = true;
            }
        }

        private void textBoxC_KeyPress(object sender, KeyPressEventArgs e)
        {
            char number = e.KeyChar;

            if (!Char.IsDigit(number) && number != 8 && number != 46)
            {
                e.Handled = true;
            }
        }

        private void textBoxZ_KeyPress(object sender, KeyPressEventArgs e)
        {
            char number = e.KeyChar;

            if (!Char.IsDigit(number) && number != 8 && number != 46)
            {
                e.Handled = true;
            }
        }


        private void button1_Click(object sender, EventArgs e)
        {
            double left, right, Nmax, U0, h, a, b, c, z;

            if (textBoxLeft.Text != "")
                left = Convert.ToDouble(textBoxLeft.Text);
            else left = 0;
            if (textBoxRight.Text != "")
                right = Convert.ToDouble(textBoxRight.Text);
            else right = 1;
            if (textBoxNmax.Text != "")
                Nmax = Convert.ToDouble(textBoxNmax.Text);
            else Nmax = 100;
            if (textBoxU0.Text != "")
                U0 = Convert.ToDouble(textBoxU0.Text);
            else U0 = 0;
            if (textBoxH.Text != "")
                h = Convert.ToDouble(textBoxH.Text);
            else h = 0.1;
            if (textBoxA.Text != "")
                a = Convert.ToDouble(textBoxA.Text);
            else a = 0;
            if (textBoxB.Text != "")
                b = Convert.ToDouble(textBoxB.Text);
            else b = 0;
            if (textBoxC.Text != "")
                c = Convert.ToDouble(textBoxC.Text);
            else c = 0;
            if (textBoxZ.Text != "")
                z = Convert.ToDouble(textBoxZ.Text);
            else z = 0;

            Functions.RKMdecision(left, right, Nmax, U0, h, a, b, c);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            double left, right, Nmax, U0, h, a, b, c, z0;

            if (textBoxLeft.Text != "")
                left = Convert.ToDouble(textBoxLeft.Text);
            else left = 0;
            if (textBoxRight.Text != "")
                right = Convert.ToDouble(textBoxRight.Text);
            else right = 1;
            if (textBoxNmax.Text != "")
                Nmax = Convert.ToDouble(textBoxNmax.Text);
            else Nmax = 100;
            if (textBoxU0.Text != "")
                U0 = Convert.ToDouble(textBoxU0.Text);
            else U0 = 0;
            if (textBoxH.Text != "")
                h = Convert.ToDouble(textBoxH.Text);
            else h = 0.1;
            if (textBoxA.Text != "")
                a = Convert.ToDouble(textBoxA.Text);
            else a = 0;
            if (textBoxB.Text != "")
                b = Convert.ToDouble(textBoxB.Text);
            else b = 0;
            if (textBoxC.Text != "")
                c = Convert.ToDouble(textBoxC.Text);
            else c = 0;
            if (textBoxZ.Text != "")
                z0 = Convert.ToDouble(textBoxZ.Text);
            else z0 = 0;

            Functions.RKMdecisionForSystem(left, right, Nmax, U0, z0, h, a, b, c);
        }
    }
}
