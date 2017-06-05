
using System.Collections.Generic;


namespace VideoStore
{
    public interface IVideoStore
    {
        void RegisterCustomer(string name, string socialSecurityNumber);
        void AddMovie(Movie movie);
        void RentMovie(string movieTitle, string socialSecurityNumber);
      IReadOnlyCollection<Customer> GetCustomers();
        void ReturnMovie(string movieTitle, string socialSecurityNumber);
    }
}
