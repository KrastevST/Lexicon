namespace Lexicon.Tests.Models.Database.PersonTests
{
    using Lexicon.Models.Contracts;
    using Lexicon.Models.Database;
    using Moq;
    using NUnit.Framework;
    using System;

    [TestFixture]
    public class FirstName_Should
    {
        [TestCase("Simba")]
        public void SetCorrectValue_WhenValidValueIsPassed(string value)
        {
            var person = new Person();

            person.FirstName = value;

            Assert.AreEqual(person.FirstName, value);
        }

        [TestCase(" ")]
        [TestCase("")]
        [TestCase(null)]
        public void ThrowArgumentNullException_WhenPassedValueIsNullOrWhitespace(string value)
        {
            var person = new Person();

            Assert.Throws<ArgumentNullException>(() => person.FirstName = value);
        }

        [TestCase("Simba1")]
        [TestCase("Si*mba")]
        [TestCase("Simba the lion")]
        public void ThrowArgumentException_WhenPassedValueContainsNonletterCharactersOrWhiteSpaces(string value)
        {
            var person = new Person();

            Assert.Throws<ArgumentException>(() => person.FirstName = value);
        }
    }
}
