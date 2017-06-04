using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VideoStore;

namespace VideoStore
{
    class DateTimex : IDateTimex
    {
        public DateTime Now()
        {
            return DateTime.Now;
        }
    }
}
