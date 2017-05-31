using System;
using System.Collections.Generic;

namespace TravelAgency
{
    public interface ITourSchedule
    {
        void CreateTour(string description, DateTime date, int nbrOfSeats);
        IReadOnlyCollection<Tour> GetToursFor(DateTime tourDate);
    }
}