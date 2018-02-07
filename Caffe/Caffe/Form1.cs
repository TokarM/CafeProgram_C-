/* 
  Mykola Tokar
  Assignment CafeWithFiles
  
  This program calcutes the price and taxes for picked items and has the ability to change the price of the items. 
 
*/
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
using Microsoft.VisualBasic.FileIO;
using System.Data.OleDb;

namespace WindowsFormsApplication1
{
    public partial class Form1 : Form
   //Here is my variables
    {
        double SubTotal;
        double TaxAmount;
        double Total;
        int q;
        
       

        List<CafeMenuItem> ItemsList = new List<CafeMenuItem>();

        public Form1()
        {
            InitializeComponent();
        }
    
        private void Form1_Load(object sender, EventArgs e)
        {
            OleDbConnection conn;
            OleDbDataAdapter adapter;
            DataSet dataset;

      

        //This is my defaul value for price changing text boxes
        textBox1.Text = "Small Coffee";
            textBox2.Text = "1.25";
            textBox3.Text = "0";

            //Here I read the text file fill up the generic list with value
            //Then I putted these values to listboxes
            CafeMenuItem c;
            string [] currentRow = new string[3];
            string sql;
            //Here I accessed my database file
            try
            {
                using (TextFieldParser myReader = new TextFieldParser("CafeMenu.csv"))
                {
                    myReader.TextFieldType = FieldType.Delimited;
                    myReader.SetDelimiters(",");
                    while (!myReader.EndOfData)
                    {
                        currentRow = myReader.ReadFields();
                        c = new CafeMenuItem();
                        c.name = currentRow[0];
                        c.price = Double.Parse(currentRow[1]);
                        ItemsList.Add(c);
                    }

                }
                
            }
            //This is my exceptions
            catch (System.IO.FileNotFoundException ex)
            {
                MessageBox.Show(ex.Message);
            }
            catch (MalformedLineException ex)
            {
                MessageBox.Show(ex.Message);

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }



            //Here I filled up the list boxes
            foreach (CafeMenuItem i in ItemsList)
            {
                listBox1.Items.Add(i.name);
                listBox2.Items.Add(i.price);
            }
            foreach (CafeMenuItem i in ItemsList)
            {
                listBox6.Items.Add(i.name);
            }

        }
        
        // Here is an event of picking the items. When user click on the item, the name of this item
        // appear in list box 3 and price for this item in list box 4
        // Also here I adding price to the subtotal amount
        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            CafeMenuItem[] list = ItemsList.ToArray();
            int a = listBox1.SelectedIndex;
            listBox3.Items.Add(listBox1.SelectedItem.ToString());
            listBox4.Items.Add(list[a].price);
            SubTotal = SubTotal + list[a].price;
            
        }
        // Here is an event of removing the items. When user click on the item in list box 3, the name of this item
        // disappear from list box 3 and price for this item disappear from list box 4
        // Also here I subtruct price from the subtotal amount 
        private void listBox3_Click(object sender, EventArgs e)
        {
            int i;
            i = listBox3.SelectedIndex;
            listBox3.Items.Remove(listBox3.SelectedItem);
            double d = Convert.ToDouble(listBox4.Items[i]);
            SubTotal = SubTotal - d;
            listBox4.Items.RemoveAt(i);

        }
       // Calculations
        private void button1_Click(object sender, EventArgs e)
        {
            CafeMenuItem i = new CafeMenuItem();

            TaxAmount = SubTotal * CafeMenuItem.TAX_RATE;
            Total = SubTotal + TaxAmount;

            listBox5.Items.Add(" Subtotal is : " + SubTotal);
            listBox5.Items.Add(" Tax is : " + Math.Round(TaxAmount, 2));
            listBox5.Items.Add(" Total is : " + Math.Round(Total, 2));

            
        }
        // Clear Buttom
        private void button2_Click(object sender, EventArgs e)
        {
            listBox3.Items.Clear();
            listBox4.Items.Clear();
            listBox5.Items.Clear();
            SubTotal = 0.0;
        }
        // Exit Buttom
        private void button3_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void listBox2_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        //This is my button for price changing
        private void button4_Click(object sender, EventArgs e)
        {
            CafeMenuItem[] list = ItemsList.ToArray();
            list[q].price = Double.Parse(textBox3.Text);


            //Here I rewrite the text file with new value
            using (TextWriter sw = new StreamWriter("CafeMenu.csv"))
            {
                for (int i = 0; i < list.Length; i++)
                {
                    sw.WriteLine("{0},{1}", list[i].name, list[i].price.ToString());
                }
            }

            textBox1.Text = "";
            textBox2.Text = "";
            textBox3.Text = "";

            MessageBox.Show("The Price for " + list[q].name + " is changed for $" + list[q].price);

        }
        //This is a list box where user can pick the item to change the price of this item
       private void listBox6_SelectedIndexChanged(object sender, EventArgs e)
        {
            CafeMenuItem[] list = ItemsList.ToArray();
            textBox1.Text = listBox6.SelectedItem.ToString();
            q = listBox6.SelectedIndex;
            textBox2.Text = list[q].price.ToString();

        }
        //This is my "Refresh" buttom. This button refresh the list boxes, so the changed values will appear in there.
        private void button5_Click(object sender, EventArgs e)
        {

            listBox1.Items.Clear();
            listBox2.Items.Clear();
            listBox3.Items.Clear();
            listBox4.Items.Clear();
            listBox6.Items.Clear();
            foreach (CafeMenuItem i in ItemsList)
            {
                listBox1.Items.Add(i.name);
                listBox2.Items.Add(i.price);
            }
            foreach (CafeMenuItem i in ItemsList)
            {
                listBox6.Items.Add(i.name);
            }
        }
    }
}
