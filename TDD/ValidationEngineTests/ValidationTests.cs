
using System;
using NUnit.Framework;
using NUnit.Framework.Internal;
using ValidationEngine;

namespace ValidationEngineTests
{
    [TestFixture]
    public class ValidationTests
    {
        [Test]
        public void TrueForValidAdress()
        {
            var sut = new Validator();

            Assert.IsTrue(
                sut.ValidateEmailAddress("jacc@email.com"));

        }
        [Test]
        public void ThrowsBadFormat()
        {
            var sut = new Validator();

            Assert.That(() =>
            sut.ValidateEmailAddress("email.com"),
                Throws.Exception.TypeOf<AdressBadFormatException>());

        }

        [Test]
        public void ThrowsNullAddressException()
        {
            var sut = new Validator();

            string nullAddress = null;

            Assert.That(() =>
            sut.ValidateEmailAddress(nullAddress),
                Throws.Exception.TypeOf<ArgumentNullException>());
        }

        [Test]
        public void ThrowsContainsNumbers()
        {

            var sut = new Validator();

            Assert.That(() =>
            sut.ValidateEmailAddress("jacc123@email.com"),
                Throws.Exception.TypeOf<AdressContainsNumbersException>());
        }

        [Test]
        public void TrowsDoublePunctiationException()
        {
            var sut = new Validator();

            Assert.That(() =>
            sut.ValidateEmailAddress("jacc@email.se.com"),
                Throws.Exception.TypeOf<AdressdoublePunctioationException>());
        }

        [Test]
        public void TrowsShnabelAException()
        {
            var sut = new Validator();

            Assert.That(() =>
            sut.ValidateEmailAddress("jacc@email@.com"),
                Throws.Exception.TypeOf<AdressContainsmultipleShnabelAException>());
        }


    }
}
