using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ASP.NET_Car.Models
{
    public class ShoppingCart
    {
        public int ID{ get; set; }
        public decimal Value 
        {
            get
            {
                decimal value = 0;
                foreach (var item in ShoppingList)
                    value =+ item.Price;
                return value;
            }
            set { }
        }
        public List<Cars> ShoppingList{ get; set; }
    }
}
