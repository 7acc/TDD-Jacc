using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VideoStore
{
   public class Rental
    {
        public string MovieTitle { get; set; }
        public string Ssn { get; set; }
        public DateTime DueDate { get; set; }

        public Rental(string movieTitle, string socialSecurityNumber, DateTime DueDate)
        {
            this.MovieTitle = movieTitle;
            this.Ssn = socialSecurityNumber;
            this.DueDate = DueDate;
        }

        
    }
}
