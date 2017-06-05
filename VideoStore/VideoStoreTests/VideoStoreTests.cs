using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
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


            _rentalSystem = new RentalSystem(_datetime);

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

            List<Movie> movies = _sut.LibraryOfMovies().Where(x => x.MovieTitle == _defaultMovie.MovieTitle);


            Assert.AreEqual(movies.Count == 3);
        }

    }

    internal class MovieAllocationException : Exception
    {
        
    }
}
