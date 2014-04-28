using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
/*Program: Total Sales
  Author: Kyle McBride A02609917
  Date: 04/28/2014
  Description: In the Chap07 folder of the Student Sample Programs, you will find a file named Sales.txt. 
               Figure 7-44 shows the file’s contents displayed in Notepad. Create an application that reads 
               this file’s contents into an array, displays the array’s contents in a ListBox control, and 
               calculates and displays the total of the array’s values.
                                          ***SEE CHANGELOG IN SOLUTION DIRECTORY***				*/

namespace Total_Sales
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void displayButton_Click(object sender, EventArgs e)
        {
            //declaring array
            const int SIZE = 100;
            decimal[] sales = new decimal[SIZE];

            //varible to hold amount stored in array
            int count = 0;

            decimal additionHolder = 0;

            //declaring streamreader
            StreamReader inputFile;

            //opening the sales file
            inputFile = File.OpenText("../../Sales.txt");

            try
            {
                //pull contents from file into array while there is still items
                //to pull and the array isnt full
                while (!inputFile.EndOfStream && count < sales.Length)
                {
                    sales[count] = decimal.Parse(inputFile.ReadLine());
                    count++;
                }
                //close the file
                inputFile.Close();

                //display contents in listbox
                for (int index = 0; index < count; index++)
                {
                    outputListBox.Items.Add(sales[index]);
                }

                
                //add all the values
                for (int index = 0; index < sales.Length; index++)
                {
                    additionHolder += sales[index];
                }
                //display total of all values
                outputListBox.Items.Add("Total =" + additionHolder);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    }
}
