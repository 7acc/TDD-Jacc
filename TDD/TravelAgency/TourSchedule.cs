using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Security.Cryptography.X509Certificates;


namespace TravelAgency
{
    public class TourSchedule : ITourSchedule
    {
        private readonly List<Tour> Tours;



        public TourSchedule()
        {
            Tours = new List<Tour>();
        }

        public void CreateTour(string description, DateTime date, int nbrOfSeats)
        {


            if(!TourNameAvailable(description,date)) throw new TourNameUnavilableOnDateException();
            if (!TourDateAvailable(date)) throw new TourAllocationException("there was no available tour on the "+ date.ToString("D"), FindNextAvailableDate(date));
            if(nbrOfSeats < 1) throw new TourAllocationException("whats the point with a tour without space for costumers? huh?");
            
                          
            else
            {
                Tours.Add(new Tour
                {
                    Name = description,
                    TourDate = date.Date,
                    NbrOfSeats = nbrOfSeats
                });
            }
        }


        public IReadOnlyCollection<Tour> GetToursFor(DateTime tourDate)
        {
            return Tours.Where(x => x.TourDate.Date == tourDate.Date).ToList().AsReadOnly();
        }




        //------------------------------------------------HELPERS-----------------------------------------------------

       private bool TourDateAvailable(DateTime date)
        {
            return Tours.Count(x => x.TourDate.Date == date.Date) < 3;
        }
        private bool TourNameAvailable(string TourName, DateTime date)
        {
            return Tours.Count(x => x.TourDate == date && x.Name == TourName) == 0;
        }

        private DateTime FindNextAvailableDate(DateTime unavailableDate)
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
