using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Programmr_Challenges.Programmr
{
    public static class DecimalToBinary
    {
        #region Problem
        /*Complete the following program to convert decimal number into binary form. program will take input number from user and will display its binary equivalent.
        scenario should be same like this
        Example1:
        Enter the decimal number:5
        Binary equivalent of the number is:
        101

        Example2:
        Enter the decimal number:8
        Binary equivalent of the number is:
        1000*/

        public static void TestClass()
        {
            Console.WriteLine(Convert(5) == "101");
            Console.WriteLine(Convert(8) == "1000");
            Console.ReadLine();
        }
        #endregion

        //I realize I'm rebuilding already existing things with AllPower2s but, since
        //I'm since I'm rebuilding a binary converter, why not rebuild the whole thing?

        static DecimalToBinary()
        {
            var temp = new List<decimal>();

            for (int i = 0; i < 64; i++)
                temp.Add((decimal)Math.Pow(2, i));

            Allpower2s = temp.ToArray();  //faster indexing  :D
        }

        private static decimal[] Allpower2s;
        
        public static string Convert(decimal input, int bitCount = 32, bool trimLeading0s = true)
        {
            var greatestBitValue = Allpower2s.First(value => value > input);

            var applicablePower2s = Allpower2s.Where(x => x <= greatestBitValue).ToArray().OrderByDescending(x => x);

            string binaryValue = "";

            foreach (var power in applicablePower2s)
                if (input - power >= 0)
                {
                    binaryValue += "1";
                    input -= power;
                }
                else
                    binaryValue += "0";

            return trimLeading0s ? binaryValue.TrimStart('0') : binaryValue;
        }
    }
}
