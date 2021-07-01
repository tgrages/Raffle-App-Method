using System;
using System.Collections.Generic;
using System.Threading;
using System.Linq;

namespace ConsoleUI
{
	class Program
    {
      
        //Start writing your code here

        private static Dictionary<int, string> guests = new Dictionary<int, string>();
        private static int min = 1;
        private static int max = 5;
        private static int raffleNumber;
        private static Random _rdm = new Random();

        //Method 1 - Call this method and pass the string method as an argument. This method will return the data you collect from the user, just like Console.ReadLine return as a string output
        static string GetUserInput(string message)
        {
            Console.WriteLine(message);
            string response = Console.ReadLine();
            return response; 
        }

        //Method 2 -
        static void GetUserInfo()
        {
            string name;
            string otherGuest;

            //Want do to ask name of guest and assign guest number
            //store first name entered and store random number

            do
            {
                name = GetUserInput("Please enter your name ");
                if (name == "")
                {
                    Console.WriteLine("Please enter a valid input.");
                    GetUserInfo();
                }
                //generate random number
                while (guests.Keys.Contains(raffleNumber))
                {
                    raffleNumber = GenerateRandomNumber(min, max);
                }

                //add random number and name to dictionary
                AddGuestsInRaffle(raffleNumber, name);
                otherGuest = GetUserInput("Do you want to add another name? ").ToLower();
            }

            while (otherGuest == "yes");
                   

		}

        //Method 3

        static int GenerateRandomNumber(int min, int max)
        {
            int randomNumber = _rdm.Next(min, max);
            return randomNumber;
        }

        //Method 4
        static void AddGuestsInRaffle(int raffleNumber, string name)
        {
            guests.Add(raffleNumber, name);
        }

        //Method 5
        static void PrintGuestName()
        {
            foreach (var i in guests)
            {
                Console.WriteLine(i);
            }
        }

        //Method 6
        static int GetRaffleNumber(Dictionary<int, string> people)
        {
            List<int> raffleNumber = people.Keys.ToList();
            int i = _rdm.Next(raffleNumber.Count);
            int winnerNumber = raffleNumber[i];
            return winnerNumber;
        }

        //Method 7
        static void PrintWinner()
        {
            int winnerNumber = GetRaffleNumber(guests);
            string winnerName = guests[winnerNumber];
            Console.WriteLine($"The winner is: {winnerName} with the #{winnerNumber}");

        }
        static void Main(string[] args)
        {
            Console.WriteLine("Welcome to the Party!!");
            GetUserInfo();            
            MultiLineAnimation();
            PrintGuestName();
            PrintWinner();
            Console.ReadLine();
        }


        static void MultiLineAnimation() // Credit: https://www.michalbialecki.com/2018/05/25/how-to-make-you-console-app-look-cool/
        {
            var counter = 0;
            for (int i = 0; i < 30; i++)
            {
                Console.Clear();

                switch (counter % 4)
                {
                    case 0:
                        {
                            Console.WriteLine("         ╔════╤╤╤╤════╗");
                            Console.WriteLine("         ║    │││ \\   ║");
                            Console.WriteLine("         ║    │││  O  ║");
                            Console.WriteLine("         ║    OOO     ║");
                            break;
                        };
                    case 1:
                        {
                            Console.WriteLine("         ╔════╤╤╤╤════╗");
                            Console.WriteLine("         ║    ││││    ║");
                            Console.WriteLine("         ║    ││││    ║");
                            Console.WriteLine("         ║    OOOO    ║");
                            break;
                        };
                    case 2:
                        {
                            Console.WriteLine("         ╔════╤╤╤╤════╗");
                            Console.WriteLine("         ║   / │││    ║");
                            Console.WriteLine("         ║  O  │││    ║");
                            Console.WriteLine("         ║     OOO    ║");
                            break;
                        };
                    case 3:
                        {
                            Console.WriteLine("         ╔════╤╤╤╤════╗");
                            Console.WriteLine("         ║    ││││    ║");
                            Console.WriteLine("         ║    ││││    ║");
                            Console.WriteLine("         ║    OOOO    ║");
                            break;
                        };
                }

                counter++;
                Thread.Sleep(200);
            }
        }
    }
}
