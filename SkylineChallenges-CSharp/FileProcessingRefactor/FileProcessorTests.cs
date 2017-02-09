using System.Collections.Generic;
using System.Linq;
using NUnit.Framework;

namespace SkylineChallenges_CSharp.FileProcessingRefactor
{
    [TestFixture]
    public class FileProcessorTests
    {
        private IList<User> _users;

        [OneTimeSetUp]
        public void OneTimeSetUp()
        {
            this._users = new FileProcessor().Process();
        }

        [Test]
        public void TestNumberOfUsers()
        {
            Assert.AreEqual(500, this._users.Count);
        }

        [Test]
        public void TestNumberOfEachGeneration()
        {
            Assert.AreEqual(82, this._users.Count(u => u.Generation.Equals("The Greatest Generation")));
            Assert.AreEqual(88, this._users.Count(u => u.Generation.Equals("The Silent Generation")));
            Assert.AreEqual(98, this._users.Count(u => u.Generation.Equals("Baby Boomers")));
            Assert.AreEqual(72, this._users.Count(u => u.Generation.Equals("Gen X")));
            Assert.AreEqual(83, this._users.Count(u => u.Generation.Equals("Millenials")));
            Assert.AreEqual(77, this._users.Count(u => u.Generation.Equals("Generation Z")));
            Assert.AreEqual(0, this._users.Count(u => u.Generation.Equals("Unknown")));
        }

        [Test]
        public void TestGenerationOfSpecificPeople()
        {

            //TODO: Check the generation name of specific people.  Get at least one each by ID, Name, and Email.
        }

        [Test]
        public void TestNumberOfCreditCardTypes()
        {
            Assert.AreEqual(75, this._users.Count(u => u.CreditCardInfo?.StartsWith("V") ?? false));
            Assert.AreEqual(73, this._users.Count(u => u.CreditCardInfo?.StartsWith("MC") ?? false));
            Assert.AreEqual(74, this._users.Count(u => u.CreditCardInfo?.StartsWith("D") ?? false));
            Assert.AreEqual(73, this._users.Count(u => u.CreditCardInfo?.StartsWith("AMEX") ?? false));
            Assert.AreEqual(83, this._users.Count(u => u.CreditCardInfo?.StartsWith("O") ?? false));
        }

        [Test]
        public void TestCreditCardInfoOfSpecificPeople()
        {

            //TODO: Check the credit card info of specific people.  Get at least one each by ID, Name, and Email.
        }

        [Test]
        public void TestColorOfSpecificPeople()
        {
            //TODO: Check the rgb color of specific people.  Get at least one each by ID, Name, and Email.
        }
    }
}
