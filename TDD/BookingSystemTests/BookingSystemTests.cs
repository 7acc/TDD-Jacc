using System;
using System.CodeDom;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework.Internal;
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
                TourDate = tourDate,
                NbrOfSeats = 1
            };

            _tourSchedueler.Tours.Add(tour);
        

            _sut.CreateBooking("Touring tour", tourDate, _defaultPassenger);

            IReadOnlyCollection<Booking> bookings = _sut.GetBookingsFor(_defaultPassenger);


            Assert.AreEqual(1, bookings.Count);

            var booking = bookings.ElementAt(0);
            Assert.True(booking.tour.Name == "Touring tour");
            Assert.True(booking.Passenger.LastName == "Man");


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
            var tour =  new Tour
            {

                Name = "Touring tour",
                TourDate = tourDate,
                NbrOfSeats = 1
            };

            _tourSchedueler.Tours.Add(tour);

            var passenger1 = _defaultPassenger;
            var passenger2 = new Passenger("Pepper", "SGT");

            _sut.CreateBooking("Touring tour",tourDate,passenger1);

            Assert.Throws<NoSeatsAvailibleException>(
                () => _sut.CreateBooking("Touring tour", tourDate, passenger2));
        }
    }

    
}
