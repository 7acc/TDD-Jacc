using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VideoStore
{
   public class Customer
    {
       public Customer()
       {
           
       }
       public Customer(string name, string socialSecurityNumber)
       {
           this.Name = name;
           this.Ssn = socialSecurityNumber;
       }

       public string Ssn { get; set; }
       public string Name { get; set; }
      

    }
}
