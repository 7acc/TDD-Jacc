using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookingSystem
{
    public class Passenger
    {
        

        public Passenger(string lastName, string firstName)
        {
            this.LastName = lastName;
            this.FirstName = firstName;
        }

        public string FirstName { get; set; }
        public string LastName { get; set; }
    }
}
