using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Back_End_API.Models
{
    public class Product
    {
        public int Id { get; set; }
        public decimal SoldPrice { get; set; }
        public decimal CostPrice { get; set; }
        public string Name { get; set; }
        public bool DisplayStatus { get; set; }
    }
}
