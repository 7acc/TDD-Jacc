﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime;
using System.Text;
using System.Threading.Tasks;

namespace VideoStore
{
   public class Movie
    {
       public Movie(string title)
       {
           MovieTitle = title;
           Id = 0;
       }

       public int Id { get; set; }

       public string MovieTitle { get; set; }


    }
}
