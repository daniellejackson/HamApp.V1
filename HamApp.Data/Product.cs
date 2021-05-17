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
        public string ProductName { get; set; }
        public decimal Cost { get; set; }
        public int Count { get; set; }

        //use foreign key .... 
        [ForeignKey(nameof(Category))]
        public int CategoryID { get; set; }
        public virtual Category Category { get; set; }


        [ForeignKey(nameof(Inventory))]
        public int InventoryID { get; set; }
        public virtual Inventory Inventory{ get; set; }

        public virtual List<Transaction> Transactions { get; set; }
    }
}
