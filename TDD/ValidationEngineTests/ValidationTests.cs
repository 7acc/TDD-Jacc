using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;
using ValidationEngine;

namespace ValidationEngineTests
{
    [TestFixture]
    public class ValidationTests
    {
        [Test]
        void TrueForValidAdress()
        {
            var sut = new Validator();
      
            Assert.IsTrue(sut.ValidateEmailAddress("Jacc@email.com"));

        }


    }
}
