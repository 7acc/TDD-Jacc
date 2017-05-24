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

        [Test]
        public void GetToursForGivenDayOnly()
        {
            var dateToBeReturned = new DateTime(2017,1,1);
            var dateNotToBeReturned = new DateTime(2020,2,2);
            
            sut.CreateTour("this should be returned",dateToBeReturned,10);
            sut.CreateTour("this should be returned", dateToBeReturned, 20);
            sut.CreateTour("this should be returned", dateToBeReturned, 30);

            sut.CreateTour("this should not be returned", dateNotToBeReturned, 40);
            sut.CreateTour("this should not be returned", dateNotToBeReturned, 50);


            var returnedTours = sut.GetToursFor(dateToBeReturned);
         
            Assert.True(returnedTours.Count == 3);
            Assert.True(returnedTours.Count(x => x.TourDate == dateToBeReturned) == 3);

        }

        [Test]
        public void CreateToManyToursOnDate_ThrowsException()
        {
            
        }
    }
}
