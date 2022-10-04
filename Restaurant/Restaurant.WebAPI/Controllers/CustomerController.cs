using Restaurant.WebAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web;
using System.Web.Http;
using System.Web.Mvc;

namespace Restaurant.WebAPI.Controllers
{
    public class CustomerController : ApiController
    {
        CustomerRepository repository = new CustomerRepository();

        // GET: api/customer/getallcustomers
        public IEnumerable<CustomerViewModel> GetAllCustomers()
        {
            return repository.GetAll();
        }
        // GET api/customer/getbyid/id
        public HttpResponseMessage GetById(int id)
        {
            CustomerViewModel customer = new CustomerViewModel();
            if (customer == null)
            {
                return Request.CreateResponse(HttpStatusCode.NotFound, id);
            }
            customer = repository.GetCustomerById(id);
            return Request.CreateResponse(HttpStatusCode.OK, customer);
        }
        // POST: 
        public HttpResponseMessage Post(CustomerViewModel customer)
        {
            customer = repository.Add(customer);
            return Request.CreateResponse<CustomerViewModel>(HttpStatusCode.Created, customer);
        }
        //PUT
        public HttpResponseMessage Put(int id, CustomerViewModel customer)
        {
            customer.Id = id;
            if(repository.Update(customer)==false)
                return Request.CreateResponse(HttpStatusCode.NotFound, id);
            return Request.CreateResponse(HttpStatusCode.OK, customer);
        }
        //DELETE
        public HttpResponseMessage Delete(int id)
        {
            CustomerViewModel customer = repository.GetCustomerById(id);
            if (customer == null)
            {
                return Request.CreateResponse(HttpStatusCode.NotFound, id);
            }
            repository.Remove(id);
            return Request.CreateResponse(HttpStatusCode.OK, customer);
        }
    }
}