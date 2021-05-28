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


        private readonly Guid _userId;
        public ProductService(Guid Id)
        {
            _userId = Id;
        }

        public bool CreateProduct(ProductCreate model)
        {
            var entity =
                new Product()
                {
                    OwnerId = _userId,
                    ProductName = model.ProductName,
                    Cost = model.Cost,
                    Description = model.Description,
                    CategoryID = model.CategoryID

                };
            using (var ctx = new ApplicationDbContext())
            {
                ctx.Products.Add(entity);
                return ctx.SaveChanges() == 1;
            }
        }

        public IEnumerable<ProductListItem> GetProducts()
        {
            using (var ctx = new ApplicationDbContext())
            {
                var query =
                    ctx
                    .Products.Where(e => e.OwnerId == _userId)
                    .Select(
                        e =>
                        new ProductListItem
                        {
                            Id = e.Id,
                            ProductName = e.ProductName,
                            CategoryID = e.CategoryID

                        }
                        );
                return query.ToArray();
            }



        }
        public ProductDetail GetProductById(int id)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity =
                    ctx
                    .Products
                    .Single(e => e.Id == id && e.OwnerId == _userId);
                return
                    new ProductDetail
                    {
                        ProductName = entity.ProductName,
                        Cost = entity.Cost,
                        Description = entity.Description,
                        Count = entity.Count,
                        CategoryID = entity.CategoryID

                    };
            }
        }

        public bool UpdateProduct(ProductEdit model)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity =
                    ctx
                    .Products
                    .Single(e => e.Id == model.Id && e.OwnerId == _userId);

                entity.ProductName = model.ProductName;
                entity.Cost = model.Cost;
                entity.Count = model.Count;
                entity.Description = model.Description;
                entity.CategoryID = model.CategoryID;
                    return ctx.SaveChanges() == 1;

            }
              

        }

        public bool DeleteProduct(int Id)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity =
                    ctx
                    .Products
                    .Single(e => e.Id == Id && e.OwnerId == _userId);
                ctx.Products.Remove(entity);
                return ctx.SaveChanges() == 1;
            }
        }
    }
}
