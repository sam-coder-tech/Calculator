using System;
using System.Windows.Forms;
using System.Data;

namespace Calculator
{
    public partial class Calculator : Form
    {
        // Variables to store the values and state
        private string currentCalculation = "";

        public Calculator()
        {
            InitializeComponent();
        }

        // Unified Click event for all Number buttons (0-9 and .)
        private void button_Click(object sender, EventArgs e)
        {
            currentCalculation += (sender as Button).Text;
            textBox_Result.Text = currentCalculation;
        }
        // Result (=) button logic
        private void btnResult_Click(object sender, EventArgs e)
        {
           string formattedCalculation = currentCalculation.ToString();
            try
            {
                textBox_Result.Text = new DataTable().Compute(formattedCalculation, null).ToString();
                currentCalculation = textBox_Result.Text;
            }
            catch (Exception ex)
            {
                textBox_Result.Text = "ERROR";
                currentCalculation = "";
            }
        }

        private void btnAll_Click(object sender, EventArgs e)
        {
            textBox_Result.Text = "0";
            currentCalculation = "";
        }

        private void button_clearEntry_click(object sender, EventArgs e)
        {
            if (currentCalculation.Length > 0)
            {
                currentCalculation = currentCalculation.Remove(currentCalculation.Length - 1, 1);
            }
            textBox_Result.Text = currentCalculation;
        }
    }   
}
