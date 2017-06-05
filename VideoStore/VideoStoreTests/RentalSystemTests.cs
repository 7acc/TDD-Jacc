using System;
using System.Collections.Generic;
using System.Linq;
using NSubstitute;
using NUnit.Framework;
using VideoStore;

namespace VideoStoreTests
{
    [TestFixture]
    class RentalSystemTests
    {
        private IRentals _sut;
        private IDateTimex _dateTime;
        private Movie _defaultMovie;
        private Customer _defaultCustomer;
   


        [SetUp]
        public void SetUp()
        {
            _dateTime = Substitute.For<IDateTimex>();
            _sut = new RentalSystem(_dateTime);
            

            _defaultMovie = new Movie
            {
                MovieTitle = "jakten på det försvunna testet",
                Id = 1
                
            };
            _defaultCustomer = new Customer
            {
                Name = "string",
                Ssn = "1990-10-10"
            };

        }




        [Test]
        public void CanAddRental()
        {
            _sut.AddRental(_defaultMovie.MovieTitle, _defaultCustomer.Ssn);

            IReadOnlyCollection<Rental> rentals = _sut.GetRentalsFor(_defaultCustomer.Ssn);
            var rental = rentals.ElementAt(0);

            Assert.True(rentals.Count == 1);
            Assert.AreEqual(rental.MovieTitle, _defaultMovie.MovieTitle);
            Assert.AreEqual(rental.Ssn, _defaultCustomer.Ssn);

        }

        [Test]
        public void CanGettRentalBySsn()
        {
            _sut.AddRental(_defaultMovie.MovieTitle, _defaultCustomer.Ssn);
            IReadOnlyCollection<Rental> rentals = _sut.GetRentalsFor(_defaultCustomer.Ssn);

            var rental = rentals.ElementAt(0);


            Assert.True(rentals.Count == 1);
            Assert.AreEqual(rental.Ssn, _defaultCustomer.Ssn);
        }
        [Test]
        public void AllRentalsWillGet3DayslaterDueDate()
        {
            var date = _dateTime.Now().Date;
            _sut.AddRental(_defaultMovie.MovieTitle, _defaultCustomer.Ssn);

            var rental = _sut.GetRentalsFor(_defaultCustomer.Ssn).ElementAt(0);

            Assert.True(rental.DueDate.Date == date.Date.AddDays(3));
         

        }

        [Test]
        public void CanRentManyMovies()
        {
            var movie1 = _defaultMovie;
            var movie2 = new Movie {MovieTitle = "Testet för länge sedan"};

            _sut.AddRental(movie1.MovieTitle, _defaultCustomer.Ssn);
            _sut.AddRental(movie2.MovieTitle, _defaultCustomer.Ssn);


            var rentals = _sut.GetRentalsFor(_defaultCustomer.Ssn);


            Assert.IsTrue(rentals.Count == 2);

        }

        [Test]
        public void RentingMoreThan3Movies_ThrowsExceoption()
        {
            var movie1 = _defaultMovie;
            var movie2 = new Movie { MovieTitle = "Testet för länge sedan" };
            var movie3 = new Movie { MovieTitle = "JungelTestet"};
            var movie4 = new Movie { MovieTitle = "Tests of the Caribean"};

            _sut.AddRental(movie1.MovieTitle,_defaultCustomer.Ssn);
            _sut.AddRental(movie2.MovieTitle, _defaultCustomer.Ssn);
            _sut.AddRental(movie3.MovieTitle, _defaultCustomer.Ssn);


            Assert.Throws<RentalAllocationException>(
                () => _sut.AddRental(movie4.MovieTitle, _defaultCustomer.Ssn));

            var rentals = _sut.GetRentalsFor(_defaultCustomer.Ssn);

            Assert.True(rentals.Count == 3);


        }

        [Test]
        public void RentingSameMovie_ThrowsException()
        {
            _sut.AddRental(_defaultMovie.MovieTitle, _defaultCustomer.Ssn);
            

            Assert.Throws<RentalAllocationException>(
           () => _sut.AddRental(_defaultMovie.MovieTitle, _defaultCustomer.Ssn));

            var rentals = _sut.GetRentalsFor(_defaultCustomer.Ssn);

            Assert.IsTrue(rentals.Count == 1);

        }

        [Test]
        public void RentingWithLateDueDate_ThrowsEsception()
        {
            var movie1 = _defaultMovie;
            var movie2 = new Movie { MovieTitle = "Testet för länge sedan" };
            _sut.AddRental(movie1.MovieTitle,_defaultCustomer.Ssn);


            _dateTime.Now().Returns(_dateTime.Now().AddDays(4));

            Assert.Throws<DueDateException>(() => _sut.AddRental(movie2.MovieTitle, _defaultCustomer.Ssn));
            Assert.True(_sut.GetRentalsFor(_defaultCustomer.Ssn).Count == 1);

            

        }

        [Test]
        public void CanRemoveRental()
        {
            _sut.AddRental(_defaultMovie.MovieTitle, _defaultCustomer.Ssn);
            _sut.RemoveRental(_defaultMovie.MovieTitle,_defaultCustomer.Ssn);

            Assert.AreEqual(_sut.GetRentalsFor(_defaultCustomer.Ssn).Count, 0);
        }

    }

    


}
