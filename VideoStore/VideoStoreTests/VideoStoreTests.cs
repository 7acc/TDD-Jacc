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
            _sut.RegisterCustomer("Booby","1990-12-24");

            Assert.Throws<CostumerAllocationException>(
                () => _sut.RegisterCustomer("Konny", "1990-12-24"));

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
            Assert.Throws<RentalAllocationException>(
                () => _sut.RentMovie("Harry Potter och den vises test", "1990-01-01"));

          _rentalSystem.DidNotReceive().AddRental(Arg.Any<string>(), Arg.Any<string>());
        }

        [Test]
        public void UnRegisteredCostumersCantRentMovies()
        {
            _sut.AddMovie(_defaultMovie);
            _sut.RegisterCustomer("Booby", "1730-12-24");

            Assert.Throws<UnRegisteredException>(
                () => _sut.RentMovie(_defaultMovie.MovieTitle, "2017-01-01"));

            _rentalSystem.DidNotReceive().AddRental(Arg.Any<string>(), Arg.Any<string>());
        }

        [Test]
        public void CanReturnMovie()
        {

            _sut.AddMovie(_defaultMovie);
            _sut.RegisterCustomer("Bobby", "2017-01-01");

            _sut.RentMovie(_defaultMovie.MovieTitle, "2017-01-01");


            List<Rental> rentals = new List<Rental>
            {
                new Rental(_defaultMovie.MovieTitle,"2017-01-01",DateTime.Now)
            };
            _rentalSystem.GetRentalsFor("2017-01-01").Returns(rentals);

            _sut.ReturnMovie(_defaultMovie.MovieTitle, "2017-01-01");
            _rentalSystem.Received().RemoveRental(Arg.Is(_defaultMovie.MovieTitle), Arg.Is("2017-01-01"));
            
        }
             
    }

   

   
}
