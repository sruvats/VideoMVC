using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using video.Models;
using System.Data.Entity.Validation;
using video.ViewModels;

namespace video.Controllers
{
    public class CustomerController : Controller
    {
        private videocontext _context = new videocontext();
        public ActionResult Index()
        {
            

            var Customer = _context.Customers.Include("MembershipType").ToList(); 
            
            return View(Customer);
        }
        public ActionResult Details(int? id)
        {
           

            Customer cust = _context.Customers.Include("MembershipType").SingleOrDefault(c => c.id == id);

            if (cust == null)
            {
                HttpNotFoundResult noresult = new HttpNotFoundResult();
                return noresult;
            }
            return View(cust);
            
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Customer Customer)
        {

            videocontext _context = new videocontext();
            if (!ModelState.IsValid)
            {
                CustomerViewModel cvm = new CustomerViewModel
                {
                    Customer = Customer,
                    MembershipType = _context.MembersipTypes.ToList()

                };
                return View("New",cvm);
           
            }


            if (Customer.id == 0)
            {
                _context.Customers.Add(Customer);
            }
            else
            {
                var customerindb = _context.Customers.Single(c=>c.id== Customer.id);

                customerindb.name = Customer.name;
                customerindb.address = Customer.address;
                customerindb.birthdate = Customer.birthdate;
                customerindb.IsSubscribedToNewsLetter = Customer.IsSubscribedToNewsLetter;
                customerindb.MembershipTypeId = Customer.MembershipTypeId;
            }
            try
            {
                _context.SaveChanges();
            }
            catch (DbEntityValidationException e)
            {
                Console.WriteLine(e);
            }
            return RedirectToAction("Index","Customer") ;
        }
        public ActionResult Edit(int id)
        {
            videocontext _context = new videocontext();
          var customer=  _context.Customers.SingleOrDefault(c=>c.id==id);
            if(customer==null)
            {
                return HttpNotFound();
            }
            CustomerViewModel cvm = new CustomerViewModel
            {
                  Customer=customer,
                  MembershipType=_context.MembersipTypes.ToList()

            };
            return View("New",cvm);
        }

        public ActionResult New()
        {
            var membershipType = _context.MembersipTypes.ToList();
            var customerViewModel = new CustomerViewModel
            {
                Customer=new Customer(),
                MembershipType = membershipType
            };

            return View(customerViewModel);

        }

        //private IEnumerable<Customer> GetCustomers()
        //{
        //    return new List<Customer>
        //    {
        //        new Customer { id = 1, name = "John Smith",address="Texas" },
        //        new Customer { id = 2, name = "Mary Williams",address="Canada"  }
        //    };
        //}
        //// GET: Customer

    }
}