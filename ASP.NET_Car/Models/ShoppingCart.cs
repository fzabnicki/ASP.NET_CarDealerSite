using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ASP.NET_Car.Models
{
    public class ShoppingCart
    {
        [HiddenInput]
        public int ID{ get; set; }
        [DataType(DataType.Currency)]
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
        public virtual ICollection<Cars> ShoppingList { get; set; }
    }
}
