using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Programmr_Challenges.TopCoder
{
    public static class Iditarod
    {
        #region Problem
        //The Iditarod is a dogsled race from Anchorage to Nome that takes many days. We want to take a list of the times when the competitors crossed the finish line and convert that into the average number of minutes to complete the race.
        //The race starts on day 1 at 8:00 AM. We are given a list of finish times as a String[], where each finish time is formatted as

        //hh:mm xM, DAY n
        //where hh is exactly 2 digits giving the hour, mm is exactly 2 digits giving the minute, x is either 'A' or 'P', and n is a positive integer less than 100 with no leading zeros. So each string has exactly 15 or 16 characters (depending on whether n is less than 10).
        //Create a class Iditarod containing method avgMinutes that is given a String[], times, and that returns the average number of minutes taken by the competitors to complete the race. Round the returned value to the nearest minute, with .5 rounding up.
         
        //Definition
    	
        //Class:	Iditarod
        //Method:	avgMinutes
        //Parameters:	String[]
        //Returns:	int
        //Method signature:	int avgMinutes(String[] times)
        //(be sure your method is public)
    
 
        //Notes
        //-	"12:00 AM, DAY d" refers to midnight between DAY d-1 and DAY d
        //-	"12:00 PM, DAY d" refers to noon on DAY d
 
        //Constraints
        //-	times contains between 1 and 50 elements inclusive
        //-	each element of times is formatted as specified above, with hh between 01 and 12 inclusive, mm between 00 and 59 inclusive, and d between 1 and 99 inclusive
        //-	each element of times represents a time later than the start of the race
 
        //Examples
        //0)	
    	
        //{"12:00 PM, DAY 1","12:01 PM, DAY 1"}
        //Returns: 241
        //From 8:00 AM to noon is 4 hours, so we have 4 hours for one competitor, and 4 hours, 1 minute for the other. These two values average to 240.5 minutes which is rounded up.
        //1)	
    	
        //{"12:00 AM, DAY 2"}
        //Returns: 960
        //The one competitor finished in 16 hours, just at the start of DAY 2.
        //2)	
    	
        //{"02:00 PM, DAY 19","02:00 PM, DAY 20", "01:58 PM, DAY 20"}
        //Returns: 27239
        //26280 minutes, 27720 minutes, 27718 minutes average to 27239.333 which rounds down.

        public static void TestClass()
        {
            Console.WriteLine(avgMinutes(new[] { "12:00 PM, DAY 1", "12:01 PM, DAY 1" }) == 241);
            Console.WriteLine(avgMinutes(new[] { "12:00 AM, DAY 2" }) == 960);
            Console.WriteLine(avgMinutes(new[] { "02:00 PM, DAY 19", "02:00 PM, DAY 20", "01:58 PM, DAY 20" }) == 27239);
            Console.ReadLine();
        }
        #endregion

        public static int avgMinutes(string[] times)
        {
            return Int32.Parse(Math.Round(ProcessTimes(times).Average() + .00001).ToString());
        }

        public static List<int> ProcessTimes(string[] times)
        {
            List<int> result = new List<int>();

            foreach (var time in times)
            {
                var numOfMinutes = -32 * 60;

                var timeDay = time.Split(',');

                numOfMinutes += Int32.Parse(timeDay.Last().Split(' ').Last()) * 60 * 24;

                var timeOfDay = timeDay[0].ToString().Split(' ');

                if (timeOfDay[1] == "PM" && timeOfDay[0].Split(':').First() != "12")
                    numOfMinutes += 12 * 60;

                var dicedUpTime = timeOfDay[0].Split(':');

                if (dicedUpTime[0] == "12" && timeOfDay[1] == "AM")
                    dicedUpTime[0] = "0";

                numOfMinutes += Int32.Parse(dicedUpTime[0]) * 60;

                numOfMinutes += Int32.Parse(dicedUpTime[1]);

                result.Add(numOfMinutes);
            }

            return result;
        }
    }
}
