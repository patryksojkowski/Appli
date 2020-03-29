using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Appli.Controllers
{
    public partial class RentalsController : Controller
    {
        // GET: Rentals
        public virtual ActionResult New()
        {
            return View();
        }
    }
}