using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Vidly.Models;
using Vidly.ViewModels;

namespace Vidly.Controllers
{
    public class CustomersController : Controller
    {
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
                Customers = _customers
            };
            return View(viewModel);
        }

        public ActionResult Details(int id)
        {
            var customer = _customers.Where(x => x.Id == id).FirstOrDefault();
            if (customer == null) return HttpNotFound();
            return View(customer);
        }
    }
}