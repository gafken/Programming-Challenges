using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Programmr_Challenges.TopCoder
{
    public static class Billboard
    {
        #region Problem
        //An electronic billboard is supposed to display large letters by using several lightbulbs per letter. Given a message, and how each enlarged letter looks as a 5x5 arrangement of lightbulbs, return the enlarged message.

        //The enlarged representation of the letters will be in a String[] with each element formatted as follows (quotes added for clarity):

        //"<letter>:*****-*****-*****-*****-*****"

        //Where <letter> is a single uppercase letter [A-Z], and each * is either the character '#' (representing a lit lightbulb) or a period ('.') (representing an unlit lightbulb). Each group of 5 (delimited by a dash, '-') represents a row in the 5x5 representation of the letter. So, "T:#####-..#..-..#..-..#..-..#.." means that the 5x5 representation of 'T' is:

        //"#####"
        //"..#.."
        //"..#.."
        //"..#.."
        //"..#.."
        //Return the enlarged message as a 5-element String[], with each element representing one row of lightbulbs (where element 0 is the top row). Leave 1 (one) column of periods ('.') between each adjacent pair of letters in the enlarged message.

 
        //Definition
    	
        //Class:	Billboard
        //Method:	enlarge
        //Parameters:	String, String[]
        //Returns:	String[]
        //Method signature:	String[] enlarge(String message, String[] letters)
        //(be sure your method is public)
    
 
        //Constraints
        //-	message will contain between 1 and 10 characters, inclusive.
        //-	each character of message will be an uppercase letter [A-Z].
        //-	letters will contain between 1 and 10 elements, inclusive.
        //-	each element of letters will be exactly 31 characters in length.
        //-	each element of letters will be formatted as (quotes added for clarity): "<letter>:*****-*****-*****-*****-*****", where <letter> is a single uppercase letter [A-Z] (inclusive) representing the letter being enlarged, and each * is either the character '#' or a period.
        //-	every letter appearing in message will have an enlarged representation in letters.
        //-	each letter represented in letters will be unique.
 
        //Examples
        //0)	
    	
        //"TOPCODER"
        //{"T:#####-..#..-..#..-..#..-..#.."
        //,"O:#####-#...#-#...#-#...#-#####"
        //,"P:####.-#...#-####.-#....-#...."
        //,"C:.####-#....-#....-#....-.####"
        //,"D:####.-#...#-#...#-#...#-####."
        //,"E:#####-#....-####.-#....-#####"
        //,"R:####.-#...#-####.-#.#..-#..##"}
        //Returns: 
        //{ "#####.#####.####...####.#####.####..#####.####.",
        // "..#...#...#.#...#.#.....#...#.#...#.#.....#...#",
        // "..#...#...#.####..#.....#...#.#...#.####..####.",
        // "..#...#...#.#.....#.....#...#.#...#.#.....#.#..",
        // "..#...#####.#......####.#####.####..#####.#..##" }
        //1)	
    	
        //"DOK"
        //{"D:####.-#...#-#...#-#...#-####."
        //,"O:#####-#...#-#...#-#...#-#####"
        //,"K:#...#-#..#.-###..-#..#.-#...#"}
        //Returns: 
        //{ "####..#####.#...#",
        // "#...#.#...#.#..#.",
        // "#...#.#...#.###..",
        // "#...#.#...#.#..#.",
        // "####..#####.#...#" }
        //2)	
    	
        //"RANDOMNESS"
        //{"S:##.##-#####-#.#.#-#.#.#-####."
        //,"N:#####-#####-#####-#####-#####"
        //,"R:#####-#####-##.##-#####-#####"
        //,"A:.....-.....-.....-.....-....."
        //,"D:#.#.#-.#.#.-#.#.#-.#.#.-#.#.#"
        //,"O:#####-#...#-#.#.#-#...#-#####"
        //,"E:#....-.#...-..#..-...#.-....#"
        //,"M:#....-.....-.....-.....-....."
        //,"X:#...#-.#.#.-..#..-.#.#.-#...#"}
        //Returns: 
        //{ "#####.......#####.#.#.#.#####.#.....#####.#.....##.##.##.##",
        // "#####.......#####..#.#..#...#.......#####..#....#####.#####",
        // "##.##.......#####.#.#.#.#.#.#.......#####...#...#.#.#.#.#.#",
        // "#####.......#####..#.#..#...#.......#####....#..#.#.#.#.#.#",
        // "#####.......#####.#.#.#.#####.......#####.....#.####..####." }
        //Note that the letter X is defined but never used.

        public static void TestClass()
        {
            Console.WriteLine(enlarge("TOPCODER", new[] { "T:#####-..#..-..#..-..#..-..#..", "O:#####-#...#-#...#-#...#-#####", "P:####.-#...#-####.-#....-#....", "C:.####-#....-#....-#....-.####", "D:####.-#...#-#...#-#...#-####.", "E:#####-#....-####.-#....-#####", "R:####.-#...#-####.-#.#..-#..##" })
                                        .SequenceEqual(new[] { "#####.#####.####...####.#####.####..#####.####.", "..#...#...#.#...#.#.....#...#.#...#.#.....#...#", "..#...#...#.####..#.....#...#.#...#.####..####.", "..#...#...#.#.....#.....#...#.#...#.#.....#.#..", "..#...#####.#......####.#####.####..#####.#..##" }));
            Console.WriteLine(enlarge("DOK", new[] { "D:####.-#...#-#...#-#...#-####.", "O:#####-#...#-#...#-#...#-#####", "K:#...#-#..#.-###..-#..#.-#...#" })
                                        .SequenceEqual(new[] { "####..#####.#...#", "#...#.#...#.#..#.", "#...#.#...#.###..", "#...#.#...#.#..#.", "####..#####.#...#" }));
            Console.WriteLine(enlarge("RANDOMNESS", new[] { "S:##.##-#####-#.#.#-#.#.#-####.", "N:#####-#####-#####-#####-#####", "R:#####-#####-##.##-#####-#####", "A:.....-.....-.....-.....-.....", "D:#.#.#-.#.#.-#.#.#-.#.#.-#.#.#", "O:#####-#...#-#.#.#-#...#-#####", "E:#....-.#...-..#..-...#.-....#", "M:#....-.....-.....-.....-.....", "X:#...#-.#.#.-..#..-.#.#.-#...#" })
                                        .SequenceEqual(new[] { "#####.......#####.#.#.#.#####.#.....#####.#.....##.##.##.##", "#####.......#####..#.#..#...#.......#####..#....#####.#####", "##.##.......#####.#.#.#.#.#.#.......#####...#...#.#.#.#.#.#", "#####.......#####..#.#..#...#.......#####....#..#.#.#.#.#.#", "#####.......#####.#.#.#.#####.......#####.....#.####..####." }));
            Console.ReadLine();
        }
        #endregion

        public static string[] enlarge(string message, string[] letters)
        {
            List<string[]> processedCheeses = new List<string[]>();

            for (var i = 0; i < 5; i++)
            {
                processedCheeses.Add(new string[message.Length]);
            }

            for (var i = 0; i < message.Length; i++)
            {
                var key = letters.First(l => l.StartsWith(message[i].ToString()));

                var elements = key.Split(':').Last().Split('-');

                for (int j = 0; j < 5; j++)
                {
                    processedCheeses[j][i] = elements[j];
                }
            }

            var result = new List<string>();

            foreach (var processedCheese in processedCheeses)
            {
                result.Add(string.Join(".", processedCheese));
            }

            return result.ToArray();
        }
    }
}
