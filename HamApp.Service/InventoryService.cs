using HamApp.Data;
using HamApp.Models;
using HamApp.V1.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HamApp.Service
{
    public class InventoryService
    {
        private readonly ApplicationDbContext _context = new ApplicationDbContext();

        private readonly Guid _Id;
        public InventoryService(Guid Id)
        {
            _Id = Id;
        }

        //public bool CreateInventory(InventoryCreate inventory)
        //{
        //    var entity = new Inventory

        //    {
        //        Id= Inventory.Id
        //    };



        //    _context.Inventories.Add(entity);
        //    return _context.SaveChanges() == 1;

        //}
        //public IEnumerable<InventoryListItem> GetInventories()
        //{
        //    var query =
        //    _context.Inventories.Select(e =>

        //                new InventoryListItem
        //                {
        //                    Id = e.Id,
                           

        //                }
        //        );

        //    return query.ToArray();

        //}

        
        //public ICollection<InventoryListItem> ConvertStoryToListItemForWriter(ICollection<Inventory> stories)
        //{
        //    var listOfItems = new List<InventoryListItem>();
        //    foreach (Inventory inventory in inventories)
        //    {
        //        var listItem = new InventoryListItem();
        //        listItem.Id = inventory.Id;
               
        //        listOfItems.Add(listItem);

        //    }
        //    return listOfItems;
        //}


        //public bool UpdateInventory(InventoryEdit model)
        //{

        //    var entity =
        //        _context.Inventories
        //        .Single(e => e.Id == model.Id && e.Id == _Id);
        //    entity.Id = model.Id;





        //    return _context.SaveChanges() == 1;
        //}

        //public bool DeleteInventory(int Id)
        //{
        //    var entity =
        //        _context.Inventories
        //        .Single(e => e.Id == Id && e.Id == _Id);
        //    _context.Inventories.Remove(entity);
        //    return _context.SaveChanges() == 1;
        //}




    }
}
