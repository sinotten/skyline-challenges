using System;

namespace SkylineChallenges_CSharp.RestAPIProcessing.Models
{
    public class User
    {
        public Guid UserId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string State { get; set; }
        public Region Region { get; set; }
        public Division Division { get; set; }
        public string CompanyName { get; set; }
        public string AlmaMater { get; set; }
        public int Age { get; set; }
        public AgeGroup AgeGroup { get; set; }
        public Gender Gender { get; set; }
    }
}
