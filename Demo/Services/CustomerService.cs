using Demo.Data;
using Demo.Data.Models;
using Microsoft.EntityFrameworkCore;

namespace Demo.Services
{
    public class CustomerService
    {
        private IDbContextFactory<DemoDbContext> _dbContextFactory;
        public CustomerService(IDbContextFactory<DemoDbContext> dbContextFactory)
        {
            _dbContextFactory = dbContextFactory;
        }
        public void AddCustomer(Customer customer)
        {
            using(var context = _dbContextFactory.CreateDbContext())
            {
                context.Customers.Add(customer);
                context.SaveChanges();
            }
        }

        public Customer GetCustomerByName(string name)
        {
            using (var context = _dbContextFactory.CreateDbContext())
            {
                var customer = context.Customers.SingleOrDefault(x => x.Name == name);
                return customer;
            }
        }

        public void UpdateCustomerByName(string name, int age)
        {
            var customer = GetCustomerByName(name);
            if(customer == null) 
            {
                throw new Exception("Customer does not exist. Cannot Update!");
            }
            customer.Age = age;
            using (var context = _dbContextFactory.CreateDbContext())
            {
                context.Update(customer);
                context.SaveChanges();
            }
        }

        public void RemoveCustomerByName(string name)
        {
            var customer = GetCustomerByName(name);
            if (customer == null)
            {
                throw new Exception("Customer does not exist. Cannot Update!");
            }
            using (var context = _dbContextFactory.CreateDbContext())
            {
                context.Remove(customer);
                context.SaveChanges();
            }
        }
    }
}
