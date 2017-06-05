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
          

            if (!CheckValidSsn(socialSecurityNumber))  throw new InvalidSsnException();
            if(CustomerDataBase.Any(x => x.Ssn == socialSecurityNumber)) throw new CostumerAllocationException();

           
            else
            {
                CustomerDataBase.Add(new Customer(name, socialSecurityNumber));
            }
            
        }

        private bool CheckValidSsn(string ssn)
        {
            Regex ssnReg = new Regex(@"^\d{4}-\d{2}-\d{2}$");

            return ssnReg.IsMatch(ssn);
        }

        public void AddMovie(Movie movie)
        {
            if (MovieBank.Count(x => x.MovieTitle == movie.MovieTitle) < 3 && !string.IsNullOrEmpty(movie.MovieTitle))
            {
                MovieBank.Add(movie);
            }

      
            else
            {
                throw new MovieAllocationException();
            }
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
           return MovieBank;
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
