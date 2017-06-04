using System;
using System.Collections.Generic;
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
        
        public VideoStoreMenu()
        {
            
        }

        public void Run()
        {
            Console.WriteLine("this is a menu!");
            Console.ReadKey();
        }
    }
}
