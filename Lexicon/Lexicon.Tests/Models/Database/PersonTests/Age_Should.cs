namespace Lexicon.Tests.Models.Database.PersonTests
{
    using Lexicon.Models.Database;
    using NUnit.Framework;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    [TestFixture]
    public class Age_Should
    {
        [TestCase(0)]
        [TestCase(-22)]
        [TestCase(151)]
        public void ThrowArgumentException_WhenInvalidIntValueIsPassed(int value)
        {
            var person = new Person();

            Assert.Throws<ArgumentException>(() => person.Age = value);
        }

        [TestCase(1)]
        [TestCase(75)]
        [TestCase(150)]
        public void SetCorrectValue_WhenValidValueIsPassed(int value)
        {
            var person = new Person();

            person.Age = value;

            Assert.AreEqual(person.Age, value);
        }
    }
}
