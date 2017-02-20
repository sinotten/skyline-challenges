using System.Collections.Generic;
using System.Linq;
using NUnit.Framework;
using System;

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
            int[] testValues = new int[3];

            //Going through the list and grabbing our values.
            foreach(User person in this._users)
            {
                if (person.Generation.Equals("Baby Boomers") && person.FirstName.Equals("Henry"))
                    ++testValues[0];

                if (person.Generation.Equals("The Greatest Generation") && person.Email.Contains("myspace.com"))
                    ++testValues[1];

                if (person.Generation.Equals("Millenials") && person.Id.Equals(new Guid("2fe1aaa2-cb3f-429a-bb52-385b83f9b0f7")))
                    ++testValues[2];
            }

            //Running tests
            Assert.AreEqual(3, testValues[0]);
            Assert.AreEqual(1, testValues[1]);
            Assert.AreEqual(1, testValues[2]);

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
            int[] testValues = new int[3];

            //Go through all users and check for specific people.
            foreach (User person in this._users)
            {
                if (person.CreditCardInfo != null)
                {
                    if (person.CreditCardInfo.Equals("V0192") && person.FirstName.Equals("Joseph"))
                        ++testValues[0];
                    else if (person.CreditCardInfo.Equals("AMEX4332") && person.Email.Contains("usa.gov"))
                        ++testValues[1];
                    else if (person.CreditCardInfo.Equals("MC9761") && person.Id.Equals(new Guid("0ae7f52f-dc2c-4bb5-a58e-40b05ab3357e")))
                        ++testValues[2];
                }
            }

            Assert.AreEqual(1, testValues[0]);
            Assert.AreEqual(1, testValues[1]);
            Assert.AreEqual(1, testValues[2]);
        }

        [Test]
        public void TestColorOfSpecificPeople()
        {
            //TODO: Check the rgb color of specific people.  Get at least one each by ID, Name, and Email.

            int[] testValues = new int[3];
            Color[] testColors = new Color[3];
            FileProcessor hexDecoder = new FileProcessor();

            for(int i = 0; i < testColors.Length; ++i)
                testColors[i] = new Color();
            
            testColors[0].Red = hexDecoder.HexToDecimal("c2");
            testColors[0].Green = hexDecoder.HexToDecimal("a7");
            testColors[0].Blue = hexDecoder.HexToDecimal("61");
            
            testColors[1].Red = hexDecoder.HexToDecimal("77");
            testColors[1].Green = hexDecoder.HexToDecimal("38");
            testColors[1].Blue = hexDecoder.HexToDecimal("21");
            
            testColors[2].Red = hexDecoder.HexToDecimal("1e");
            testColors[2].Green = hexDecoder.HexToDecimal("83");
            testColors[2].Blue = hexDecoder.HexToDecimal("07");

            foreach (User person in this._users)
            {
                if (person.ProfileColor.Red == testColors[0].Red && person.ProfileColor.Green == testColors[0].Green 
                    && person.ProfileColor.Blue == testColors[0].Blue && person.FirstName.Equals("Ralph"))
                    ++testValues[0];

                if (person.ProfileColor.Red == testColors[1].Red && person.ProfileColor.Green == testColors[1].Green
                    && person.ProfileColor.Blue == testColors[1].Blue && person.Email.Contains("businessweek.com"))
                    ++testValues[1];

                if (person.ProfileColor.Red == testColors[2].Red && person.ProfileColor.Green == testColors[2].Green
                    && person.ProfileColor.Blue == testColors[2].Blue && person.Id.Equals(new Guid("07db1074-43e2-4de9-91fb-a86137dec0fa")))
                    ++testValues[2];
            }

            Assert.AreEqual(1, testValues[0]);
            Assert.AreEqual(1, testValues[1]);
            Assert.AreEqual(1, testValues[2]);
        }
        
    }
}
