using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApplication1
{
    public partial class Form1 : Form
    {
        const double TAX_RATE = 0.05;
        double SubTotal;
        double TaxAmount;
        double Total;


        private Item[] list = new Item[12];
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            list[0] = new Item("Small Coffee", 1.25);
            list[1] = new Item("Large Coffee", 1.75);
            list[2]  = new Item("Cappuccino", 2.75);
            list[3] = new Item("Mocha Cappuccino", 3.25);
            list[4] = new Item("Cafe au lait", 3.00);
            list[5] = new Item("Orange Juice", 1.25);
            list[6] = new Item("Apple Juice", 1.25);
            list[7] = new Item("Bagel", 1.85);
            list[8] = new Item("Whole Wheat Bagel", 1.85);
            list[9] = new Item("Raisin Bagel", 1.85);
            list[10] = new Item("Scone", 2.25);
            list[11] = new Item("Muffin", 2.15);
            
            foreach (Item i in list)
            {
                listBox1.Items.Add(i.name);
                listBox2.Items.Add(i.price);
                
            }
       

        }

        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

            int a = listBox1.SelectedIndex;

      
            listBox3.Items.Add(listBox1.SelectedItem.ToString());
            listBox4.Items.Add(list[a].price);

            SubTotal = SubTotal + list[a].price;



            
        }
        private void listBox2_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void listBox3_SelectedIndexChanged(object sender, EventArgs e)
        {

            int b = listBox3.SelectedIndex;
          
            
            
            listBox3.Items.Remove(listBox3.SelectedItem.ToString());
            listBox4.Items.Remove(listBox4.Items);
            

            

        }

        private void button1_Click(object sender, EventArgs e)
        {
            TaxAmount = SubTotal * TAX_RATE;
            Total = SubTotal + TaxAmount;

            listBox5.Items.Add(" Subtotal is : " + SubTotal);
            listBox5.Items.Add(" Tax is : " + Math.Round(TaxAmount, 2));
            listBox5.Items.Add(" Total is : " + Math.Round(Total, 2));
            
        }

        private void button2_Click(object sender, EventArgs e)
        {
            listBox3.Items.Clear();
            listBox4.Items.Clear();
            listBox5.Items.Clear();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
      
    }
}
