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
        private Rental _defaultRental;


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
        public void CanGettRentalBySsn()
        {
            _sut.AddRental(_defaultMovie.MovieTitle, _defaultCustomer.Ssn);
            IReadOnlyCollection<Rental> rentals = _sut.GetRentalsFor(_defaultCustomer.Ssn);

            var rental = rentals.ElementAt(0);


            Assert.True(rentals.Count == 1);
            Assert.Equals(rental.Ssn, _defaultCustomer.Ssn);
        }

        public void AllRentalsWillGet3DayslaterDueDate()
        {
            var date = DateTime.Now.Date;
            _sut.AddRental(_defaultMovie.MovieTitle, _defaultCustomer.Ssn);

            var rental = _sut.GetRentalsFor(_defaultCustomer.Ssn).ElementAt(0);

            Assert.True(rental.DueDate.Date == date.Date.AddDays(3));
         

        }
    }
}
