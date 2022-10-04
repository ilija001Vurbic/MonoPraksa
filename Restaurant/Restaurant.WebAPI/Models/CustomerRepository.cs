using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;

namespace Restaurant.WebAPI.Models
{
    public class CustomerRepository
    {
        private List<CustomerViewModel> customers = new List<CustomerViewModel>();
        private int nextId = 1;
        public CustomerRepository()
        {
            Add(new CustomerViewModel { FirstName = "John", LastName = "Doe", Phone = 1234567890, Address = "Oak Street 12", Order = new OrderViewModel { Id = 1, CustomerId = 1, Price = 156 } });
            Add(new CustomerViewModel { FirstName = "Ethan", LastName = "Payne", Phone = 1234567890, Address = "Olive Street 12", Order = new OrderViewModel { Id = 2, CustomerId = 2, Price = 190 } });
            Add(new CustomerViewModel { FirstName = "Jack", LastName = "Johnson", Phone = 1234567890, Address = "Left Street 12", Order = new OrderViewModel { Id = 3, CustomerId = 3, Price = 123 } });
            Add(new CustomerViewModel { FirstName = "Anna", LastName = "Oliviera", Phone = 1234567890, Address = "Right Street 12", Order = new OrderViewModel { Id = 4, CustomerId = 4, Price = 256 } });

        }
        [HttpGet]
        public IEnumerable<CustomerViewModel> GetAll()
        {
            return customers;
        }
        [HttpGet]
        public CustomerViewModel GetCustomerById(int id)
        {
            return customers.Find(c => c.Id == id);
        }
        [HttpPost]
        public CustomerViewModel Add(CustomerViewModel customer)
        {
            if (customer == null)
                throw new ArgumentNullException();
            customer.Id = nextId++;
            customers.Add(customer);
            return customer;
        }
        [HttpPut]
        public bool Update(CustomerViewModel customer)
        {
            if (customer == null)
                throw new ArgumentNullException("customer");
            customers.Remove(customers.First(c=>c.Id==customer.Id));
            customers.Add(customer);
            return true;
        }
        [HttpDelete]
        public void Remove(int id)
        {
            customers.RemoveAll(c => c.Id == id);
        }
    }
}