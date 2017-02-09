using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace SkylineChallenges_CSharp.FileProcessingRefactor
{
    public class Color
    {
        public int Red { get; set; }
        public int Green { get; set; }
        public int Blue { get; set; }

        public Color()
        {
            
        }

        public Color(int red, int green, int blue)
        {
            Red = red;
            Green = green;
            Blue = blue;
        }

        public string ToRGBString()
        {
            return "rgb(" + this.Red + ", " + this.Blue + ", " + this.Green + ")";
        }
    }
}
