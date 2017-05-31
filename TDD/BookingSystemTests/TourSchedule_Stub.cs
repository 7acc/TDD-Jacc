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
        private readonly Dictionary<DateTime, int> _recordedDates;
        public List<Tour> Tours { get; set; }


        public TourScheduleStub()
        {
            Tours = new List<Tour>();
            _recordedDates = new Dictionary<DateTime, int>();
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
            LoggDate(tourDate);

            var tours = Tours.Where(x => x.TourDate == tourDate).ToList();
            return tours;
        }


        //-------------------------------RecirdedDates Helpers------------------------
        private void LoggDate(DateTime date)
        {
            if (!_recordedDates.ContainsKey(date.Date))
            {
                _recordedDates.Add(date.Date, 1);
            }
            else
            {
                _recordedDates[date.Date] += 1;
            }
        }
        public KeyValuePair<DateTime, int> GetRecordedDatePair(DateTime date)
        {
            KeyValuePair<DateTime, int> dateData = _recordedDates.SingleOrDefault(x => x.Key == date);

            return dateData;

        }
    }
}
