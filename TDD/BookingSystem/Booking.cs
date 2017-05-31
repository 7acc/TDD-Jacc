
using TravelAgency;

namespace BookingSystem
{
    public class Booking
    {
        public Booking(Tour tour, Passenger passenger)
        {
            this.Tour = tour;
            Passenger = passenger;
        }

        public Tour Tour { get; set; }
        public Passenger Passenger { get; set; }
    }
}
