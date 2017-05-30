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
        private StringCalculator _sut;

        [SetUp]
        public void SetUp()
        {
            _sut = new StringCalculator();
            
        }

        [Test]
        public void EmptyStringReturnsZero()
        {
           var result = _sut.Add("");
          
            Assert.AreEqual(0, result);
        }

        [Test]
        public void PassingOneNumberReturnsSameNumber()
        {
            var result = _sut.Add("1");

            Assert.AreEqual(1, result);

        }

        [Test]
        public void AddingNumbersReturnsSum()
        {
            var result = _sut.Add("1,2,3");

            Assert.AreEqual(6, result);

        }

        [Test]
        public void SeperatingNumbersWithNewLine()
        {
            var result = _sut.Add("1\n2,3");

            Assert.AreEqual(6, result);
        }

        [Test]
        public void UsingCustomDelimiter()
        {
            var result = _sut.Add("//delimiter\n 10 delimiter 2, 3 delimiter 4");

            Assert.AreEqual(19, result);

        }

        [Test]
        public void PassingNegativeNumbers_ThrowsException()
        {
            var message = Assert.Throws<NegativeNumbersException>(
                () => _sut.Add("-1, 1, -99")).Message;

            Assert.IsTrue(message.Contains("-99") && message.Contains("-1"));

        }
        [Test]
        public void IgnoresBigNumbers()
        {

            var result = _sut.Add("1000,1001");
            Assert.AreEqual(1000,result);
        }
    }
}
