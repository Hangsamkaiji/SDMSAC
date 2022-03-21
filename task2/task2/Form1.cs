using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace task2
{
    public partial class Form1 : Form
    {
        public float totalProfit = 0;
        public string salePrice;
        public float purchasePrice;

        string filePath = @"C:\Users\Hangs\OneDrive\Desktop\SDM Practise SAC\task2\profitCSV.txt";
        public List<string> lines = new List<string>();


        public Form1()
        {


            InitializeComponent();

            lines = File.ReadAllLines(filePath).ToList();
            dataGridView1.ColumnCount = 8;


            foreach (var line in lines)
            {
                float profit = 0;
                List<string> fields = line.Split(',').ToList();
                salePrice = fields[5];
                purchasePrice = float.Parse(fields[3]);
                if (float.TryParse(salePrice, out float _salePrice))
                {
                    profit = _salePrice - purchasePrice;

                }
                else
                {
                    profit = (purchasePrice) * -1;


                }
                
                fields.Add(profit.ToString());
                totalProfit = totalProfit + profit;
                dataGridView1.Rows.Add(fields.ToArray());



            }
            dataGridView1.Rows.Add("", "", "", "", "","","Total Profit", "$" + totalProfit);










        }

        private void btnCalculate_Click(object sender, EventArgs e)
        {
           


        }




        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

    }
}

