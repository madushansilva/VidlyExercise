using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using VidlyModified.Models;
using System.Data.Entity;
using VidlyModified.ViewModel;

namespace VidlyModified.Controllers
{
    public class CustomerController : Controller
    {
        // GET: Customer

        private ApplicationDbContext _context;

        public CustomerController()
        {
            _context = new ApplicationDbContext();
        }

        protected override void Dispose(bool disposing)
        {
            _context.Dispose();
        }
        public ActionResult Index()
        {
            //var customer = GetCustomers();
          //  var customer = _context.Customer.Include(c => c.MemberShipType).ToList();

            return View();
        }


        public ActionResult Detail(int id)
        {

            // var customer = GetCustomers().SingleOrDefault(c => c.Id == id);
            var customer = _context.Customer.SingleOrDefault(c => c.Id == id);
            if (customer == null)
                return HttpNotFound();
                return View(customer);
        }

        public ActionResult NewCustomer()
        {
            var membershipTypes = _context.MemberShipType.ToList();
            var viewModel = new NewCustomerViewModel {

                MemberShipType = membershipTypes,
                 Customer= new Customer()
            };
            return View("CustomerForm",viewModel);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Save(Customer customer)
        {
            if (!ModelState.IsValid)
            {
                var viewModel = new NewCustomerViewModel {
                    Customer = customer,
                    MemberShipType = _context.MemberShipType.ToList()
                };
                return View("CustomerForm", viewModel);
            }


            if(customer.Id==0)
            _context.Customer.Add(customer);

            else
            {
                var customerInDb = _context.Customer.Single(c => c.Id == customer.Id);
                customerInDb.Name = customer.Name;
                customerInDb.BirthDay = customer.BirthDay;
                customerInDb.MemberShipType = customer.MemberShipType;
                customerInDb.IsSubscribedToNewsletter = customer.IsSubscribedToNewsletter;
            }
            _context.SaveChanges();
            return RedirectToAction("Index", "Customer");
        }

        public ActionResult Edit(int id)
        {

            var customer = _context.Customer.SingleOrDefault(c => c.Id == id);
            if (customer == null)
                return HttpNotFound();
            var viewModel = new NewCustomerViewModel {

                Customer = customer,
                MemberShipType = _context.MemberShipType.ToList()

            };
            return View("CustomerForm", viewModel);
        }

        //private IEnumerable<Customer> GetCustomers()
        //{
        //    return new List<Customer> {
        //    new Customer {Id=1, Name= "Madushan" },
        //    new Customer {Id=2, Name="Sathsarani" }

        //    };
        //}
    }
}