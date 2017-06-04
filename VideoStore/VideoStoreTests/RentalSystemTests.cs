using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;
using VideoStore;

namespace VideoStoreTests
{
    [TestFixture]
    class RentalSystemTests
    {
        private IRentals _sut;
        private Movie _defaultMovie;
        private Customer _defaultCustomer;

        [SetUp]
        public void SetUp()
        {
            _sut = new RentalSystem();

            _defaultMovie = new Movie
            {
                MovieTitle = "jakten på det försvunna testet",
                Id = 1

            };
            _defaultCustomer = new Customer
            {
                FirstName = "",
                LastName = "",
                Ssn = "1990-12-17-1111"
            };



        }
        [Test]
        public void CanAddRental()
        {
            _sut.AddRental(_defaultMovie.MovieTitle, _defaultCustomer.Ssn);

            IReadOnlyCollection<Rental> rentals = _sut.GetRentalsFor(_defaultCustomer.Ssn);
            var rental = rentals.ElementAt(0);
        
            Assert.True(rentals.Count == 1);
            Assert.Equals(rental.MovieTitle, _defaultMovie.MovieTitle);
            Assert.Equals(rental.Ssn, _defaultCustomer.Ssn);

        }
        [Test]
        public void AllRentalsWillGet3DayslaterDueDate()
        {
            
        }

    }
}
