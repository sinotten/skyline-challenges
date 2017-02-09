using System;
using System.Collections.Generic;
using System.Linq;
using NUnit.Framework;
using SkylineChallenges_CSharp.RestAPIProcessing.Models;

namespace SkylineChallenges_CSharp.RestAPIProcessing
{
    [TestFixture]
    public class TestProcessUsers
    {
        private IList<User> _users;

        [OneTimeSetUp]
        public void OneTimeSetUp()
        {
            this._users = new ProcessUsers().Process();
        }

        [Test]
        public void ValidateUserCounts()
        {
            Assert.AreEqual(75, this._users.Count, "An incorrect number of users were returned.");
            Assert.AreEqual(41, this._users.Count(u => u.Gender.Equals(Gender.F)), "An incorrect number of female users were returned.");
            Assert.AreEqual(3, this._users.Count(u => u.State.Equals("WI")), "An incorrect number of users from Wisconsin were returned.");
        }

        [Test]
        public void ValidateAgeGroups()
        {
            Assert.AreEqual(1, _users.Count(u => u.AgeGroup == AgeGroup.Teens), "The returned number of teenagers was incorrect.");
            Assert.AreEqual(17, _users.Count(u => u.AgeGroup == AgeGroup.Twenties), "The returned number of people in their twenties was incorrect.");
            Assert.AreEqual(13, _users.Count(u => u.AgeGroup == AgeGroup.Thirties), "The returned number of people in their thirties was incorrect.");
            Assert.AreEqual(16, _users.Count(u => u.AgeGroup == AgeGroup.Forties), "The returned number of people in their forties was incorrect.");
            Assert.AreEqual(19, _users.Count(u => u.AgeGroup == AgeGroup.Fifties), "The returned number of people in their fifties was incorrect.");
            Assert.AreEqual(8, _users.Count(u => u.AgeGroup == AgeGroup.Sixties), "The returned number of people in their sixties was incorrect.");
            Assert.AreEqual(1, _users.Count(u => u.AgeGroup == AgeGroup.Unknown), "The returned number of people with an unknown age group was incorrect.");

            Assert.AreEqual(AgeGroup.Twenties, _users.FirstOrDefault(u => u.UserId.Equals(new Guid("8234eea9-4dfd-4661-ba9b-808e03b07acd")))?.AgeGroup, "The user's age group was incorrect.");
            Assert.AreEqual(AgeGroup.Forties, _users.FirstOrDefault(u => u.FirstName.Equals("Scott") && u.LastName.Equals("Kim"))?.AgeGroup, "The user's age group was incorrect.");
            Assert.AreEqual(AgeGroup.Fifties, _users.FirstOrDefault(u => u.CompanyName?.Equals("Mynte") ?? false)?.AgeGroup, "The user's age group was incorrect.");
        }

        [Test]
        public void ValidateDivisions()
        {
            Assert.AreEqual(1, _users.Count(u => u.Division == Division.NewEngland), "The returned number of users in the New England division was incorrect.");
            Assert.AreEqual(7, _users.Count(u => u.Division == Division.MidAtlantic), "The returned number of users in the Mid-Atlantic division was incorrect.");
            Assert.AreEqual(10, _users.Count(u => u.Division == Division.EastNorthCentral), "The returned number of users in the East North Central division was incorrect.");
            Assert.AreEqual(5, _users.Count(u => u.Division == Division.WestNorthCentral), "The returned number of users in the West North Central division was incorrect.");
            Assert.AreEqual(18, _users.Count(u => u.Division == Division.SouthAtlantic), "The returned number of users in the South Atlantic division was incorrect.");
            Assert.AreEqual(4, _users.Count(u => u.Division == Division.EastSouthCentral), "The returned number of users in the East South Central division was incorrect.");
            Assert.AreEqual(10, _users.Count(u => u.Division == Division.WestSouthCentral), "The returned number of users in the West South Central division was incorrect.");
            Assert.AreEqual(8, _users.Count(u => u.Division == Division.Mountain), "The returned number of users in the Mountain division was incorrect.");
            Assert.AreEqual(12, _users.Count(u => u.Division == Division.Pacific), "The returned number of users in the Pacific division was incorrect.");

            Assert.AreEqual(Division.SouthAtlantic, _users.FirstOrDefault(u => u.UserId.Equals(new Guid("26944649-4389-4b8e-bb86-0808166c0c1a")))?.Division, "The user's region was incorrect.");
            Assert.AreEqual(Division.EastNorthCentral, _users.FirstOrDefault(u => u.FirstName.Equals("Irene") && u.LastName.Equals("Ryan"))?.Division, "The user's region was incorrect.");
            Assert.AreEqual(Division.MidAtlantic, _users.FirstOrDefault(u => u.CompanyName?.Equals("Babblestorm") ?? false)?.Division, "The user's region was incorrect.");
        }
        
        [Test]
        public void ValidateRegions() {
            Assert.AreEqual(8, _users.Count(u => u.Region == Region.Northeast), "The returned number of users in the Northeast region was incorrect.");
            Assert.AreEqual(15, _users.Count(u => u.Region == Region.Midwest), "The returned number of users in the Midwest region was incorrect.");
            Assert.AreEqual(32, _users.Count(u => u.Region == Region.South), "The returned number of users in the South region was incorrect.");
            Assert.AreEqual(20, _users.Count(u => u.Region == Region.West), "The returned number of users in the West region was incorrect.");
            
            Assert.AreEqual(Region.Northeast, _users.FirstOrDefault(u => u.UserId.Equals(new Guid("84cd4388-c9aa-4424-a68f-ba646c2774d8")))?.Region, "The user's region was incorrect.");
            Assert.AreEqual(Region.Midwest, _users.FirstOrDefault(u => u.FirstName.Equals("Louise") && u.LastName.Equals("Mitchell"))?.Region, "The user's region was incorrect.");
            Assert.AreEqual(Region.South, _users.FirstOrDefault(u => u.CompanyName?.Equals("Einti") ?? false)?.Region, "The user's region was incorrect.");
        }
    }
}
