using System;
using System.Collections.Generic;
using System.ComponentModel.Design;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework.Constraints;

namespace VideoStore
{
    public class RentalSystem : IRentals
    {
        private List<Rental> rentals;

        public RentalSystem()
        {
            this.rentals = new List<Rental>();
        }

        public void AddRental(string movieTitle, string socialSecurityNumber)
        {
            var costumerRentals = GetRentalsFor(socialSecurityNumber);
            if (costumerRentals.Count >= 3) throw new RentalAllocationException("to many moviez");

            var lateRentals = GetLateRentals(costumerRentals);
            if(lateRentals.Count > 0) throw new DueDateException(lateRentals);

            if (costumerRentals.Any(x => x.MovieTitle == movieTitle)) throw new RentalAllocationException(movieTitle);

            else
            {
                rentals.Add(new Rental(movieTitle,socialSecurityNumber,DateTime.Now.AddDays(3)));
            }
        }

        public void RemoveRental(string movieTitle, string socialSecurityNumber)
        {
            throw new NotImplementedException();
        }

        public List<Rental> GetRentalsFor(string socialSecurityNumber)
        {
            return rentals.Where(x => x.Ssn == socialSecurityNumber).ToList();
        }



        //------------HELPERS--------------

        private List<Rental> GetLateRentals(List<Rental> costumerRentals)
        {
            return costumerRentals.Where(x => x.DueDate > DateTime.Now).ToList();
        } 
    }
    public class RentalAllocationException : Exception
    {
        public RentalAllocationException(string message) : base(message)
        {
        }
    }
    public class DueDateException : Exception
    {
        private List<Rental> lateRentals;

        public DueDateException(List<Rental> lateRentals)
        {
            this.lateRentals = lateRentals;
        }
    }
}
