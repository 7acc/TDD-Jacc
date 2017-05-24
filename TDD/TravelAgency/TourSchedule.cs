using System;
using System.Collections.Generic;
using System.Linq;


namespace TravelAgency
{
    public class TourSchedule
    {
        public List<Tour> Tours { get; private set; }

        public TourSchedule()
        {
            Tours = new List<Tour>();
        }

        public void CreateTour(string description, DateTime date, int nbrOfSeats)
        {
            if (TourDateAvailable(date))
            {
                Tours.Add(new Tour
                {
                    Name = description,
                    TourDate = date.Date,
                    NbrOfSeats = nbrOfSeats
                });
            }
            else
            {
                throw new TourAllocationException("there was no available tour on the ",FindNextAvailableDate(date));
            }
        }


        public List<Tour> GetToursFor(DateTime tourDate)
        {
            return Tours.Where(x => x.TourDate.Date == tourDate.Date).ToList();
        }


        //------------------------------------------------HELPERS-----------------------------------------------------

        public bool TourDateAvailable(DateTime date)
        {
            return Tours.Count(x => x.TourDate.Date == date.Date) < 3;
        }

        public DateTime FindNextAvailableDate(DateTime unavailableDate)
        {
            DateTime search = unavailableDate ;
            do
            {
                search = search.AddDays(1);

            } while (!TourDateAvailable(search));

            return search;
        }
    }

    public class Tour
    {
        public DateTime TourDate { get; set; }
        public string Name { get; set; }
        public int NbrOfSeats { get; set; }
    }
}
