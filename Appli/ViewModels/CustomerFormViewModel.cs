using System.Collections.Generic;
using Appli.Models;

namespace Appli.ViewModels
{
    public class CustomerFormViewModel
    {
        public IEnumerable<MembershipType> MembershipTypes { get; set; }
        public Customer Customer { get; set; }
        public string Title {
            get
            {
                return Customer is null || Customer.Id == 0 ? "New customer" : "Edit customer";
            }
        }
    }
}