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
    public class ProductService
    {
        private readonly ApplicationDbContext _context = new ApplicationDbContext();

        private readonly Guid _Id;
        public ProductService(Guid Id)
        {
            _Id = Id;
        }

        public bool CreateProduct(ProductCreate model)
        {
            var productEntity = new Product
            {
                Id = (_context.Categories.Single(c => c.Name.ToLower() == model.ProductName.ToLower())).Id,
                Cost = model.Cost,
                Description = model.Description

            };
            _context.Products.Add(productEntity);
            return _context.SaveChanges() == 1;
        }

        public IEnumerable<ProductListItem> GetAllProducts()
        {
            var productEntities = _context.Products.ToList();
            var productList = productEntities.Select(e => new ProductListItem
            {
                Id = e.Id,
                //CategoryName = (_context.Categories.Single(c => c.Id == e.CategoryId)).Name,
                ProductName = (_context.Products.Single(p => p.Id == e.Id)).ProductName,
            }).ToList().OrderByDescending(p => p.Id);
            return productList;
        }

       
    }
}
