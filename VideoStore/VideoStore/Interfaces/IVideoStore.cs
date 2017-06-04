﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
