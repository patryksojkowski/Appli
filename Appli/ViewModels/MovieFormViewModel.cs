using System.Collections.Generic;
using Appli.Models;

namespace Appli.ViewModels
{
    public class MovieFormViewModel
    {
        public Movie Movie { get; set; }
        public IEnumerable<Genre> Genres { get; set; }
        public string Title
        {
            get
            {
                if (Movie is null || Movie.Id == 0)
                {
                    return "New movie";
                }
                return "Edit movie";
            }
        }
    }
}