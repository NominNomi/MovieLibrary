using System;
using System.Collections.Generic;
using System.Text;

namespace MovieLibrary
{
    //The specification of Member ADT
    interface iMember
    {

        string FirstName  //get and set the first name of this member
        {
            get;
            set;
        }
        string LastName //get and set the last name of this member
        {
            get;
            set;
        }

        string ContactNumber //get and set the contact number of this member
        {
            get;
            set;
        }

        int Pin //get and set a four-digit pin number
        {
            get;
            set;
        }

        string[] getBorrowingMovieDVDs //get a list of movies that this memebr is currently borrowing
        {
            get;
        }

        void addMovie(iMovie aMovie); //add a given movie DVD to the list of movies DVDs that this member is currently holding

        void deleteMovie(iMovie aMovie); //delete a given movie DVD from the list of movie DVDs that this member is currently holding

        string ToString(); // return a string containing the first name, last name and contact number of this memeber 
    }
}
