using System;
using System.ComponentModel.DataAnnotations;

namespace Appli.Models
{
    public class Movie
    {
        [Required]
        public int Id { get; set; }

        [Required]
        [StringLength(255)]
        public string Name { get; set; }

        public Genre Genre { get; set; }

        [Required]
        [Display(Name = "Genre")]
        public byte GenreId { get; set; }

        [Required]
        [Display(Name = "Date of release")]
        public DateTime ReleaseDate { get; set; }

        [Required]
        public DateTime DateAdded { get; set; }

        //private short numberInStock;
        [Required]
        [Display(Name = "Number in stock")]
        [Range(1, 20)]
        public short NumberInStock
        {
             get; set;
            //get
            //{
            //    return NumberInStock;
            //}
            //set
            //{
            //    // count number of already rented movies
            //    var rented = numberInStock - NumberAvailable;

            //    // if there are more rented than new value of available, throw
            //    if (value < rented)
            //    {
            //        throw new ArgumentOutOfRangeException(nameof(NumberInStock),
            //            message: "More movies are rented than all in stock");
            //    }

            //    // count difference 
            //    var diff = value - numberInStock;
            //    NumberAvailable += (short)diff;
            //    numberInStock = value;
            //}
        }

        [Display(Name = "Number available")]
        [Range(0, 20)]
        public short NumberAvailable { get; set; }

        public void Update(Movie movie)
        {
            Name = movie.Name;
            GenreId = movie.GenreId;
            ReleaseDate = movie.ReleaseDate;
            DateAdded = DateTime.Now;
            NumberInStock = movie.NumberInStock;
        }
    }
}