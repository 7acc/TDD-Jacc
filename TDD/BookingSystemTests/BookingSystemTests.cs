using System;
using System.Collections.Generic;
using System.Linq;
using NUnit.Framework;
using TravelAgency;
using BookingSystem;

namespace BookingSystemTests
{
    [TestFixture]
    class BookingSystemTests
    {

        private TourScheduleStub _tourSchedueler;
        private Booker _sut;
        private Passenger _defaultPassenger;

        [SetUp]
        public void SetUp()
        {
            _tourSchedueler = new TourScheduleStub();
            _sut = new Booker(_tourSchedueler);

            _defaultPassenger = new Passenger("Man", "Iron");
           
        }

        [Test]
        public void CanCreateCreateBooking()
        {

            var tourDate = new DateTime(2017, 05, 30);
            var tour = new Tour
            {
                Name = "Touring tour",
                TourDate = 
                tourDate,NbrOfSeats = 1
            };

            _tourSchedueler.Tours.Add(tour);
            _sut.CreateBooking("Touring tour", tourDate, _defaultPassenger);


            IReadOnlyCollection<Booking> bookings = _sut.GetBookingsFor(_defaultPassenger);

            Assert.AreEqual(1, bookings.Count);
            Assert.AreEqual(tour, bookings.ElementAt(0).Tour);


        }


        [Test]
        public void CreateBookingOnNonExistingTour_ThrowsException()
        {
            Assert.Throws<NoTourException>(
                () => _sut.CreateBooking("tour to NeverLand", DateTime.Today, _defaultPassenger));
        }

        [Test]
        public void CreatBookingOnTourWithNoAvailibleSeats_ThrowsException()
        {
            var tourDate = DateTime.Now;
            var tour = new Tour
            {

                Name = "Touring tour",
                TourDate = tourDate,
                NbrOfSeats = 1
            };

            _tourSchedueler.Tours.Add(tour);

            var passenger1 = _defaultPassenger;
            var passenger2 = new Passenger("Pepper", "SGT");

            _sut.CreateBooking("Touring tour", tourDate, passenger1);

            Assert.Throws<NoSeatsAvailibleException>(
                () => _sut.CreateBooking("Touring tour", tourDate, passenger2));
        }

        [Test]
        public void PassengerCanCancleBooking()
        {
            var tourdate = new DateTime(2017, 05, 31);
            var tour = new Tour
            {
                Name = "Touring tour",
                TourDate =  tourdate,          
                NbrOfSeats = 1
            };

            _tourSchedueler.Tours.Add(tour);
            _sut.CreateBooking("Touring tour", tourdate, _defaultPassenger);
            int countBookingsForPassenger = _sut.GetBookingsFor(_defaultPassenger).Count;


            _sut.CancleBooking("Touring tour", tourdate, _defaultPassenger);
            int countBookingsAfterCancle = _sut.GetBookingsFor(_defaultPassenger).Count;


            Assert.AreEqual(1,countBookingsForPassenger);
            Assert.AreEqual(0,countBookingsAfterCancle);
            



        }
    }


}
