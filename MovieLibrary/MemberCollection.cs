using System;
using System.Linq;
using System.Collections.Generic;
using System.Collections;
namespace MovieLibrary
{
    public class MemberCollection
    {
        private Member[] members;
        private int number;
        

        public MemberCollection(int num)
        {
            members = new Member[num];
            for(int i=0; i < members.Length; i++)
            {
                members[i] = new Member("EMPTY", "EMPTY", "EMPTY", 0000);
            }
        }

        public  Member[] Members
        {
            get { return members; }
            
        }
        public int Number
        {
            get { return number; }
        }

        public void add()
        {
            Console.WriteLine("enter first name");
            string inputFirstName = Convert.ToString(Console.ReadLine());
            
            Console.WriteLine("enter last name");
            string inputLastName = Convert.ToString(Console.ReadLine());
            
            Console.WriteLine("enter phone number");
            string inputPhoneNumber = Convert.ToString(Console.ReadLine());
            
            Console.WriteLine("enter a 4 digit new pin");
            int inputPin = Convert.ToInt32(Console.ReadLine());

            for (int i = 0; i < members.Length; i++)
            {
                if (members[i].FirstName == "EMPTY")
                {
                    members[i].FirstName = inputFirstName;
                    members[i].LastName = inputLastName;
                    members[i].ContactNumber = inputPhoneNumber;
                    members[i].Pin = inputPin;
                    
                    break;
                }

            }
        }

        public void Add(string firstName,string lastName,string contactNumber,int pin)
        {
            
            for(int i = 0; i < members.Length; i++)
            {
                if(members[i].FirstName == "EMPTY")
                {
                    members[i].FirstName = firstName;
                    members[i].LastName = lastName;
                    members[i].ContactNumber = contactNumber;
                    members[i].Pin = pin;
                    
                    break;
                }
                
            }
            
        }

        public void delete()
        {
            Console.WriteLine("enter first name");
            string inputFirstName = Convert.ToString(Console.ReadLine());
            Console.WriteLine("enter last name");
            string inputLastName = Convert.ToString(Console.ReadLine());
            Member temp = new Member();
            for (int i = 0; i < members.Length; i++)
            {
                if (members[i].FirstName == inputFirstName && members[i].LastName == inputLastName)
                {

                    temp = members[i];
                }
                else Console.WriteLine("Member not exist");
            }
            members = members.Where(val => val != temp).ToArray();
        }

        public void GetContactNumber()
        {
            Console.WriteLine("enter first name");
            string inputFirstName = Convert.ToString(Console.ReadLine());
            for (int i = 0; i < members.Length; i++)
            {
                if (members[i].FirstName == inputFirstName)
                {
                    Console.WriteLine("The contact number for {0} is:  {1}", members[i].FirstName, members[i].ContactNumber);
                    
                }
                else Console.WriteLine("Member not exist");
            }
        }

        public bool MemberCheck(string firstName, string lastName, int pin)
        {
            
            for (int i = 0; i < members.Length; i++)
            {
                if (members[i].FirstName == firstName && members[i].LastName == lastName && members[i].Pin == pin)
                {
                    return true;
                    
                }
                
            }
            return false;
        }
        public void MemberBorrows(string firstName, string lastName, string title)
        {
            for(int i=0; i < members.Length; i++)
            {
                if (members[i].FirstName == firstName && members[i].LastName == lastName)
                {
                    members[i].addToDVDs(title);
                    Console.WriteLine("Operation Successful");

                }
            }
        }
        

        public void MemberReturns(string firstName, string lastName, string title)
        {
            
            for (int i = 0; i < members.Length; i++)
            {
                if (members[i].FirstName == firstName && members[i].LastName == lastName )
                {
                    if (members[i].HoldingDVDs.Contains(title))
                    {
                        members[i].deleteFromDVDs(title);
                        Console.WriteLine("Operation Successful");
                    }
                    else
                    {
                        Console.WriteLine("You don't hold this movie");
                        break;
                    }
                }
                
            }
        }

        public void GetBorrowers()
        {
            Console.WriteLine("enter the title");
            string inputTitle = Convert.ToString(Console.ReadLine());
            
            for (int i = 0; i < members.Length; i++)
            {
                if (members[i].HoldingDVDs.Contains(inputTitle))
                {
                    Console.WriteLine("The members who holding this movie are: {0} {1}", members[i].FirstName, members[i].LastName);
                }

                else Console.WriteLine("No one holding that movie");
            }
            
        }

        public void CheckMembersHold()
        {
            Console.WriteLine("enter first name");
            string inputFirstName = Convert.ToString(Console.ReadLine());
            Console.WriteLine("enter last name");
            string inputLastName = Convert.ToString(Console.ReadLine());
            for (int i = 0; i < members.Length; i++)
            {
                if (members[i].FirstName == inputFirstName && members[i].LastName == inputLastName)
                {
                    Console.WriteLine(members[i].HoldingDVDs+"  ");
                    

                }
                else Console.WriteLine("Member not exist");
            }
        }
        public void CheckMembersHold(string firstName,string lastName)
        {
            for (int i = 0; i < members.Length; i++)
            {
                if (members[i].FirstName == firstName && members[i].LastName == lastName)
                {
                    Console.WriteLine(members[i].HoldingDVDs + "  ");


                }
                else Console.WriteLine("Member not exist");
            }
        }
        public bool search(Member member)
        {
            for(int i=0; i < members.Length; i++)
            {
                if (members[i].FirstName == member.FirstName && members[i].LastName == member.LastName)
                {
                    return true;
                }
                
            }
            return false;
        }
        public void clear()
        {
            for(int i=0; i < members.Length; i++)
            {
                Array.Clear(members, i, members.Length);
            }
        }
        public void Print()
        {
            for(int i = 0; i < members.Length; i++)
            {
                Console.WriteLine(members[i].ToString());
            }
        }
    }
}
