using System;
using System.Collections.Generic;
using SkylineChallenges_CSharp.RestAPIProcessing.Models;

namespace SkylineChallenges_CSharp.RestAPIProcessing
{
    public class ProcessUsers
    {
        public IList<User> Process()
        {
            var users = this.GetUsers();

            this.AddUsersToAgeGroup(users);
            this.SetDivisionAndRegionsForUsers(users);

            return users;
        }

        public IList<User> GetUsers()
        {
            //TODO: Get users from an API.  URL is https://fazioskyline.firebaseio.com/sampleUsers.json
            //Note that RestSharp is installed and can be used if desired.
            throw new NotImplementedException();
        }

        public void SetDivisionAndRegionsForUsers(IList<User> users)
        {
            //TODO: Assign appropriate division and region for a given user, based on results from US Census Bureau Regions and Divisions.xlsx
            //e.g. Mary Olsen is from Indiana, which is from the East North Central division in the Midwest region.
        }

        public void AddUsersToAgeGroup(IList<User> users)
        {
            //TODO: Assign the corresponding age group for each user based on their age.  Age groups can be found in the AgeGroup enum.
        }
    }
}
