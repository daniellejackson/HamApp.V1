using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HamApp.Models
{
    public class ProductCreate
    {
        public int Id { get; set; }
        public string ProductName { get; set; }
        public decimal Cost { get; set; }
        public string Description { get; set; }
    }
}
