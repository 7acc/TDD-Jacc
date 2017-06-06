using System;
using System.Collections.Generic;
using System.Data.SqlTypes;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using NUnit.Framework.Internal;
using VideoStore;

namespace VideoStoreUI
{
    class VideoStoreMenu
    {
        private IRentals _rentalSystem;
        private IVideoStore _videoStore;
        private IDateTimex _dateTime;




        public VideoStoreMenu()
        {
            _dateTime = new DateTimex();
            _rentalSystem = new RentalSystem(_dateTime);
            _videoStore = new TheVideoStore(_rentalSystem);

            DemonStrationSetup();
        }

        private void DemonStrationSetup()
        {
            _videoStore.AddMovie(new Movie("Testet för längesedan"));
            _videoStore.AddMovie(new Movie("jakten på det försvunna testet"));
            _videoStore.AddMovie(new Movie("Testfadern"));
            _videoStore.AddMovie(new Movie("test, test, och testare"));

            _videoStore.RegisterCustomer("Bobby","1970-10-17");
            _videoStore.RegisterCustomer("Konny", "1965-02-13");
            _videoStore.RegisterCustomer("Evert", "1989-11-20");

            _videoStore.RentMovie("Testet för längesedan", "1970-10-17");
            _videoStore.RentMovie("Testet för längesedan", "1965-02-13");
            _videoStore.RentMovie("Testet för längesedan", "1989-11-20");
            _videoStore.RentMovie("Testfadern", "1970-10-17");
            _videoStore.RentMovie("test, test, och testare", "1970-10-17");
            _videoStore.RentMovie("jakten på det försvunna testet", "1965-02-13");
            _videoStore.RentMovie("jakten på det försvunna testet", "1989-11-20");

        }

        public void Run()
        {
            Console.ForegroundColor = ConsoleColor.Green;

            Console.WriteLine("this is a menu!");

            MainMenu();

        }

        public void MainMenu()
        {
            bool loop = true;
            while (loop)
            {

                Console.Clear();
                Console.WriteLine(
                    "\n\n" +
                    "[1] Add Movie\n" +
                    "[2] Register Costumer\n" +
                    "[3] Rent Movie \n" +
                    "[4] Return Movie \n" +
                    "[5] List Movies \n" + //to be done
                    "[6] List Costumers \n" + //to be done ( with rented movies)
                    "[7] list rentals \n"+
                    "[Q] Quit");

                var navigationChoice = Console.ReadKey(true).Key;

                switch (navigationChoice)
                {
                    case ConsoleKey.D1:
                    case ConsoleKey.NumPad1:

                        AddMovieMenu();
                        break;

                    case ConsoleKey.D2:
                    case ConsoleKey.NumPad2:

                        RegisterCostumerMenu();
                        break;

                    case ConsoleKey.D3:
                    case ConsoleKey.NumPad3:

                        RentMovieMenu();
                        break;

                    case ConsoleKey.D4:
                    case ConsoleKey.NumPad4:

                        ReturnMovieMenu();
                        break;

                    case ConsoleKey.D5:
                    case ConsoleKey.NumPad5:

                        ListMovies();
                        Console.ReadKey();
                        break;

                    case ConsoleKey.D6:
                    case ConsoleKey.NumPad6:
                        ListCustomers();
                        Console.ReadKey();
                        break;

                    case ConsoleKey.D7:
                    case ConsoleKey.NumPad7:

                        PrintRentals();
                        Console.ReadKey();
                        break;
                    case ConsoleKey.Q:

                        loop = false;
                        Console.Clear();
                        Console.Write("\n\n\n\n\n\n\n\n.......BYE!.......");
                        Thread.Sleep(1500);
                        break;

                    default:
                        break;

                }
            }

            return;
        }

        private void PrintRentals()
        {
            Console.Clear();
            _videoStore.GetAllRentals().ForEach(Console.WriteLine);
           
        }

        private void ReturnMovieMenu()
        {

            bool loop = true;
            while (loop)
            {
                ReturnMovie();

                Console.WriteLine($"Do you want to Return another one?  Y/N");

                if (Console.ReadKey(true).Key != ConsoleKey.Y)
                    loop = false;
            }
        }

