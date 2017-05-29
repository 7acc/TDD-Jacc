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
        private TourSchedule Sut;

        [SetUp]
        public void Setup()
        {
            Sut = new TourSchedule();
        }

        [Test]
        public void CanCreateNewTour()
        {
            var tourDate = new DateTime(2017, 8, 10, 1, 1, 1);

            Sut.CreateTour("Best tour ever nr1",
                tourDate, 22);

            var tours = Sut.GetToursFor(tourDate);
            var tour = tours.ElementAt(0);
          
            Assert.True(tours.Count == 1);

            Assert.True(
                tour.TourDate == tourDate.Date
                && tour.NbrOfSeats == 22
                && tour.Name == "Best tour ever nr1");
        }

        [Test]
        public void GetToursForGivenDayOnly()
        {
            var dateToBeReturned = new DateTime(2017, 1, 1);
            var dateNotToBeReturned = new DateTime(2020, 2, 2);

            Sut.CreateTour("this should be returned nr1", dateToBeReturned, 10);
            Sut.CreateTour("this should be returned nr2", dateToBeReturned, 20);
            Sut.CreateTour("this should be returned nr3", dateToBeReturned, 30);

            Sut.CreateTour("this should not be returned nr1", dateNotToBeReturned, 40);
            Sut.CreateTour("this should not be returned nr2", dateNotToBeReturned, 50);

           
            var returnedTours = Sut.GetToursFor(dateToBeReturned);       
       
            Assert.True(returnedTours.Count == 3);
            Assert.True(returnedTours.Count(x => x.TourDate == dateToBeReturned) == 3);

        }

        [Test]
        public void CreateToManyToursOnDate_ThrowsException_AndSugestsAnotherDate()
        {
            var dateToScheduel = new DateTime(2017, 1, 1);

            Sut.CreateTour("fitt but you know it nr1", dateToScheduel, 99);
            Sut.CreateTour("fitt but you know it nr2", dateToScheduel, 99);
            Sut.CreateTour("fitt but you know it nr3", dateToScheduel, 99);


            var exception = Assert.Throws<TourAllocationException>(
                () => Sut.CreateTour("To many tours up in this place nr1", dateToScheduel, 99));

            Assert.AreEqual(exception.SugestedDate, dateToScheduel.AddDays(1));

            Assert.True(Sut.GetToursFor(dateToScheduel).Count == 3);


        }

        [Test]
        public void schedualingTourWithTheSameNameOnDate_ThrowsException()
        {
            var tourDate = new DateTime(2017, 1, 1);

            Sut.CreateTour("Only tour with this name",tourDate , 99);

            Assert.Throws<TourNameUnavilableOnDateException>(
               () => Sut.CreateTour("Only tour with this name", tourDate, 99));

            Assert.True(Sut.GetToursFor(tourDate).Count == 1);
        }

        [Test]
        public void SchedualingTourWithoutSeats_ThrowsException()
        {
            Assert.Throws<TourAllocationException>(
                () => Sut.CreateTour("No one likes me anywayz", new DateTime(2017, 12, 17), 0));
        }

       
    }
}
