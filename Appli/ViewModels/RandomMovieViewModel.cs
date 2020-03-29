using System.Collections.Generic;
using Appli.Models;

namespace Appli.ViewModels
{
    public class RandomMovieViewModel
    {
        public Movie Movie { get; set; }
        public List<Customer> Customers { get; set; }
    }
}