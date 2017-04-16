using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Programmr_Challenges.Programmr
{
    public class NumberToString
    {
        #region Problem
        /*Complete the following program which takes input as a number and converts it into string format.initially arrays of string are given just use it for your logic.
        Scenario will be:
        Enter the number:
        54
        Entered number is:
        fifty four*/

        public static void TestClass()
        {
            Console.WriteLine(Convert(54) == "fifty four");
            Console.WriteLine(Convert(1) == "one");
            Console.WriteLine(Convert(99) == "ninety nine");
            Console.WriteLine(Convert(19) == "nineteen");
            Console.ReadLine();
        }
        #endregion

        //Challenge only goes into the tens
        //Given arrays:
        static readonly string[] ones = { "one", "two", "three", "four", "five", "six", "seven", "eight", "nine", "ten", "eleven", "twelve", "thirteen", "fourteen", "fifteen", "sixteen", "seventeen", "eighteen", "nineteen" };
        static readonly string[] tens = { "twenty", "thirty", "forty", "fifty", "sixty", "seventy", "eighty", "ninety" };
   
        public static string Convert(int input)
        {
            var stringitizedInput = input.ToString().ToCharArray();

            if (!stringitizedInput.Any() || input > 99)
                return "";

            if (stringitizedInput.Count() == 1)
                return ones[int.Parse(stringitizedInput[0].ToString()) - 1];

            var tensPlace = int.Parse(stringitizedInput[0].ToString());
            var onesPlace = int.Parse(stringitizedInput[1].ToString());

            if (tensPlace == 1)
                return ones[onesPlace + 9];

            if (onesPlace == 0)
                return tens[tensPlace - 2];

            return string.Concat(tens[tensPlace - 2], " ", ones[onesPlace - 1]);
        }
    }
}
