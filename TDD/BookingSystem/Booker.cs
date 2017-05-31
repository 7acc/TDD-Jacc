using System;
using System.Collections.Generic;
using System.Linq;
using TravelAgency;

namespace BookingSystem
{
    public class Booker
    {
        private ITourSchedule _tourSchedueler;
        private List<Booking> _bookings; 

        public Booker(ITourSchedule tourSchedueler)
        {
            this._tourSchedueler = tourSchedueler;
            this._bookings = new List<Booking>();

        }

        public void CreateBooking(string tourname, DateTime tourDate, Passenger passenger)
        {
           
                var tour = _tourSchedueler.GetToursFor(tourDate).FirstOrDefault(x => x.Name == tourname);

                if (tour == null) throw new NoTourException(tourname, tourDate);
                if (!CheckSeatsAvailible(tour)) throw new NoSeatsAvailibleException(tour);

                else
                {
                    _bookings.Add(new Booking(tour, passenger));
                }

                    
        }

        private bool CheckSeatsAvailible(Tour tour)
        {
            return _bookings.Count(x => x.Tour == tour) < tour.NbrOfSeats;
        }

        public IReadOnlyCollection<Booking> GetBookingsFor(Passenger passenger)
        {
            return _bookings.Where(x => x.Passenger == passenger).ToList();

        
        }

        public void CancleBooking(string tourName, DateTime tourdate, Passenger passenger)
        {
            var booking = _bookings.Find(x => x.Passenger == passenger && x.Tour.TourDate == tourdate);
            _bookings.Remove(booking);
        }
    }

    
    
}