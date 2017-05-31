using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TravelAgency;

namespace BookingSystemTests
{
    public class TourScheduleStub : ITourSchedule
    {

        public List<Tour> Tours { get; set; }

        public TourScheduleStub()
        {
            Tours = new List<Tour>();
        }

        public void CreateTour(string description, DateTime date, int nbrOfSeats)
        {
           Tours.Add(new Tour
           {
               Name = description,
               TourDate = date,
               NbrOfSeats = nbrOfSeats
           });
        }

        public IReadOnlyCollection<Tour> GetToursFor(DateTime tourDate)
        {
            var tours = Tours.Where(x => x.TourDate == tourDate).ToList();         
            return tours;
        }
    }
}
