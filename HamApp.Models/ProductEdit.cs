using HamApp.Data;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HamApp.Models
{
    public class ProductEdit
    {
        public int Id { get; set; }
        public string ProductName { get; set; }
        public decimal Cost { get; set; }
        public int Count { get; set; }
        public string Description { get; set; }
     
        public int CategoryID { get; set; }
      
    }
}
