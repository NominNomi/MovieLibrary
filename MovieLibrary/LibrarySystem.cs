using System;
using System.Collections;
using System.Collections.Generic;
namespace MovieLibrary
{
    class LibrarySystem
    {
        public static void Main(string[] args)
        {
            MovieCollection aMovieCollection = new MovieCollection(17);
            MemberCollection aMemberCollection = new MemberCollection(10);
            aMovieCollection.AddNew("The Lord of the Ring I", "Adventure", "General", 3.4, 5);
            aMovieCollection.AddNew("The Lord of the Ring II", "Adventure", "General", 3.4, 5);
            aMovieCollection.AddNew("The Lord of the Ring III", "Adventure", "General", 3.4, 5);
            aMovieCollection.Print();
            aMemberCollection.Add("Jim", "Curry", "04123456", 1234);
            aMemberCollection.Add("Tom", "T", "04234567", 1234);
            aMemberCollection.Print();
            while (true)
            {
                Console.WriteLine("Please enter your command as follows: ");
                Console.WriteLine("1. Staff");
                Console.WriteLine("2. Member");
                Console.WriteLine("3. End the program");
                int command = Convert.ToInt32(Console.ReadLine());
                if (command == 1)
                {
                    while (true)
                    {
                        Console.WriteLine("'A' for adding new movie");
                        Console.WriteLine("'B' for adding existing movie");
                        Console.WriteLine("'C' for delete a movie");
                        Console.WriteLine("'D' for adding a member");
                        Console.WriteLine("'E' for delete a member");
                        Console.WriteLine("'F' for get the contact number of a member");
                        Console.WriteLine("'G' for get the members who holding the movie");
                        Console.WriteLine("'9999' to back to main manu");
                        string command1 = Convert.ToString(Console.ReadLine());
                        if (command1 == "A")
                        {
                            aMovieCollection.AddNew();
                        }
                        else if (command1 == "B")
                        {
                            aMovieCollection.AddExist();
                        }
                        else if (command1 == "C")
                        {
                            aMovieCollection.Delete();
                        }
                        else if (command1 == "D")
                        {
                            aMemberCollection.add();
                        }
                        else if (command1 == "E")
                        {
                            aMemberCollection.delete();
                        }
                        else if (command1 == "F")
                        {
                            aMemberCollection.GetContactNumber();
                        }
                        else if (command1 == "G")
                        {
                            aMemberCollection.GetBorrowers();
                        }
                        else if (command1 == "9999")
                        {
                            break;
                        }
                        else
                        {
                            Console.WriteLine("Invalid command, enter again");

                        }
                    }
                }
                else if (command == 2)
                {
                    while (true)
                    {
                        Console.WriteLine("'H' for display all the movie in this library");
                        Console.WriteLine("'I' for display one specific movie");
                        Console.WriteLine("'J' for a member borrows a movie");
                        Console.WriteLine("'K' for a member returns a movie");
                        Console.WriteLine("'L' for check the DVDs a member hold");
                        Console.WriteLine("'M' for display the top 3 most borrowed movies");
                        Console.WriteLine("'9999' to back to main manu");
                        string command2 = Convert.ToString(Console.ReadLine());
                        if (command2 == "H")
                        {
                            aMovieCollection.Print();
                        }
                        else if (command2 == "I")
                        {
                            aMovieCollection.PrintOne();
                        }
                        else if (command2 == "J")
                        {
                            Console.WriteLine("enter first name");
                            string inputFirstName = Convert.ToString(Console.ReadLine());
                            Console.WriteLine("enter last name");
                            string inputLastName = Convert.ToString(Console.ReadLine());
                            Console.WriteLine("enter the pin");
                            int inputPin = Convert.ToInt32(Console.ReadLine());
                            if (aMemberCollection.MemberCheck(inputFirstName, inputLastName, inputPin))
                            {
                                Console.WriteLine("enter the title");
                                string inputTitle = Convert.ToString(Console.ReadLine());
                                if (aMovieCollection.BorrowMovie(inputTitle))
                                {
                                    aMemberCollection.MemberBorrows(inputFirstName, inputLastName, inputTitle);
                                }
                            }
                        }
                        else if (command2 == "K")
                        {
                            Console.WriteLine("enter first name");
                            string inputFirstName = Convert.ToString(Console.ReadLine());
                            Console.WriteLine("enter last name");
                            string inputLastName = Convert.ToString(Console.ReadLine());
                            Console.WriteLine("enter the pin");
                            int inputPin = Convert.ToInt32(Console.ReadLine());
                            if (aMemberCollection.MemberCheck(inputFirstName, inputLastName, inputPin))
                            {
                                Console.WriteLine("enter the title");
                                string inputTitle = Convert.ToString(Console.ReadLine());
                                if (aMovieCollection.ReturnMovie(inputTitle))
                                {
                                    aMemberCollection.MemberReturns(inputFirstName, inputLastName, inputTitle);
                                }
                            }
                        }
                        else if (command2 == "L")
                        {
                            aMemberCollection.CheckMembersHold();
                        }
                        else if (command2 == "M")
                        {
                            aMovieCollection.Top3();
                        }
                        else if (command2 == "9999")
                        {
                            break;
                        }
                        else Console.WriteLine("Invalid command, enter again");
                    }
                }
                else if (command == 3)
                {
                    break;
                }
                else Console.WriteLine("Invalid command, enter again");


            }
        }
    }
}
