using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TravelAgency
{
    class TourAllocationException : Exception
    {
        public TourAllocationException()
        {
            
        }

        public TourAllocationException(string message) 
            :base(message)
        {
            message = "the number of tours on the given day has been exeeded, try another date ";
        }
    }
}
