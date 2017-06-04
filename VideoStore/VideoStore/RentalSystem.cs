using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VideoStore
{
    public class RentalSystem : IRentals
    {
        public void AddRental(string movieTitle, string socialSecurityNumber)
        {
            throw new NotImplementedException();
        }

        public void RemoveRental(string movieTitle, string socialSecurityNumber)
        {
            throw new NotImplementedException();
        }

        public List<Rental> GetRentalsFor(string socialSecurityNumber)
        {
            throw new NotImplementedException();
        }
    }
}
