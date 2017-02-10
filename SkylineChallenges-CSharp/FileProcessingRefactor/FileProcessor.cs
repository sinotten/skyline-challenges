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

            for (int i = 0; i < lines.Length; i++)
            {
                if (i > 0)
                {
                    User user = new User();

                    string line = lines[i];
                    string[] attributes = line.Split(',');

                    user.Id = new Guid(attributes[0]);
                    user.FirstName = attributes[1];
                    user.LastName = attributes[2];
                    user.Birthday = DateTime.Parse(attributes[3]);
                    user.Email = attributes[5];

                    //Generations based on https://www.careerplanner.com/Career-Articles/Generations.cfm
                    string birthdayString = attributes[3];
                    DateTime birthday = DateTime.Parse(birthdayString);
                    string generation = "Unknown";
                    if (birthday >= DateTime.Parse("1910-01-01") && birthday <= DateTime.Parse("1924-12-31 23:59:59"))
                    {
                        generation = "The Greatest Generation";
                    }
                    else if (birthday >= DateTime.Parse("1925-01-01") && birthday <= DateTime.Parse("1945-12-31 23:59:59"))
                    {
                        generation = "The Silent Generation";
                    }
                    else if (birthday >= DateTime.Parse("1946-01-01") && birthday <= DateTime.Parse("1964-12-31 23:59:59"))
                    {
                        generation = "Baby Boomers";
                    }
                    else if (birthday >= DateTime.Parse("1965-01-01") && birthday <= DateTime.Parse("1979-12-31 23:59:59"))
                    {
                        generation = "Gen X";
                    }
                    else if (birthday >= DateTime.Parse("1980-01-01") && birthday <= DateTime.Parse("1995-12-31 23:59:59"))
                    {
                        generation = "Millenials";
                    }
                    else if (birthday >= DateTime.Parse("1996-01-01") && birthday <= DateTime.Parse("2010-12-31 23:59:59"))
                    {
                        generation = "Generation Z";
                    }
                    else
                    {
                        generation = "Unknown";
                    }

                    user.Generation = generation;

                    string hexValue = attributes[4];
                    hexValue = hexValue.Replace("#", "");
                    string redHex = hexValue[0].ToString() + hexValue[1].ToString();
                    string greenHex = hexValue[2].ToString() + hexValue[3].ToString();
                    string blueHex = hexValue[4].ToString() + hexValue[5].ToString();
                    int red = HexToDecimal(redHex);
                    int green = HexToDecimal(greenHex);
                    int blue = HexToDecimal(blueHex);

                    Color color = new Color();
                    color.Red = red;
                    color.Green = green;
                    color.Blue = blue;
                    user.ProfileColor = color;

                    string creditCardInfo;
                    string creditCardNumberString = attributes[6];
                    string creditCardType = attributes[7] != null ? attributes[7].Replace("\r", "") : "";

                    if (creditCardType.Equals("Visa"))
                    {
                        creditCardInfo = "V";
                    }
                    else if (creditCardType.Equals("MasterCard"))
                    {
                        creditCardInfo = "MC";
                    }
                    else if (creditCardType.Equals("Discover"))
                    {
                        creditCardInfo = "D";
                    }
                    else if (creditCardType.Equals("American Express"))
                    {
                        creditCardInfo = "AMEX";
                    }
                    else
                    {
                        creditCardInfo = "O";
                    }

                    if (creditCardNumberString != null && creditCardNumberString.Equals("") == false)
                    {
                        int creditCardNumberLength = creditCardNumberString.Length;

                        creditCardInfo = creditCardInfo + creditCardNumberString.Substring(creditCardNumberLength - 4);
                        user.CreditCardInfo = creditCardInfo;
                    }

                    users.Add(user);
                }
            }

            return users;
        }

        public int HexToDecimal(string hex)
        {
            string[] digits = new string[2];
            digits[0] = hex[0].ToString();
            digits[1] = hex[1].ToString();
            int digitA = 0;
            int digitB = 0;

            if (digits[0].Equals("A") || digits[0].Equals("a")) digitA = 10;
            if (digits[0].Equals("B") || digits[0].Equals("b")) digitA = 11;
            if (digits[0].Equals("C") || digits[0].Equals("c")) digitA = 12;
            if (digits[0].Equals("D") || digits[0].Equals("d")) digitA = 13;
            if (digits[0].Equals("E") || digits[0].Equals("e")) digitA = 14;
            if (digits[0].Equals("F") || digits[0].Equals("f")) digitA = 15;
            if (digitA == 0) digitA = int.Parse(digits[0]);

            if (digits[1].Equals("A") || digits[1].Equals("a")) digitB = 10;
            if (digits[1].Equals("B") || digits[1].Equals("b")) digitB = 11;
            if (digits[1].Equals("C") || digits[1].Equals("c")) digitB = 12;
            if (digits[1].Equals("D") || digits[1].Equals("d")) digitB = 13;
            if (digits[1].Equals("E") || digits[1].Equals("e")) digitB = 14;
            if (digits[1].Equals("F") || digits[1].Equals("f")) digitB = 15;
            if (digitB == 0) digitB = int.Parse(digits[1]);

            return digitA*16 + digitB;
        }
    }
}