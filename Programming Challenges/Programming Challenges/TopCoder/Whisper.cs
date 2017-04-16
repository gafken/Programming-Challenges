using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Programmr_Challenges.TopCoder
{
    public static class Whisper
    {
        #region Problem
        //When people whisper to each other in the TopCoder arena, they type "/msg <username> <message>" (quotes and angle brackets for clarity only). However, TopCoder allows users to have spaces in their names. This leads to some ambiguity in regards to who a whisper is actually addressed to. For examples if a user types in "/msg John Doe hi there", this could interpreted in a number of ways. It could be that the user is trying to send the message "Doe hi there" to a user named "John" or it could be that the message is to a user "John Doe", and has content "hi there".

        //To figure this out you should take a list of users who are logged in, and determine, of the users that the message could possibly be to, which one has the longest name. It may only be to a user if it starts exactly with "/msg <username> ". That is, "/msg " followed by a single space, followed by the user's handle, followed by another space. Thus, if someone typed in "/msg John Doe hi there" and the people logged in were {"John","John Doe","John Doe h"}, the message could be to either "John Doe" or "John" (but not "John Doe h" because there is not a space following his handle in the typed string). Of those two, "John Doe" has the longer name, so we assume it is to him.

        //Additionally, all whispering is case insensitive, so "/msg John Doe hi there" will go to the same person as "/MSG jOHN dOE HI THERE".

        //If there is no user who the message could be to return "user is not logged in" (see examples) 

        //If typed does not begin with "/msg " return "not a whisper" (note that there is a space at the end of "/msg ").

 
        //Definition
    	
        //Class:	Whisper
        //Method:	toWhom
        //Parameters:	String[], String
        //Returns:	String
        //Method signature:	String toWhom(String[] usernames, String typed)
        //(be sure your method is public)
    
 
        //Notes
        //-	A double space in typed does not match a single space in usernames. (see examples)
        //-	When the user is found, the returned case should match the case in usernames. (see examples)
 
        //Constraints
        //-	Each element of usernames will contain only letters ('a'-'z' and 'A'-'Z'), and spaces.
        //-	usernames will contain between 1 and 50 elements, inclusive.
        //-	Each element of usernames will have between 1 and 50 characters in length, inclusive.
        //-	Elements of usernames will not have leading, trailing, or double spaces.
        //-	No two elements of usernames will be identical, ignoring case.
        //-	typed will be between 1 and 50 characters, inclusive and will contain only letters ('a'-'z' and 'A'-'Z'), spaces, and slashes ('/').
 
        //Examples
        //0)	
    	
        //{"John","John Doe","John Doe h"}
        //"/msg John Doe hi there"
        //Returns: "John Doe"
        //"John Doe" is longer than "John", and "John Doe h" does not match the typed letters.
        //1)	
    	
        //{"John","John Doe","John Doe h"}
        //"/MSG jOHN dOE HI THERE"
        //Returns: "John Doe"
        //Note that "/msg", as well as the user's name is case insensitive. Also note that the case of the return matches the usernames parameter, not the typed parameter.
        //2)	
    	
        //{"writer"}
        //"writer hi"
        //Returns: "not a whisper"
        //This is not a whisper.
        //3)	
    	
        //{"tester"}
        //"/msg testerTwo you there"
        //Returns: "user is not logged in"
        //There is no one logged in named "testerTwo" or "testerTwo you"
        //4)	
    	
        //{"lbackstrom"}
        //"/msg lbackstrom"
        //Returns: "user is not logged in"
        //Since, by our definition, a message is only to someone if there is a space following their name, this message is not to lbackstrom. However, it does start with "/msg ", so we don't return "not a whisper". Although it may seems rather strange, by the rules we return "user is not logged in".
        //5)	
    	
        //{"me"}
        //"/msg  me hi"
        //Returns: "user is not logged in"
        //Again note that, by our strict definition of what it means for a message to be to a user, the double space prevents this message from going to the user "me"
        //6)	
    	
        //{"abc"}
        //" /msg abc note the leading space"
        //Returns: "not a whisper"
        //7)	
    	
        //{"Wow"}
        //"/msg Wow "
        //Returns: "Wow"
        //8)	
    	
        //{"msg"}
        //"/msg"
        //Returns: "not a whisper"

        public static void TestClass()
        {
            Console.WriteLine(toWhom(new[] { "John", "John Doe", "John Doe h" }, "/msg John Doe hi there") == "John Doe");
            Console.WriteLine(toWhom(new[] { "John", "John Doe", "John Doe h" }, "/MSG jOHN dOE HI THERE") == "John Doe");
            Console.WriteLine(toWhom(new[] { "writer" }, "writer hi") == "not a whisper");
            Console.WriteLine(toWhom(new[] { "tester" }, "/msg testerTwo you there") == "user is not logged in");
            Console.WriteLine(toWhom(new[] { "lbackstrom" }, "/msg lbackstrom") == "user is not logged in");
            Console.WriteLine(toWhom(new[] { "me" }, "/msg  me hi") == "user is not logged in");
            Console.WriteLine(toWhom(new[] { "abc" }, " /msg abc note the leading space") == "not a whisper");
            Console.WriteLine(toWhom(new[] { "Wow" }, "/msg Wow ") == "Wow");
            Console.WriteLine(toWhom(new[] { "msg" }, "/msg") == "not a whisper");
            Console.ReadLine();
        }
        #endregion

        public static string toWhom(string[] usernames, string typed)
        {
            var unsortedWords = typed.Split(' ');
            typed = typed.ToLower();

            if (!typed.StartsWith(@"/msg "))
                return "not a whisper";

            var name = usernames.Where(u => typed.Contains(u.ToLower()) && typed.Contains(@"/msg " + u.ToLower() + " ")).OrderByDescending(u => u.Length);
            
            if (!name.Any())
                return "user is not logged in";

            return name.First();
        }
    }
}
