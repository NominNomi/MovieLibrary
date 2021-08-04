using System;

namespace MovieLibrary
{
    public class Movie
    {
        private string title;
        private string genre;
        private string classification;
        private double duration;
        private int availableCopies;
        private int noBorrowing;
        private int popularity;

        public Movie()
        {

        }
        
        public Movie(string title, string genre, string classification, double duration,int availableCopies)
        {
            this.title = title;
            this.genre = genre;
            this.classification = classification;
            this.duration = duration;
            this.availableCopies = availableCopies;
                
        }
        public string Title
        {
            get { return title; }
            set { title = value; }
        }
        public string Genre
        {
            get { return genre; }
            set { genre = value; }
        }
        public string Classification
        {
            get { return classification; }
            set { classification = value; }
        }
        public double Duration
        {
            get { return duration; }
            set { duration = value; }
        }
        public int AvailableCopies
        {
            get { return availableCopies; }
            set { availableCopies = value; }
        }
        public int NoBorrowing
        {
            get { return noBorrowing; }
            set { noBorrowing = value; }
        }
        public int Popularity
        {
            get { return popularity; }
            set { popularity = value; }
        }
        public override string ToString()
        {
            {
                return
                "Title: "+Title.ToString()+" "+
                "Genre: "+Genre.ToString() + " " +
                "Class: "+Classification.ToString() + " " +
                "Dur: "+Duration.ToString() + " " +
                "Copies: "+AvailableCopies.ToString();
            }
        }
        public void Sort()
        {

        }
    }
}
