using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TravelAgency
{
    public class TourAllocationException : Exception
    {

        public DateTime SugestedDate;

        public TourAllocationException()
        {
            
        }

        public TourAllocationException(string message) 
            :base(message)
        {
            message = "the number of tours on the given day has been exeeded, try another date ";
        }

        public TourAllocationException(string message,DateTime sugestedDate)
            :base(message)
        {
            SugestedDate = sugestedDate;
            message = $"the number of tours on the given day has been exeeded, the next available date is - {SugestedDate} ";
           
        }
    }

    public class TourNameUnavilableOnDateException : Exception
    {
        public TourNameUnavilableOnDateException()
        {
            
        }
    }
}
