using System;
using System.Collections.Generic;
using System.Text;

namespace MovieLibrary
{
    //The specification of Movie ADT
    interface iMovie
    {

        string Title // get and set the tile of this movie
        {
            get;
            set;
        }
        string Genre //get and set the genre of this movie
        {
            get;
            set;
        }

        int Classification //get and set the classification of this movie
        {
            get;
            set;
        }

        int Duration //get and set the duration of this movie
        {
            get;
            set;
        }

        int AvailableCopies //get and set the number of the copies of this movie currently available to lend
        {
            get;
            set;
        }

        int NoBorrowings //get and set the number of times that this movie has been borrowed
        {
            get;
            set;
        }

        iMemberCollection getBorrowers  //get all the members who are currently holding this movie
        {
            get;
        }


        void addBorrower(iMember aMember); //add a member to the borrower list

        void deleteBorrower(iMember aMember); //delte a member from the borrower list

        string ToString(); //return a string containning the title, genre, classification, duration, and the number of copies of this movie currently in the community library 

    }
}


