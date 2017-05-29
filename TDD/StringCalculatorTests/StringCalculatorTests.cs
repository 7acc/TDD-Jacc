using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework.Internal;
using NUnit.Framework;
using StringCalc;

namespace StringCalculatorTests
{
    [TestFixture]
    class StringCalculatorTests
    {
        private StringCalculator Sut ;

        [SetUp]
        public void SetUp()
        {
            Sut = new StringCalculator();
            
        }

        [Test]
        public void EmptyStringReturnsZero()
        {
           var result = Sut.Add("");
          
            Assert.AreEqual(0, result);
        }

        [Test]
        public void PassingOneNumberReturnsSameNumber()
        {
            var result = Sut.Add("1");

            Assert.AreEqual(1, result);

        }

        [Test]
        public void AddingNumbersReturnsSum()
        {
            var result = Sut.Add("1,2,3");

            Assert.AreEqual(6, result);

        }

        [Test]
        public void SeperatingNumbersWithNewLine()
        {
            var result = Sut.Add("1\n2,3");

            Assert.AreEqual(6, result);
        }

        [Test]
        public void UsingCustomDelimiter()
        {
            var result = Sut.Add("//delimiter\n 10 delimiter 2, 3 delimiter 4");

            Assert.AreEqual(19, result);

        }


    }
}
