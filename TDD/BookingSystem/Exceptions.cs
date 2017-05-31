using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookingSystem
{
    public class NoTourException : Exception
    {
        public NoTourException(string tourName, DateTime tourDate)
        {
            Message = $"No tour found with that name or date: \"{tourName}\" at {tourDate} ";
        }

        public override string Message { get; }
    }
}
