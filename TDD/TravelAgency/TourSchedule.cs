using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TravelAgency
{
   public class TourSchedule
   {
       private List<Tour> Tours;

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
                   Description = description,
                   TourDate = date.Date,
                   NbrOfSeats = nbrOfSeats
               });
           }
           else
           {
               //throw exception!
           }
       }

     

       public List<Tour> GetToursFor(DateTime tourDate)
       {
           return Tours.Where(x => x.TourDate.Date == tourDate.Date).ToList();
       }




        //------------------------------------------------HELPERS--------------------------------------------------------
        public bool TourDateAvailable(DateTime date)
        {
            return Tours.Count(x => x.TourDate.Date == date.Date) < 3;
        }
    }

    public class Tour
    {
        public DateTime TourDate { get; set; }
        public string Description { get; set; }
        public int NbrOfSeats { get; set; }
    }
}
