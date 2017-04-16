using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Programmr_Challenges.TopCoder
{
    public static class StreetParking
    {
        #region Problem        	
        //You are looking for a place to park your car on a suburban street. You can park at any position that meets the following requirements:

        //1.	It is not directly in front of a private driveway.
        //2.	It is not directly in front of a bus stop.
        //3.	It is not 5 meters before a bus stop.
        //4.	It is not 10 meters before a bus stop.
        //5.	It is not directly in front of a side-street.
        //6.	It is not 5 meters before a side-street.
        //7.	It is not 5 meters after a side-street.
        //The street will be represented as a String, where each character describes a section of the street 5 meters in length. So the first character describes the first 5 meters of the street, the second character describes the next 5 meters and so on. street will use 'D' for driveway, 'B' for bus stop, 'S' for side-street and '-' for all other sections of the street. A position is directly in front of an object if it has the same index as the object in street. A position is before an object if its index is lower than the index of the object in street. Finally, a position is after an object if its index is higher than the index of the object in street.

        //Given the street return the total number of possible parking spaces on that street.

 
        //Definition
    	
        //Class:	StreetParking
        //Method:	freeParks
        //Parameters:	String
        //Returns:	int
        //Method signature:	int freeParks(String street)
        //(be sure your method is public)
    
 
        //Constraints
        //-	street will have between 1 and 50 characters inclusive.
        //-	street will only contain characters 'D', 'B', 'S' and '-'.
 
        //Examples
        //0)	
    	
        //"---B--S-D--S--"
        //Returns: 4
        //The street looks like this:
        //---B--S-D--S--
        //^   ^    ^   ^
        //|   |    |   |
        //The arrows indicate where you are allowed to park on this street. Thus the method should return 4.
        //1)	
    	
        //"DDBDDBDDBDD"
        //Returns: 0
        //This street is full of private driveways and bus stops. You cannot park anywhere on this street. The method should return 0.
        //2)	
    	
        //"--S--S--S--S--"
        //Returns: 2
        //You can only park at the first and last positions on this street. The method should return 2.
        //3)	
    	
        //"SSD-B---BD-DDSB-----S-S--------S-B----BSB-S--B-S-D"
        //Returns: 14

        public static void TestClass()
        {
            Console.WriteLine(freeParks("---B--S-D--S--") == 4);
            Console.WriteLine(freeParks("DDBDDBDDBDD") == 0);
            Console.WriteLine(freeParks("--S--S--S--S--") == 2);
            Console.WriteLine(freeParks("SSD-B---BD-DDSB-----S-S--------S-B----BSB-S--B-S-D") == 14);
            Console.ReadLine();
        }
        #endregion

        public static int freeParks(string street)
        {
            var numOfSpaces = 0;

            for (int i = 0; i < street.Length; i++)
            {
                if ((street[i] == 'B'
                    || street[i] == 'D'
                    || street[i] == 'S')
                    || (i + 1 < street.Length && (street[i + 1] == 'B'
                                               || street[i + 1] == 'S'))
                    || (i + 2 < street.Length && street[i + 2] == 'B')
                    || (i - 1 >= 0 && street[i - 1] == 'S'))
                    continue;

                numOfSpaces++;
            }

            return numOfSpaces;
        }
    }
}
