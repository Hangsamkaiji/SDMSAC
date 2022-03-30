using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

//Hangsam Nembang SDV SAC TASK 1
namespace task1
{
    public partial class Form1 : Form
    {
        public float cumuValue = 0f;
        public Form1()
        {
            InitializeComponent();
            
        }
        //End program by clearing cumulative value
        private void button1_Click(object sender, EventArgs e)
        {
            cumuValue = 0f;
            lblCumValue.Text = "";
            lblValue.Text = "";


        }
        //accepts two float and returns the value depending if it is a negative value.
        public string currentValue(float _depreciation, float _purchasedValue)
        {
            float curValue;
            if (_depreciation > _purchasedValue)
            {
                return "It is worth $0";
            }
            else
            {
                curValue = _purchasedValue - _depreciation;
                cumuValue = cumuValue + curValue;
                lblCumValue.Text = "The collection so far is worth $" + cumuValue;
                return "It is worth $" + curValue.ToString(); ;
            }



        }
        //calculates cumulative and singular value by taking age and purchased value as input. Accounts for non parseable values.
        public string calculateValue()
        {
            float depreciation;
            //Checks if input is a parseable value, if not returns error.
            if (float.TryParse(txtPrice.Text, out float purchasedValue) && float.TryParse(txtAge.Text, out float age))
            {
                depreciation = purchasedValue * 0.2f * age;
                return currentValue(depreciation, purchasedValue).ToString();
                

            }
            else
            {
                return "Error, please enter a valid number!";
            }

        }
       
        private void btnCalculate_Click(object sender, EventArgs e)
        {
            lblValue.Text = calculateValue();
            
            txtAge.Clear();
            txtPrice.Clear();


        }
    }
}
