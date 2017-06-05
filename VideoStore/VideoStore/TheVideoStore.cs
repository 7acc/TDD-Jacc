using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VideoStore
{
   public class TheVideoStore : IVideoStore
    {
        public void RegisterCustomer(string name, string socialSecurityNumber)
        {
            throw new NotImplementedException();
        }

        public void AddMovie(Movie movie)
        {
            throw new NotImplementedException();
        }

        public void RentMovie(string movieTitle, string socialSecurityNumber)
        {
            throw new NotImplementedException();
        }



        public void ReturnMovie(string movieTitle, string socialSecurityNumber)
        {
            throw new NotImplementedException();
        }

       public IReadOnlyCollection<Customer> GetCustomers()
        {
            throw new NotImplementedException();
        }
    }
}
