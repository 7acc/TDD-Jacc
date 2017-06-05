
using System.Collections.Generic;

namespace VideoStore
{
   public interface IRentals
    {
        void AddRental(string movieTitle, string socialSecurityNumber);
        void RemoveRental(string movieTitle, string socialSecurityNumber);
      List<Rental> GetRentalsFor(string socialSecurityNumber);
    }
}
