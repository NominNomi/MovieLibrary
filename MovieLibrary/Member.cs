using System;
using System.Linq;
using System.Collections.Generic;
namespace MovieLibrary
{
    public class Member
    {
        private string firstName;
        private string lastName;
        private string contactNumber;
        private int pin;
        //private string[] holdingDVDs;
        private List<string> holdingDVDs;
        

        public string FirstName
        {
            get { return firstName; }
            set { firstName = value; }
        }
        public string LastName
        {
            get { return lastName; }
            set { lastName = value; }
        }
        public string ContactNumber
        {
            get { return contactNumber; }
            set { contactNumber = value; }
        }
        public int Pin
        {
            get { return pin; }
            set { pin = value; }
        }
        public List<string> HoldingDVDs
        {
            get { return holdingDVDs; }
            set { holdingDVDs = value; }
        }
        public void addToDVDs(string title)
        {
            HoldingDVDs.Add(title);
        }
        public void deleteFromDVDs(string title)
        {
            HoldingDVDs.Remove(title);
        }


        public Member()
        {
        }
        public Member(string firstName,string lastName,string contactNumber,int pin)
        {
            FirstName = firstName;
            LastName = lastName;
            ContactNumber = contactNumber;
            Pin = pin;
            holdingDVDs = new List<string>();
        }
        
        public override string ToString()
        {
            return FirstName.ToString() + " " + LastName.ToString() + " " + ContactNumber.ToString();
        }
    }
}
