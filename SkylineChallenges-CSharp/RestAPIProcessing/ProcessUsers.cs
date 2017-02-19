using System;
using System.Collections.Generic;
using RestSharp;
using SkylineChallenges_CSharp.RestAPIProcessing.Models;
using Microsoft.Office.Interop.Excel;
using System.IO;

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
            
            //List of Users to go through
            User[] users;
            int ageParse;

            //Arrays to help parse input
            string[] initialSplit;
            string[] rowBreak;
            string[] userDetail;

            //Retreive user list from web URL, no authentication needed.
            var client = new RestClient("https://fazioskyline.firebaseio.com/sampleUsers.json");
            var request = new RestRequest(Method.GET);
            var response = client.Execute(request);

            if (response.ErrorException != null)
                throw new Exception(response.ErrorMessage);

            if (string.IsNullOrEmpty(response.Content))
                throw new Exception("Response did not contain any content!");
            
            initialSplit = response.Content.Split('}');

            users = new User[initialSplit.Length - 1];

            //Go through each user given
            for (int i = 0; i < initialSplit.Length -1; ++i)
            {
                users[i] = new User();

                //Remove additional character from the start and 
                rowBreak = initialSplit[i].Substring(2).Split(',');

                foreach (string row in rowBreak)
                {
                    userDetail = row.Split(':');
                    switch(userDetail[0].ToLower())
                    {
                        case "\"age\"":
                            int.TryParse(userDetail[1], out ageParse);
                            users[i].Age = ageParse;
                            break;
                        case "\"almamater\"":
                            users[i].AlmaMater = userDetail[1].Substring(1, (userDetail[1].Length - 2));
                            break;
                        case "\"companyname\"":
                            users[i].CompanyName = userDetail[1].Substring(1, (userDetail[1].Length - 2));
                            break;
                        case "\"email\"":
                            users[i].Email = userDetail[1].Substring(1, (userDetail[1].Length - 2));
                            break;
                        case "\"firstname\"":
                            users[i].FirstName = userDetail[1].Substring(1, (userDetail[1].Length - 2));
                            break;
                        case "\"gender\"":
                            //When instantiating a User object, gender is automatically set to F. Only need to check for M
                            if (userDetail[1].Substring(1, (userDetail[1].Length - 2)).ToUpper().Equals("M"))
                                users[i].Gender = Gender.M;
                            break;
                        case "\"lastname\"":
                            users[i].LastName = userDetail[1].Substring(1, (userDetail[1].Length - 2));
                            break;
                        case "\"state\"":
                            users[i].State = userDetail[1].Substring(1, (userDetail[1].Length - 2));
                            break;
                        case "\"userid\"":
                            users[i].UserId = new Guid(userDetail[1].Substring(1, (userDetail[1].Length - 2)));
                            break;
                    }
                }
            }
            
            return users;
        }

        public void SetDivisionAndRegionsForUsers(IList<User> users)
        {
            //TODO: Make filePath Dynamic
            string filePath = Directory.GetCurrentDirectory();
            User currentUser;
            Dictionary<string, Region> regions = new Dictionary<string, Region>();
            Dictionary<string, Division> divisions = new Dictionary<string, Division>();
            Dictionary<string, string> states = new Dictionary<string, string>(50);

            //Load all the regions and divisions from the excel file given.
            LoadExcelData(regions, divisions);

            states.Add("AL", "Alabama");
            states.Add("AK", "Alaska");
            states.Add("AZ", "Arizona");
            states.Add("AR", "Arkansas");
            states.Add("CA", "California");
            states.Add("CO", "Colorado");
            states.Add("CT", "Connecticut");
            states.Add("DC", "Washington, D.C.");
            states.Add("DE", "Delaware");
            states.Add("FL", "Florida");
            states.Add("GA", "Georgia");
            states.Add("HI", "Hawaii");
            states.Add("ID", "Idaho");
            states.Add("IL", "Illinois");
            states.Add("IN", "Indiana");
            states.Add("IA", "Iowa");
            states.Add("KS", "Kansas");
            states.Add("KY", "Kentucky");
            states.Add("LA", "Louisiana");
            states.Add("ME", "Maine");
            states.Add("MD", "Maryland");
            states.Add("MA", "Massachusetts");
            states.Add("MI", "Michigan");
            states.Add("MN", "Minnesota");
            states.Add("MS", "Mississippi");
            states.Add("MO", "Missouri");
            states.Add("MT", "Montana");
            states.Add("NE", "Nebraska");
            states.Add("NV", "Nevada");
            states.Add("NH", "New Hampshire");
            states.Add("NJ", "New Jersey");
            states.Add("NM", "New Mexico");
            states.Add("NY", "New York");
            states.Add("NC", "North Carolina");
            states.Add("ND", "North Dakota");
            states.Add("OH", "Ohio");
            states.Add("OK", "Oklahoma");
            states.Add("OR", "Oregon");
            states.Add("PA", "Pennsylvania");
            states.Add("RI", "Rhode Island");
            states.Add("SC", "South Carolina");
            states.Add("SD", "South Dakota");
            states.Add("TN", "Tennessee");
            states.Add("TX", "Texas");
            states.Add("UT", "Utah");
            states.Add("VT", "Vermont");
            states.Add("VA", "Virginia");
            states.Add("WA", "Washington");
            states.Add("WV", "West Virginia");
            states.Add("WI", "Wisconsin");
            states.Add("WY", "Wyoming");

            //Assign region and divisions based on state of each user
            foreach (object obj in users)
            {
                currentUser = (User)obj;

                if (divisions.ContainsKey(states[currentUser.State]))
                    currentUser.Division = divisions[states[currentUser.State]];

                if (regions.ContainsKey(states[currentUser.State]))
                    currentUser.Region = regions[states[currentUser.State]];
            }
        }

        public void AddUsersToAgeGroup(IList<User> users)
        {
            User currentUser;

            //TODO: Assign the corresponding age group for each user based on their age.  Age groups can be found in the AgeGroup enum.
            foreach(object obj in users)
            {
                currentUser = (User)obj;

                if (currentUser.Age >= 10 && currentUser.Age < 20)
                    currentUser.AgeGroup = AgeGroup.Teens;
                else if (currentUser.Age >= 20 && currentUser.Age < 30)
                    currentUser.AgeGroup = AgeGroup.Twenties;
                else if (currentUser.Age >= 30 && currentUser.Age < 40)
                    currentUser.AgeGroup = AgeGroup.Thirties;
                else if (currentUser.Age >= 40 && currentUser.Age < 50)
                    currentUser.AgeGroup = AgeGroup.Forties;
                else if (currentUser.Age >= 50 && currentUser.Age < 60)
                    currentUser.AgeGroup = AgeGroup.Fifties;
                else if (currentUser.Age >= 60 && currentUser.Age < 70)
                    currentUser.AgeGroup = AgeGroup.Sixties;
                else
                    currentUser.AgeGroup = AgeGroup.Unknown;
            }
        }

        private void LoadExcelData(Dictionary<string, Region> regions, Dictionary<string, Division> divisions)
        {
            string currentCell = String.Empty;
            Application file = new Application();
            Workbook book = file.Workbooks.Open("C:\\Users\\nsinotte\\Desktop\\Personal Projects\\SkyLine\\skyline-challenges\\SkylineChallenges-CSharp\\RestAPIProcessing\\US Census Bureau Regions and Divisions.xlsx");
            _Worksheet sheet = book.Sheets[1];
            Range range = sheet.UsedRange;

            for (int i = 3; i < 9; ++i)
            {
                currentCell = range[i, 3].Value2;

                divisions.Add(currentCell, Division.NewEngland);
                regions.Add(currentCell, Region.Northeast);
            }

            for (int i = 10; i < 13; ++i)
            {
                currentCell = range[i, 3].Value2.ToString();

                divisions.Add(currentCell, Division.MidAtlantic);
                regions.Add(currentCell, Region.Northeast);
            }

            for (int i = 15; i < 20; ++i)
            {
                currentCell = range[i, 3].Value2.ToString();

                divisions.Add(currentCell, Division.EastNorthCentral);
                regions.Add(currentCell, Region.Midwest);
            }

            for (int i = 21; i < 28; ++i)
            {
                currentCell = range[i, 3].Value2.ToString();

                divisions.Add(currentCell, Division.WestNorthCentral);
                regions.Add(currentCell, Region.Midwest);
            }

            for (int i = 3; i < 12; ++i)
            {
                currentCell = range[i, 7].Value2.ToString();

                divisions.Add(currentCell, Division.SouthAtlantic);
                regions.Add(currentCell, Region.South);
            }

            for (int i = 13; i < 17; ++i)
            {
                currentCell = range[i, 7].Value2.ToString();

                divisions.Add(currentCell, Division.EastSouthCentral);
                regions.Add(currentCell, Region.South);
            }

            for (int i = 18; i < 22; ++i)
            {
                currentCell = range[i, 7].Value2.ToString();

                divisions.Add(currentCell, Division.WestSouthCentral);
                regions.Add(currentCell, Region.South);
            }

            for (int i = 24; i < 32; ++i)
            {
                currentCell = range[i, 7].Value2.ToString();

                divisions.Add(currentCell, Division.Mountain);
                regions.Add(currentCell, Region.West);
            }

            for (int i = 33; i < 37; ++i)
            {
                currentCell = range[i, 7].Value2.ToString();

                divisions.Add(currentCell, Division.Pacific);
                regions.Add(currentCell, Region.West);
            }
        }
    }
}
