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
        private readonly List<Rental> _rentals;
        private IDateTimex _dateTime;

        public RentalSystem(IDateTimex dateTimeThing)
        {
            this._rentals = new List<Rental>();
            this._dateTime = dateTimeThing;
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
                _rentals.Add(new Rental(movieTitle,socialSecurityNumber, _dateTime.Now().AddDays(3)));
            }
        }

        public void RemoveRental(string movieTitle, string socialSecurityNumber)
        {
            var rentalToremove = _rentals.FirstOrDefault(x => x.MovieTitle == movieTitle && x.Ssn == socialSecurityNumber);

            if (rentalToremove == null)
            {
                throw new RentalAllocationException("Error");
            }
            else
            {
                _rentals.Remove(rentalToremove);
            }

        }

        public List<Rental> GetRentalsFor(string socialSecurityNumber)
        {
            return _rentals.Where(x => x.Ssn == socialSecurityNumber).ToList();
        }

        


        //------------HELPERS--------------

        private List<Rental> GetLateRentals(List<Rental> costumerRentals)
        {
            return costumerRentals.Where(x => x.DueDate < _dateTime.Now()).ToList();
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
