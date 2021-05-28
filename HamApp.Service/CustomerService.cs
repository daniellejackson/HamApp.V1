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
    public class CustomerService
    {
        private readonly Guid _userId;
        public CustomerService(Guid Id)
        {
            _userId = Id;
        }

        public bool CreateCustomer(CustomerCreate model)
        {
            var entity =
                new Customer()

                {
                    OwnerId = _userId,
                    Name = model.Name
                };
            using (var ctx = new ApplicationDbContext())
            {
                ctx.Customers.Add(entity);
                return ctx.SaveChanges() == 1;
            }

        }
        public IEnumerable<CustomerListItem> GetCustomers()
        {
            using (var ctx = new ApplicationDbContext())
            {
                var query =
                   ctx
                     .Customers
                     .Where(e => e.OwnerId == _userId)
                     .Select(
                       e =>

                        new CustomerListItem
                        {
                            Id = e.Id,
                            Name = e.Name,

                        }
                );

                return query.ToArray();
            }

        }
        public CustomerDetail GetCustomerById(int id)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity =
                    ctx
                    .Customers
                    .Single(e => e.OwnerId == _userId);
                return new CustomerDetail
                {
                    Id = entity.Id,
                    Name = entity.Name

                };
            }
        }

        public bool UpdateCustomer(CustomerEdit model)
        {
            using(var ctx = new ApplicationDbContext())
            {
                var entity =
                    ctx
                    .Customers.Single(e => e.Id == model.Id && e.OwnerId == _userId);

                entity.Id = model.Id;
                entity.Name = model.Name;

                return ctx.SaveChanges() == 1;
            }
        }

        public bool DeleteCustomer(int Id)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity =
                ctx
                .Customers
                .Single(e => e.Id == Id && e.OwnerId == _userId);

                ctx.Customers.Remove(entity);

                return ctx.SaveChanges() == 1;
            }
        }

    }
}
