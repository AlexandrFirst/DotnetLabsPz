using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LostAndFound_LIB
{
    public static class MyExtensions
    {
        public static T GetRandom<T>(this List<T> inputColletion)
        {
            Random random = new Random();
            return inputColletion[random.Next(inputColletion.Count)];
        }
        public static string FitWithLength(this string input)
        {
            if (input.Length < 20)
                while (input.Length < 20)
                {
                    input = " " + input;
                    input += " ";
                }
            return input;
        }
    }
}
