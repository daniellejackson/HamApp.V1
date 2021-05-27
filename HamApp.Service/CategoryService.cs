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
    public class CategoryService
    {
        // private readonly ApplicationDbContext _context = new ApplicationDbContext();

        private readonly Guid _userId;

        public CategoryService(Guid userId)
        {
            _userId = userId;
        }

        public bool CreateCategory(CategoryCreate model)
        {
            var entity =
                new Category()
                {
                    OwnerId = _userId,
                    Name = model.Name

                };
            using (var ctx = new ApplicationDbContext())
            {
                ctx.Categories.Add(entity);
                return ctx.SaveChanges() == 1;

            }
            //var category = new Category
            //{
            //    Name = model.Name
            //};

            //_context.Categories.Add(category);
            //return _context.SaveChanges() > 0;
        }

        public IEnumerable<CategoryListItem> GetCategories()
        {
            using (var ctx = new ApplicationDbContext())
            {
                var query =
                    ctx
                    .Categories
                    .Where(e => e.OwnerId == _userId)
                    .Select(
                        e =>
                        new CategoryListItem
                        {
                            Id = e.Id,
                            Name = e.Name
                        }
                        );
                return query.ToArray();
            }

        }
        public CategoryDetail GetCategoryById(int id)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity =
                    ctx
                    .Categories
                    .Single(e => e.Id == id && e.OwnerId == _userId);
                return
                    new CategoryDetail
                    {
                        Id = entity.Id,
                        Name = entity.Name
                    };
            }
        }

        public bool UpdateCategory(CategoryEdit model)
        {
            using(var ctx = new ApplicationDbContext())
            {
                var entity =
                    ctx
                    .Categories
                    .Single(e => e.Id == model.Id && e.OwnerId == _userId);

                entity.Name = model.Name;

                return ctx.SaveChanges() == 1;
            }
        }

        public bool DeleteCategory(int Id)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity =
                    ctx
                    .Categories
                    .Single(e => e.Id == Id && e.OwnerId == _userId);

                ctx.Categories.Remove(entity);
                return ctx.SaveChanges() == 1;
            }
        }

    }
}
