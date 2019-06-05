namespace Lexicon.Tests.Models.Database.PersonTests
{
    using Lexicon.Models.Contracts;
    using Lexicon.Models.Database;
    using Moq;
    using NUnit.Framework;
    using System;

    [TestFixture]
    public class LastName_Should
    {
        [TestCase("Petroff")]
        public void SetCorrectValue_WhenValidValueIsPassed(string value)
        {
            var person = new Person();

            person.LastName = value;

            Assert.AreEqual(person.LastName, value);
        }

        [TestCase(" ")]
        [TestCase("")]
        [TestCase(null)]
        public void ThrowArgumentNullException_WhenPassedValueIsNullOrWhitespace(string value)
        {
            var person = new Person();

            Assert.Throws<ArgumentNullException>(() => person.LastName = value);
        }

        [TestCase("Pe1troff")]
        [TestCase("Petro#ff")]
        [TestCase("Tra la la")]
        public void ThrowArgumentException_WhenPassedValueContainsNonletterCharactersOrWhiteSpaces(string value)
        {
            var person = new Person();

            Assert.Throws<ArgumentException>(() => person.LastName = value);
        }
    }
}
