using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace _005_FormAppWithAllData.Models
{
    public partial class Product
    {
        public string Name { get; set; }
        public uint Stock { get; set; }
        public decimal UnitPrice { get; set; }
        public decimal Cost { get; set; }

        public decimal Total => UnitPrice * Stock;
        public override string ToString()
        {
            return $"{Name}:{Stock * UnitPrice}";
        }
    }
}