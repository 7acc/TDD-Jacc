using System;
using System.Collections.Generic;
using System.Data.SqlTypes;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
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
        }

        public void Run()
        {
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
                    "[1] Add Movie\n" +
                    "[2] Register Costumer\n" +
                    "[3] Rent Movie \n" +
                    "[4] Return Movie \n" +
                    "[Q] Quit");

                var navigationChoice = Console.ReadKey(false).Key;

                switch (navigationChoice)
                {
                    case ConsoleKey.D1:

                        AddMovieMenu();
                        break;

                    case ConsoleKey.D2:

                        RegisterCostumerMenu();
                        break;

                    case ConsoleKey.D3:

                        RentMovieMenu();
                        break;

                    case ConsoleKey.D4:

                        ReturnMovieMenu();
                        break;

                    case ConsoleKey.Q:

                        loop = false;
                        break;

                    default:
                        break;

                }
            }

            return;
        }

        private void ReturnMovieMenu()
        {

            bool loop = true;
            while (loop)
            {
            }
        }

        private void RentMovieMenu()
        {
            {

                bool loop = true;
                while (loop)
                {
                }
            }
        }

        private void RegisterCostumerMenu()
        {
            {

                bool loop = true;
                while (loop)
                {
                }
            }
        }

        private void AddMovieMenu()
        {
            {

                bool loop = true;
                while (loop)
                {
                }
            }
        }
    }
}
