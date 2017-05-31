using System;
using TravelAgency;

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

    public class NoSeatsAvailibleException : Exception
    {
        public NoSeatsAvailibleException(Tour tour)
        {
            Message = $"No seats Availible on that Tour \n {tour.Name} - {tour.TourDate}";
        }

        public override string Message { get; }
    }
}
