using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework.Internal;
using NUnit.Framework;
using TravelAgency;

namespace TravelAgencyTests
{
    [TestFixture]
    class TourScheduleTests
    {
        private TourSchedule sut;

        [SetUp]
        public void Setup()
        {
            sut = new TourSchedule();

        }

        [Test]
        public void CanCreateNewTour()
        {
            var tourDate = new DateTime(2017, 8, 10,1,1,1);

            sut.CreateTour("Best tour ever",
                tourDate, 22);

            var tours = sut.GetToursFor(tourDate);
            var tour = tours[0];

            Assert.True(tours.Count == 1);    
                
            Assert.True(
                tour.TourDate == tourDate.Date
                && tour.NbrOfSeats == 22 
                && tour.Description == "Best tour ever");
        }      
    }
}
