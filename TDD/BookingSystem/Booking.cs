using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TravelAgency;

namespace BookingSystem
{
    public class Booking
    {
        public Booking(Tour tour, Passenger passenger)
        {
            this.tour = tour;
            Passenger = passenger;
        }

        public Tour tour { get; set; }
        public Passenger Passenger { get; set; }
    }
}
