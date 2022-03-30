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

namespace task3
{
    public partial class Form1 : Form
    {
        List<Sale> lstData = new List<Sale>();
        BindingSource bs = new BindingSource();
        public string filter;

        public Form1()
        {
            InitializeComponent();
            string[] dropDown = new string[] { "textbook", "subject", "rating" };
            dropDownBox.Items.AddRange(dropDown);
            bs.DataSource = lstData;
            bs.ResetBindings(false);
            dataGridView1.DataSource = bs;
        }
        //Prompts the user to select a csv file, after spliting the file by commas inputs it to the lstData list.
        public void readCSV()
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            if(openFileDialog.ShowDialog() == DialogResult.OK)
            {
                string filepath = openFileDialog.FileName;
                List<string> lines = new List<string>();
                lines = File.ReadAllLines(filepath).Skip(1).ToList();
                foreach (var line in lines)
                {
                    List<string> tempList = line.Split(',').ToList();
                    Sale s = new Sale();

                    s.Name = tempList[0];
                    s.Subject = tempList[1];
                    s.PurchasePrice = float.Parse(tempList[4]);
                    s.SalePrice = tempList[5];
                    s.Rating = tempList[6];

                    lstData.Add(s);


                }

            }

        }

        //sorts the list by rating
        private void SortByRating(List<Sale> _lstData)
        {
            int min;
            for (int i = 0; i < _lstData.Count -1 ; i++)
            {
                min = i; 
                for (int j = i+1; j < _lstData.Count; j++)
                {
                    if (int.TryParse(lstData[j].Rating, out int ratingJ))
                    {
                        if (int.TryParse(lstData[min].Rating, out int ratingMin))
                        {
                            if (ratingJ < ratingMin)
                            {
                                min = j;
                            }


                            else
                            {
                                min = i;
                            }
                          
                        }
                        
                    }
                    if(_lstData[j].Rating == "none")
                    {
                        lstData[j].Rating = "0";
                    }
                   

                }
                var temp = _lstData[min];
                _lstData[min] = _lstData[i];
                _lstData[i] = temp;



            }


        }
        //searches the list for the target using filter as a criteria
        private List<Sale> categorySearch(string target, string filter)
        {
            List<Sale> results = new List<Sale>();
            foreach (var s in lstData)
            {
                if(filter == "textbook")
                {
                    if (s.Name.ToLower().Contains(target.ToLower()))
                    {
                        results.Add(s);
                        Console.WriteLine(target);

                    }
                    

                }
                if (filter == "subject")
                {
                    if (s.Subject.ToLower().Contains(target.ToLower()))
                    {
                        results.Add(s);
                        Console.WriteLine(target);

                    }


                }
                if (filter == "rating")
                {
                    if (s.Rating.ToLower().Contains(target.ToLower()))
                    {
                        results.Add(s);
                        Console.WriteLine(target);

                    }


                }



            }
            return results;
        }

        private void btnUpload_Click(object sender, EventArgs e)
        {
            readCSV();
            bs.DataSource = lstData;
            bs.ResetBindings(false);
        }

        private void dropDownBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            filter = dropDownBox.SelectedItem.ToString();
            if(filter == "rating")
            {
                SortByRating(lstData);
                bs.DataSource = lstData;
                dataGridView1.DataSource = bs;
                bs.ResetBindings(false);


            }

        }
       
        private void txtSearch_TextChanged(object sender, EventArgs e)
        {
            List<Sale> r = categorySearch(txtSearch.Text, filter);
            bs.DataSource = r;
            dataGridView1.DataSource = bs;
            bs.ResetBindings(false);

        }
    }
}
