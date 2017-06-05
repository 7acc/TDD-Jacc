using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace VideoStore
{
   public class TheVideoStore : IVideoStore
    {
        private IRentals _rentalSystem;
       private List<Customer> CustomerDataBase;
       private List<Movie> MovieBank;  

        public TheVideoStore(IRentals _rentalSystem)
        {
            this._rentalSystem = _rentalSystem;
            this.CustomerDataBase = new List<Customer>();
            this.MovieBank = new List<Movie>();
        }

        public void RegisterCustomer(string name, string socialSecurityNumber)
        {
            var customer = new Customer(name,socialSecurityNumber);

            if (CheckValidSsn(socialSecurityNumber))
            {
                CustomerDataBase.Add(customer);
            }
            else
            {
                throw new InvalidSsnException();
            }
        }

        private bool CheckValidSsn(string ssn)
        {
            Regex ssnReg = new Regex(@"[12]\d{ 3 } - (0[1 - 9] | 1[0 - 2]) - (0[1 - 9] |[12]\d | 3[01])");

            return ssnReg.IsMatch(ssn);
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

       public List<Movie> LibraryOfMovies()
       {
           throw new NotImplementedException();
       }

       public IReadOnlyCollection<Customer> GetCustomers()
        {
            throw new NotImplementedException();
        }
    }
    public class InvalidSsnException : Exception
    {
    }

    public class CostumerAllocationException : Exception
    {
    }

    public class MovieAllocationException : Exception
    {

    }
}
