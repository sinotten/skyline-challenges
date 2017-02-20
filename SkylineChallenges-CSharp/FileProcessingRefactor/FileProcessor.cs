using System;
using System.Collections.Generic;

namespace SkylineChallenges_CSharp.FileProcessingRefactor
{
    public class FileProcessor
    {
        public IList<User> Process()
        {
            IList<User> users = new List<User>();
            
            string filePath = AppDomain.CurrentDomain.BaseDirectory + "/FileProcessingRefactor/user-data.csv";
            string fileContents = System.IO.File.ReadAllText(filePath);
            string[] lines = fileContents.Split('\n');
            
            for (int i = 1; i < lines.Length; i++)
            {
                User user = new User();
                Color color = new Color();
                string[] attributes = lines[i].Split(',');
                
                //Setting values that don't need to be altered
                user.Id = new Guid(attributes[0]);
                user.FirstName = attributes[1];
                user.LastName = attributes[2];
                user.Birthday = DateTime.Parse(attributes[3]);
                user.Email = attributes[5];

                //Set Generations based on https://www.careerplanner.com/Career-Articles/Generations.cfm
                if(DateBetweenDates(user.Birthday, DateTime.Parse("1910-01-01"), DateTime.Parse("1924-12-31 23:59:59")))
                    user.Generation = "The Greatest Generation";
                else if(DateBetweenDates(user.Birthday, DateTime.Parse("1925-01-01"), DateTime.Parse("1945-12-31 23:59:59")))
                    user.Generation = "The Silent Generation";
                else if (DateBetweenDates(user.Birthday, DateTime.Parse("1946-01-01"), DateTime.Parse("1964-12-31 23:59:59")))
                    user.Generation = "Baby Boomers";
                else if (DateBetweenDates(user.Birthday, DateTime.Parse("1965-01-01"), DateTime.Parse("1979-12-31 23:59:59")))
                    user.Generation = "Gen X";
                else if (DateBetweenDates(user.Birthday, DateTime.Parse("1980-01-01"), DateTime.Parse("1995-12-31 23:59:59")))
                    user.Generation = "Millenials";
                else if (DateBetweenDates(user.Birthday, DateTime.Parse("1996-01-01"), DateTime.Parse("2010-12-31 23:59:59")))
                    user.Generation = "Generation Z";
                else
                    user.Generation = "Unknown";
                
                //Set Color based on the hex value
                string hexValue = attributes[4].Substring(1);
                color.Red = HexToDecimal(hexValue[0].ToString() + hexValue[1].ToString());
                color.Green = HexToDecimal(hexValue[2].ToString() + hexValue[3].ToString());
                color.Blue = HexToDecimal(hexValue[4].ToString() + hexValue[5].ToString());
                user.ProfileColor = color;

                //Getting credit card information
                string creditCardInfo;
                string creditCardNumberString = attributes[6];
                string creditCardType = attributes[7] != null ? attributes[7].Replace("\r", "") : "";
                
                if (!string.IsNullOrEmpty(creditCardNumberString))
                {
                    switch (creditCardType)
                    {
                        case "Visa":
                            creditCardInfo = "V";
                            break;
                        case "MasterCard":
                            creditCardInfo = "MC";
                            break;
                        case "Discover":
                            creditCardInfo = "D";
                            break;
                        case "American Express":
                            creditCardInfo = "AMEX";
                            break;
                        default:
                            creditCardInfo = "O";
                            break;
                    }

                    creditCardInfo = creditCardInfo + creditCardNumberString.Substring(creditCardNumberString.Length - 4);
                    user.CreditCardInfo = creditCardInfo;
                }

                users.Add(user);
            }

            return users;
        }

        /// <summary>
        /// Convert the two character hexidecimal value into the decimal value
        /// </summary>
        /// <param name="hex">Two character Hex that will be converted</param>
        /// <returns>hexidecimal value of the sum of both characters</returns>
        public int HexToDecimal(string hex)
        {            
            int digitA = SingleHexValue(hex[0]);
            if (digitA == 0) digitA = int.Parse(hex[0].ToString());

            int digitB = SingleHexValue(hex[1]);
            if (digitB == 0) digitB = int.Parse(hex[1].ToString());

            return digitA*16 + digitB;
        }

        /// <summary>
        /// Convert the given string into a hexadecimal value.
        /// </summary>
        /// <param name="hex">single character string that will be converted.</param>
        /// <returns>The integer value of hex</returns>
        private int SingleHexValue(char hex)
        {
            //Convert character to integer
            switch (hex)
            {
                case 'A':
                case 'a':
                    return 10;
                case 'B':
                case 'b':
                    return 11;
                case 'C':
                case 'c':
                    return 12;
                case 'D':
                case 'd':
                    return 13;
                case 'E':
                case 'e':
                    return 14;
                case 'F':
                case 'f':
                    return 15;
                default:
                    return 0;
            }
        }

        /// <summary>
        /// Check if the current date is between the start and end dates
        /// </summary>
        /// <param name="current">The DateTime that may be between the start and end DateTime</param>
        /// <param name="start">The DateTime that represents the start of the range</param>
        /// <param name="end">The DateTime that represents the end of the range</param>
        /// <returns>True if current is between start and end</returns>
        private bool DateBetweenDates(DateTime current, DateTime start, DateTime end)
        {
            if (current.Ticks >= start.Ticks && current.Ticks <= end.Ticks)
                return true;
            else
                return false;

        }
    }
}