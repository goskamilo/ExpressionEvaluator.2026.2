using System;
using System.Windows.Forms;

namespace Frontend.Windows
{
    public partial class Form1 : Form
    {
        public Form1() => InitializeComponent();

        private void label1_Click(object sender, EventArgs e)
        {
        }

        // Variables
       string op = "";
       double num1 = 0, num2 = 0, result = 0;

        private void button20_Click(object sender, EventArgs e)
        {
            txtScreen.Text = txtScreen.Text + "0";
            num1 = 0;
           num2 = 0;
           op = "";
        }

        private void button21_Click(object sender, EventArgs e)
        {
            if (txtScreen.Text.Length > 0)
            {
                txtScreen.Text = txtScreen.Text.Substring(0, txtScreen.Text.Length - 1);
            }
        }
        private void button1_Click(object sender, EventArgs e)
        {
            if (txtScreen.Text.Length == 0) txtScreen.Text = "1";
            else txtScreen.Text = txtScreen.Text + "1";
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (txtScreen.Text.Length == 0) txtScreen.Text = "2";
            else txtScreen.Text = txtScreen.Text + "2";
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (txtScreen.Text.Length == 0) txtScreen.Text = "3";
            else txtScreen.Text = txtScreen.Text + "3";
        }

        private void button4_Click(object sender, EventArgs e)
        {
            if (txtScreen.Text.Length == 0) txtScreen.Text = "4";
            else txtScreen.Text = txtScreen.Text + "4";
        }

        private void button5_Click(object sender, EventArgs e)
        {
            if (txtScreen.Text.Length == 0) txtScreen.Text = "5";
            else txtScreen.Text = txtScreen.Text + "5";
        }

        private void button6_Click(object sender, EventArgs e)
        {
            if (txtScreen.Text.Length == 0) txtScreen.Text = "6";
            else txtScreen.Text = txtScreen.Text + "6";
        }

        private void button7_Click(object sender, EventArgs e)
        {
            if (txtScreen.Text.Length == 0) txtScreen.Text = "7";
            else txtScreen.Text = txtScreen.Text + "7";
        }

        private void button8_Click(object sender, EventArgs e)
        {
            if (txtScreen.Text.Length == 0) txtScreen.Text = "8";
            else txtScreen.Text = txtScreen.Text + "8";
        }

        private void button9_Click(object sender, EventArgs e)
        {
            if (txtScreen.Text.Length == 0) txtScreen.Text = "9";
            else txtScreen.Text = txtScreen.Text + "9";
        }

        private void button10_Click(object sender, EventArgs e)
        {
            txtScreen.Text = txtScreen.Text + "0";
        }

        private void button11_Click(object sender, EventArgs e)
        {
            txtScreen.Text = txtScreen.Text + ",";
        }


    }
}
