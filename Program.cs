/*
    Author: Sean Burnham
    Description: This program builds a queue and a dictionary filled with random names and numbers 
                 and outputs them as names and number of hamburgers next to them.
    Date: 09/19/2016
 */

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataStructureBasics
{
    class Program
    {
        public static Random random = new Random(); //allows for random generation

        public static string randomName() //function to return a random name from an already designated array
        {
            string[] names = new string[8] { "Dan Morain", "Emily Bell", "Carol Roche", "Ann Rose", "John Miller", "Greg Anderson", "Arthur McKinney", "Joann Fisher" };
            int randomIndex = Convert.ToInt32(random.NextDouble() * 7);
            return names[randomIndex];
        }

        public static int randomNumberInRange() //function to return a random integer to use for later in the program
        {
            return Convert.ToInt32(random.NextDouble() * 20);
        }
        static void Main(string[] args)
        {

            Queue<string> myQueue = new Queue<string>(); //creates a new queue that holds type string

            Dictionary<string, int> myDictionary = new Dictionary<string, int>(); //builds a new dictionary that has a key of type string and a value of type int

            for(int i = 0; i < 100; i++) //loop to fill up the queue with 100 names from the above function
            {
                myQueue.Enqueue(randomName());
            }

            for(int i = 0; i < myQueue.Count(); i++) //loop to fill dictionary with names in the queue and random numbers from the above function
            {
                int tempNum = randomNumberInRange(); //temporary name to hold the names from the queue
                string tempName = myQueue.Dequeue(); //temporary number to hold the random numbers generated
                if (myDictionary.ContainsKey(tempName)) //this if statement checks to see if the name already exists in the dictionary and then add the number to the already existing value
                {
                    myDictionary[tempName] += tempNum;
                }
                else //this else statement creates a new name in the dictionary to hold hamburger info
                {
                    myDictionary.Add(tempName, tempNum);
                }

            }

            foreach (KeyValuePair<string, int> entry in myDictionary) //this foreach statement prints out each name and the associated number in the dictionary
            {
                Console.Write(entry.Key.PadRight(25));
                Console.WriteLine(entry.Value);
            }
            Console.ReadLine();
        }
    }
}
