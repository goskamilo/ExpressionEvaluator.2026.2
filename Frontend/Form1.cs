
using Backend;

namespace Frontend { 
   
public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        private void button17_Click(object sender, EventArgs e)
        {
            txtScreen.Text = "";
            txtScreen.Text = txtScreen.Text + "0";
        }

        private void button14_Click(object sender, EventArgs e)
        {
            if (txtScreen.Text.Length > 0)
            {
                txtScreen.Text = txtScreen.Text.Substring(0, txtScreen.Text.Length - 1);
            }
        }

        private void btn0_Click(object sender, EventArgs e)
        {
            txtScreen.Text = txtScreen.Text + "0";
        }

        private void button11_Click(object sender, EventArgs e)
        {
            txtScreen.Text = txtScreen.Text + ",";
        }


        private void button1_Click(object sender, EventArgs e)
        {
            if (txtScreen.Text.Length == 0) txtScreen.Text = "1";
            else txtScreen.Text = txtScreen.Text + "1";
        }
        private void btn2_Click(object sender, EventArgs e)
        {
            if (txtScreen.Text.Length == 0) txtScreen.Text = "2";
            else txtScreen.Text = txtScreen.Text + "2";
        }

        private void btn3_Click(object sender, EventArgs e)
        {
            if (txtScreen.Text.Length == 0) txtScreen.Text = "3";
            else txtScreen.Text = txtScreen.Text + "3";
        }

        private void btn4_Click(object sender, EventArgs e)
        {
            if (txtScreen.Text.Length == 0) txtScreen.Text = "4";
            else txtScreen.Text = txtScreen.Text + "4";
        }

        private void btn5_Click(object sender, EventArgs e)
        {
            if (txtScreen.Text.Length == 0) txtScreen.Text = "5";
            else txtScreen.Text = txtScreen.Text + "5";
        }

        private void btn6_Click(object sender, EventArgs e)
        {
            if (txtScreen.Text.Length == 0) txtScreen.Text = "6";
            else txtScreen.Text = txtScreen.Text + "6";
        }

        private void btn7_Click(object sender, EventArgs e)
        {
            if (txtScreen.Text.Length == 0) txtScreen.Text = "7";
            else txtScreen.Text = txtScreen.Text + "7";
        }

        private void btn8_Click(object sender, EventArgs e)
        {
            if (txtScreen.Text.Length == 0) txtScreen.Text = "8";
            else txtScreen.Text = txtScreen.Text + "8";
        }

        private void btn9_Click(object sender, EventArgs e)
        {
            if (txtScreen.Text.Length == 0) txtScreen.Text = "9";
            else txtScreen.Text = txtScreen.Text + "9";
        }

        private void btnResult_Click(object sender, EventArgs e)
    {
        // Guarda la expresión que aparece en pantalla.
        string infix = txtScreen.Text;

        try
        {
           
            // Convierte la coma decimal ingresada por el usuario
            // en punto para que el Backend pueda procesarla.
            infix = infix.Replace(',', '.');

            // Envía la expresión completa al Backend.
            double result = ExpressionEvaluator.Evalute(infix);

            
            // Convierte el resultado nuevamente a coma
            // para mostrarlo de la misma forma que lo ingresó el usuario.
            txtScreen.Text = result.ToString().Replace('.', ',');
        }
        catch (Exception ex)
        {
            MessageBox.Show(
            $"Error: {ex.Message}",
            "Calculation Error",
            MessageBoxButtons.OK,
            MessageBoxIcon.Error
            );
        }
    }

    private void btnPabr_Click(object sender, EventArgs e)
        {
            if (txtScreen.Text.Length == 0) txtScreen.Text = "(";
            else txtScreen.Text = txtScreen.Text + "(";
        }

        private void btnPcer_Click(object sender, EventArgs e)
        {
            if (txtScreen.Text.Length == 0) txtScreen.Text = ")";
            else txtScreen.Text = txtScreen.Text + ")";
        }

        private void BtnMulti_Click(object sender, EventArgs e)
        {
            if (txtScreen.Text.Length == 0) txtScreen.Text = "*";
            else txtScreen.Text = txtScreen.Text + "*";
        }

        private void btnDiv_Click(object sender, EventArgs e)
        {
            if (txtScreen.Text.Length == 0) txtScreen.Text = "/";
            else txtScreen.Text = txtScreen.Text + "/";
        }

        private void btnSuma_Click(object sender, EventArgs e)
        {
            if (txtScreen.Text.Length == 0) txtScreen.Text = "+";
            else txtScreen.Text = txtScreen.Text + "+";
        }

        private void btnResta_Click(object sender, EventArgs e)
        {
            if (txtScreen.Text.Length == 0) txtScreen.Text = "-";
            else txtScreen.Text = txtScreen.Text + "-";
        }

        private void button20_Click(object sender, EventArgs e)
        {
            if (txtScreen.Text.Length == 0) txtScreen.Text = "^";
            else txtScreen.Text = txtScreen.Text + "^";
        }
    
    }
}
