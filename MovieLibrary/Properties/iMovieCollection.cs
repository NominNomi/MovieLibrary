using System;
using System.Collections.Generic;
using System.Text;


    //The specification of MovieCollection ADT, which is used to store and manipulate a collection of movies
    interface iMovieCollection
    {
        int Number // get the number of movies in the community library
        {
            get;
        }
        void add(iMovie aMovie); //add a given movie to this tool collection
        void delete(iMovie aMovie); //delete a given movie from this movie collection
        Boolean search(iMovie aMovie); //search a given movie in this movie collection. Return true if this movie is in the movie collection; return false otherwise
        void clear(); //remove all the movies in this movie collection
        iMovie[] toArray(); //output the movies in this collection to an array of iMovies
    }

