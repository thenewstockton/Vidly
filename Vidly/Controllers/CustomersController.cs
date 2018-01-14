using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Vidly.Models;
using Vidly.ViewModels;
using System.Data.Entity;

namespace Vidly.Controllers
{
    public class CustomersController : Controller
    {
        private ApplicationDbContext _context;

        public CustomersController()
        {
            _context = new ApplicationDbContext();
        }

        protected override void Dispose(bool disposing)
        {
            _context.Dispose();
        }

        private List<Customer> _customers = new List<Customer>()
        {
            new Customer{Name="John Smith", Id = 1}, 
            new Customer{Name="Mary Williams", Id= 2}
        };

        // GET: Customers
        public ActionResult Index()
        {
            var viewModel = new CustomersViewModel
            {
                Customers = GetCustomers()
            };
            return View(viewModel);
        }

        private List<Customer> GetCustomers()
        {
            return _context.Customers.Include(c => c.MembershipType).ToList();
            //return _customers;
        }

        public ActionResult Details(int id)
        {
            var customer = GetCustomers().Where(x => x.Id == id).FirstOrDefault();
            if (customer == null) return HttpNotFound();
            return View(customer);
        }
    }
}