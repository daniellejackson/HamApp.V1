using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HamApp.Data
{
    public class Product
    {
        [Key]
        public int Id { get; set; }
        public Guid OwnerId { get; set; }
        public string ProductName { get; set; }
        public decimal Cost { get; set; }
        public int Count { get; set; }
        public string Description { get; set; }
        [ForeignKey(nameof(Category))]
        public int CategoryID { get; set; }
        public virtual Category Category { get; set; }


       

      
    }
}
