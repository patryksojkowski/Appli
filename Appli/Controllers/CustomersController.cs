using System.Linq;
using System.Web.Mvc;
using System.Data.Entity;
using Appli.Models;
using Appli.ViewModels;

namespace Appli.Controllers
{
    public partial class CustomersController : Controller
    {
        private readonly ApplicationDbContext context = new ApplicationDbContext();

        protected override void Dispose(bool disposing)
        {
            context.Dispose();
            base.Dispose(disposing);
        }

        /// <summary>
        /// Displays list of customers
        /// </summary>
        /// <returns></returns>
        public virtual ActionResult Index()
        {
            if (User.IsInRole(RoleName.CanManageCustomers))
            {
                return View(MVC.Customers.Views.List);
            }
            return View(MVC.Customers.Views.ReadOnlyList);
        }

        /// <summary>
        /// Displays details of given customer
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public virtual ActionResult Details(int id)
        {
            var customer = context.Customers.Include(c => c.MembershipType).FirstOrDefault(x => x.Id == id);
            if (customer is null)
            {
                return HttpNotFound();
            }
            return View(customer);
        }

        [Authorize(Roles = RoleName.CanManageCustomers)]
        public virtual ActionResult New()
        {
            var viewModel = new CustomerFormViewModel
            {
                MembershipTypes = context.MembershipTypes,
                Customer = new Customer()
            };
            return View(MVC.Customers.Views.CustomerForm, viewModel);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = RoleName.CanManageCustomers)]
        public virtual ActionResult Save(CustomerFormViewModel viewModel)
        {
            var customer = viewModel.Customer;

            if (!ModelState.IsValid)
            {
                viewModel = new CustomerFormViewModel
                {
                    Customer = customer,
                    MembershipTypes = context.MembershipTypes
                };
                return View(MVC.Customers.Views.CustomerForm, viewModel);
            }

            var dbCustomer = context.Customers.FirstOrDefault(x => x.Id == customer.Id);
            if (dbCustomer is null)
            {
                context.Customers.Add(customer);
            }
            else
            {
                dbCustomer.UpdateModel(customer);
            }
            context.SaveChanges();

            return RedirectToAction(MVC.Customers.Index());
        }

        [Authorize(Roles = RoleName.CanManageCustomers)]
        public virtual ActionResult Edit(int id)
        {
            var customer = context.Customers.FirstOrDefault(c => c.Id == id);

            if (customer == null)
            {
                return HttpNotFound();
            }
            var viewModel = new CustomerFormViewModel
            {
                Customer = customer,
                MembershipTypes = context.MembershipTypes.ToList()
            };
            return View(MVC.Customers.Views.CustomerForm, viewModel);
        }
    }
}