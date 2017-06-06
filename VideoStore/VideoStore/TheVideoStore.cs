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


            if (!CheckValidSsn(socialSecurityNumber)) throw new InvalidSsnException();
            if (CustomerDataBase.Any(x => x.Ssn == socialSecurityNumber)) throw new CostumerAllocationException();


            else
            {
                CustomerDataBase.Add(new Customer(name, socialSecurityNumber));
            }

        }


        public void AddMovie(Movie movie)
        {
            if (MovieBank.Count(x => x.MovieTitle == movie.MovieTitle) < 3 && !string.IsNullOrWhiteSpace(movie.MovieTitle))
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
            if (!MovieBank.Any(x => x.MovieTitle == movieTitle)) throw new RentalAllocationException($"The movie: {movieTitle} is not in stock");
            if (!CustomerDataBase.Any(x => x.Ssn == socialSecurityNumber)) throw new UnRegisteredException();

            _rentalSystem.AddRental(movieTitle, socialSecurityNumber);
        }



        public void ReturnMovie(string movieTitle, string socialSecurityNumber)
        {
            if (!_rentalSystem.GetRentalsFor(socialSecurityNumber).Any(x => x.MovieTitle == movieTitle))
            {
                throw new RentingException();
            }
            else
            {
                _rentalSystem.RemoveRental(movieTitle, socialSecurityNumber);
            }
        }

        public List<Movie> LibraryOfMovies()
        {
            return MovieBank;
        }

        public IReadOnlyCollection<Customer> GetCustomers()
        {
            return CustomerDataBase;
        }


        public List<string> GetAllRentals()
        {
            var list = new List<string>();
            foreach (var customer in CustomerDataBase)
            {
                StringBuilder sb = new StringBuilder();
               


                var rentals = _rentalSystem.GetRentalsFor(customer.Ssn);

                if(rentals.Count != 0)
                    sb.Append($"\n{customer.Name} - {customer.Ssn}\n" + "------------------------\n");

                foreach (var rental in rentals)
                {
                    sb.Append(rental.DueDate < DateTime.Now
                        ? $"{rental.MovieTitle} - due LATE: {rental.DueDate} LATE\n"
                        : $"{rental.MovieTitle} - due: {rental.DueDate}\n");

                   
                }
                list.Add(sb.ToString());
            }
            return list;
        }


        //------------------helpers---------------------
        private bool CheckValidSsn(string ssn)
        {
            Regex ssnReg = new Regex(@"^\d{4}-\d{2}-\d{2}$");

            return ssnReg.IsMatch(ssn);
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
    public class UnRegisteredException : Exception
    {
    }
    public class RentingException : Exception
    {
    }

}
