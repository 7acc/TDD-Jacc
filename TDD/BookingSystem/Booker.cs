using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
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
            _bookings = new List<Booking>();

        }

        public void CreateBooking(string tourname, DateTime tourDate, Passenger passenger)
        {
           
                var tour = _tourSchedueler.GetToursFor(tourDate).FirstOrDefault(x => x.Name == tourname);

                if (tour == null) throw new NoTourException(tourname, tourDate);
                else if (!CheckSeatsAvailible(tour)) throw new NoSeatsAvailibleException(tour);

                else
                {
                    _bookings.Add(new Booking(tour, passenger));
                }

            
          

        }

        private bool CheckSeatsAvailible(Tour tour)
        {
            return _bookings.Count(x => x.tour == tour) < tour.NbrOfSeats;
        }

        public IReadOnlyCollection<Booking> GetBookingsFor(Passenger passenger)
        {
            return _bookings.Where(x => x.Passenger == passenger).ToList();

        
        }
    }

    
    public class NoSeatsAvailibleException : Exception
    {
        public NoSeatsAvailibleException(Tour tour)
        {
            Message = $"No seats Availible on that Tour \n {tour.Name} - {tour.TourDate}";
        }

        public override string Message { get; }
    }
}