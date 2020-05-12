using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Cors;
using video.Models;
namespace video.Controllers.API
{
    //[EnableCors(origins: "https://localhost:44310/api/Customers/", headers: "*", methods: "*")]
    
    public class CustomersController : ApiController
    {
        videocontext _context;
        public  CustomersController()
        {
            _context = new videocontext();
        }

        //get--//api/Customers
        [HttpGet,HttpHead]
        public IEnumerable<Customer> GetCustomer(string query=null)
        {

            var customerquery = _context.Customers.ToList();
           
            if (!string.IsNullOrWhiteSpace((query)))
                 customerquery = customerquery.Where(c => (c.name.ToUpper()).Contains(query.ToUpper())).ToList();
                

           
            return customerquery;
        }

        //get--//api/Customer/1

        public Customer GetCustomer(int id)
        {
            var customer = _context.Customers.Single(c => c.id==id);
            if(customer==null)
            {
                throw new HttpResponseException(HttpStatusCode.NotFound);
            }
            return customer;
        }
        //post--//api/CreateCustomer/1
        [HttpPost]
        public IHttpActionResult CreateCustomer(Customer customer)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }
            _context.Customers.Add(customer);
            _context.SaveChanges();
            return Created(new Uri(Request.RequestUri+"/"+customer.id),customer);
        }
        //put==//api/updateCustomer/1
        [HttpPut]
        public void updateCustomer(int id,Customer customer)
        {
            if (!ModelState.IsValid)
            {
                throw new HttpResponseException(HttpStatusCode.BadRequest);
            }

            var customerindb = _context.Customers.Single(c => c.id == id);
            customerindb.name = customer.name;
            customerindb.address = customer.address;
            customerindb.birthdate = customer.birthdate;
            customerindb.IsSubscribedToNewsLetter = customer.IsSubscribedToNewsLetter;
            customerindb.MembershipTypeId = customer.MembershipTypeId;
            _context.SaveChanges();
           // return customer;
        }
        [HttpDelete]
        public void deleteCustomer(int id)
        {
            var customer = _context.Customers.Single(c => c.id == id);
            if (customer == null)
            {
                throw new HttpResponseException(HttpStatusCode.NotFound);
            }
            _context.Customers.Remove(customer);
            _context.SaveChanges();
            

        }



    }
}
