using System;
using System.Linq;
using System.Text;

namespace SkylineChallenges_CSharp.FakeBinary
{
    public class FakeBinary
    {
        public string ConvertToFakeBinary(string a)
        {
            //String that gets returned
            StringBuilder fakeBinary = new StringBuilder(a.Length);

            //Go through each character and add to fakeBinary
            for(int i = 0; i < a.Length; ++i)
            {
                switch(a[i])
                {
                    case '0':
                    case '1':
                    case '2':
                    case '3':
                    case '4':
                        fakeBinary.Append("0");
                        break;
                    case '5':
                    case '6':
                    case '7':
                    case '8':
                    case '9':
                        fakeBinary.Append("1");
                        break;
                    //Always have a default, putting an error character in it's place
                    default:
                        fakeBinary.Append("E");
                        break;
                }
            }

            return fakeBinary.ToString();
        }
    }
}
