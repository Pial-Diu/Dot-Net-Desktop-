using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Calculator
{
    public partial class BasicCalculator : Form
    {
        Double result = 0;
        String OperationPerformed = "";
        bool isOperationPerformed = false;
        public BasicCalculator()
        {
            InitializeComponent();
        }

        private void helpToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            
        }

        

        private void BasicCalculator_Load(object sender, EventArgs e)
        {
            
        }

        private void btnplu_Click(object sender, EventArgs e)
        {

        }

        private void btn_click(object sender, EventArgs e)
        {
            if (isOperationPerformed == true) textBox_Result.Clear();
            if (textBox_Result.Text == "0" || textBox_Result.Text.Contains("C")) textBox_Result.Clear();
            if (textBox_Result.Text.Contains(".") && (sender as Button).Text ==".") return;
            textBox_Result.Text += (sender as Button).Text;
            isOperationPerformed = false;
        }

        private void textBox_Result_TextChanged(object sender, EventArgs e)
        {

        }

        private void operator_click(object sender, EventArgs e)
        {
            if (result != 0)
            {
                button17_Click(this, new EventArgs());
            }
            if (textBox_Result.Text.Contains("C")) textBox_Result.Text = "0";
            Button button = (Button)sender;
            OperationPerformed = button.Text;
            result = Double.Parse(textBox_Result.Text);
            isOperationPerformed = true;
            lblCurrentOperation.Text = result + " " + OperationPerformed;
            textBox_Result.Text = "0";
        }

        private void button4_Click(object sender, EventArgs e)
        {
            String s = textBox_Result.Text;
            if (s.Length == 1) s = "0";
            else s = s.Substring(0, s.Length - 1);
            textBox_Result.Text = s;
        }

        private void button7_Click(object sender, EventArgs e)
        {
            lblCurrentOperation.Text = "";
            textBox_Result.Text = "0";
            result = 0;
        }

        private void button17_Click(object sender, EventArgs e)
        {
            isOperationPerformed = true;
            lblCurrentOperation.Text = "";
            switch(OperationPerformed)
            {
                case "+": textBox_Result.Text = (result + Double.Parse(textBox_Result.Text)).ToString();
                    break;
                case "-":
                    textBox_Result.Text = (result - Double.Parse(textBox_Result.Text)).ToString();
                    break;
                case "*":
                    textBox_Result.Text = (result * Double.Parse(textBox_Result.Text)).ToString();
                    break;
                case "/":
                    if (Double.Parse(textBox_Result.Text) == 0) textBox_Result.Text = "Can not Divide by Zero";
                    else textBox_Result.Text = (result / Double.Parse(textBox_Result.Text)).ToString();
                    break;
                case "Power":
                    textBox_Result.Text = (Math.Pow(result , Double.Parse(textBox_Result.Text))).ToString();
                    break;
                case "Mod":
                    textBox_Result.Text = (result % Double.Parse(textBox_Result.Text)).ToString();
                    break;
            }
        }

        private void CE_Click(object sender, EventArgs e)
        {
            textBox_Result.Text = "0";
        }

        private void helpToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Perform a (C) Clear All operation after each calculation to avoid unwanted error !!\n" +
                "Use (=) Equal to Button to See your result.");
        }

        private void BasicCalculator_KeyDown(object sender, KeyEventArgs e)
        {
            
            //Numbers..
            if (e.KeyCode.Equals(Keys.NumPad1))         button15.PerformClick();
            else if(e.KeyCode.Equals(Keys.NumPad2))     button14.PerformClick();
            else if (e.KeyCode.Equals(Keys.NumPad3))    button13.PerformClick();
            else if (e.KeyCode.Equals(Keys.NumPad4))    button10.PerformClick();
            else if (e.KeyCode.Equals(Keys.NumPad5))    button9.PerformClick();
            else if (e.KeyCode.Equals(Keys.NumPad6))    button8.PerformClick();
            else if (e.KeyCode.Equals(Keys.NumPad7))    button1.PerformClick();
            else if (e.KeyCode.Equals(Keys.NumPad8))    button2.PerformClick();
            else if (e.KeyCode.Equals(Keys.NumPad9))    button3.PerformClick();
            else if (e.KeyCode.Equals(Keys.NumPad0))    button20.PerformClick();

            //Backspace..
            else if (e.KeyCode.Equals(Keys.Back))       button4.PerformClick();
            else if (e.KeyCode.Equals(Keys.Enter))      button17.PerformClick();
        }

        private void BasicCalculator_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar.ToString() == "+")      button16.PerformClick();
            else if (e.KeyChar.ToString() == "-") button11.PerformClick();
            else if (e.KeyChar.ToString() == "*") button6.PerformClick();
            else if (e.KeyChar.ToString() == "/") button5.PerformClick();
            else if (e.KeyChar.ToString() == ".") button18.PerformClick();
        }
    }
}
