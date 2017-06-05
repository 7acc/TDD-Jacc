using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using NSubstitute;
using NSubstitute.Core;
using NUnit.Framework;
using VideoStore;

namespace VideoStoreTests
{
    [TestFixture]
    class VideoStoreTests
    {
        private IVideoStore _sut;
        private Movie _defaultMovie;
        private Customer _defaultCustomer;
        private IRentals _rentalSystem;
        private IDateTimex _datetime;



        [SetUp]
        public void SetUp()
        {
            _defaultMovie = new Movie {MovieTitle = "Testet som gick upp för en kulle och försvann"};


            _rentalSystem = Substitute.For<IRentals>();

            _sut = new TheVideoStore(_rentalSystem);
        }

        [Test]
        public void TitleCantBeEmpty_ThrowsException()
        {
            var noTitleMovie = new Movie {MovieTitle = ""};

            Assert.Throws<MovieAllocationException>(() => _sut.AddMovie(noTitleMovie));
        }

        [Test]
        public void AddingMoreThan3CopiesOfSameMovie_ThrowsException()
        {
            _sut.AddMovie(_defaultMovie);
            _sut.AddMovie(_defaultMovie);
            _sut.AddMovie(_defaultMovie);
            Assert.Throws<MovieAllocationException>(() => _sut.AddMovie(_defaultMovie));

            List<Movie> movies = _sut.LibraryOfMovies().Where(x => x.MovieTitle == _defaultMovie.MovieTitle).ToList();


            Assert.AreEqual(movies.Count, 3);
        }

        [Test]
        public void CantAddSameCostumerTwice()
        {
            _sut.RegisterCustomer("Booby","1730-12-24-1234");

            Assert.Throws<CostumerAllocationException>(
                () => _sut.RegisterCustomer("Konny", "1730-12-24-1234"));

        }

        [Test]
        public void RegisterCostumerWithInvalidSSn_ThrowsException()
        {
            Assert.Throws<InvalidSsnException>(
                () => _sut.RegisterCustomer("Booby", "111-8008"));
        }

        [Test]
        public void CantRentNonExistingMovie_ThrowsException()
        {
            Assert.Throws<MovieAllocationException>(
                () => _sut.RentMovie("Harry Potter och den vises test", "1990-01-01"));

          _rentalSystem.DidNotReceive().AddRental(Arg.Any<string>(), Arg.Any<string>());
        }   
             
    }





    internal class InvalidSsnException : Exception
    {
    }

    internal class CostumerAllocationException : Exception
    {
    }

    internal class MovieAllocationException : Exception
    {
        
    }
}