        private void ReturnMovie()
        {
            Console.Write("Enter SSN: ");
            var Ssn = Console.ReadLine();

            Console.Write("Enter title: ");
            var title = Console.ReadLine();

            Console.WriteLine($"Return {title}?");
            if (Console.ReadKey(true).Key == ConsoleKey.Y)
            {

                try
                {
                    _videoStore.RentMovie(title, Ssn);
                    Console.WriteLine($" {title} has been returned");
                    Console.ReadKey(true);
                }
                catch (Exception e)
                {

                    Console.WriteLine(e.Message);
                }
            }
        }

        private void RentMovieMenu()
        {
            {

                bool loop = true;
                while (loop)
                {
                    Console.WriteLine("Titles Availible\n------------------\n");
                    ListMovies();
                    Console.WriteLine();
                    RentMovie();

                    Console.WriteLine($"Do you want to Rent another one?  Y/N");

                    if (Console.ReadKey().Key != ConsoleKey.Y)
                        loop = false;
                }
            }
        }

        private void RentMovie()
        {
            Console.Write("Enter SSN: ");
            var Ssn = Console.ReadLine();

            Console.Write("Enter title: ");
            var title = Console.ReadLine();

            Console.WriteLine($"rent {title}?");
            if (Console.ReadKey().Key == ConsoleKey.Y)
            {

                try
                {
                    _videoStore.RentMovie(title, Ssn);
                    Console.WriteLine($" {Ssn} has rented {title}");
                    Console.ReadKey();
                }
                catch (Exception e)
                {

                    Console.WriteLine(e.Message);
                }
            }
        }

        private void RegisterCostumerMenu()
        {
            {

                bool loop = true;
                while (loop)
                {
                    RegisterCostumer();

                    Console.WriteLine($"Do you want to add another one?  Y/N");

                    if (Console.ReadKey(true).Key != ConsoleKey.Y)
                        loop = false;
                }
            }
        }

        private void RegisterCostumer()
        {
            Console.Write("Enter Name: ");
            var name = Console.ReadLine();

            Console.Write("Enter Ssn (YYYY-MM-DD): ");
            var ssn = Console.ReadLine();

            Console.WriteLine($"Do you want to add {name} - {ssn} to the CostumerDatabase  Y/N");
            if (Console.ReadKey(true).Key == ConsoleKey.Y)
            {

                try
                {
                    _videoStore.RegisterCustomer(name, ssn);
                    Console.WriteLine($" {name} - {ssn} has been added");
                    Console.ReadKey(true);
                }
                catch (Exception e)
                {

                    Console.WriteLine(e.Message);
                }
            }

        }

        private void AddMovieMenu()
        {
            {

                bool loop = true;
                while (loop)
                {

                    CreateMovie();
                    Console.WriteLine($"Do you want to add another one?  Y/N");

                    if (Console.ReadKey(true).Key != ConsoleKey.Y)
                        loop = false;

                }
            }
        }

        private void CreateMovie()
        {
            Console.Write("Enter Title: ");
            var title = Console.ReadLine();

            Console.WriteLine($"Do you want to add {title} to the MovieBank?  Y/N");
            if (Console.ReadKey(true).Key == ConsoleKey.Y)
            {
                try
                {
                    _videoStore.AddMovie(new Movie(title));
                    Console.WriteLine($"{title} has been added");
                    Console.ReadKey(true);
                }

                catch (Exception e)
                {

                    Console.WriteLine(e.Message);
                }
            }

        }

        private void ListMovies()
        {
            var movieList = _videoStore.LibraryOfMovies();

            foreach (var movie in movieList)
            {
                Console.WriteLine($"Title:{movie.MovieTitle}");
            }

        }

        private void ListCustomers()
        {
            var customerList = _videoStore.GetCustomers();

            foreach (var customer in customerList)
            {
                Console.WriteLine($"Name:{customer.Name}   SSN:{customer.Ssn}");
            }
        }
    }
}
