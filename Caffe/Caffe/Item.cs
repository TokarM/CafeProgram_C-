using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WindowsFormsApplication1
{
    class Item
    {
        public string name { get; set; }
        public double price {get; set;}
    

       /*  public override string ToString()
        {
            string myState;
            myState = string.Format("[Price: {0}]", price );
            return myState; 
        } */
        
    public Item()
{
    name = " ";
    price = 0.0;
}
    public Item(string name, double price)
    {
        this.name = name;
        this.price = price;
    }
    
}
}