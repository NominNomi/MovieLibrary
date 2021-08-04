using System;
using System.Collections.Generic;
using System.Linq;
namespace MovieLibrary
{
    public class MovieCollection
    {
        private int count;
        private int buckets;
        private Movie[] table;

        public MovieCollection() { }

        public MovieCollection(int buckets)
        {
            if (buckets > 0)
            {
                this.buckets = buckets;
                count = 0;
                table = new Movie[buckets];
            }
            
            for (int i = 0; i < buckets; i++)
                table[i] = new Movie("EMPTY", "EMPTY", "EMPTY", 0.00, 0);
        }
        public int Count
        {
            get { return count; }
        }
        public int Capacity
        {
            get { return buckets; }
            set { buckets = Capacity; }
        }
        public int Hashing(string key)
        {
            int k =  Math.Abs(key.GetHashCode());
            return (k % buckets);
        }
        private int Find_Insertion_Bucket(string key)
        {
            int bucket = Hashing(key);
            int i = 0;
            int offset = 0;
            while((i<buckets)&&
                table[(bucket + offset) % buckets].Title != "EMPTY" &&
                table[(bucket + offset) % buckets].Title != "DELETED")
            {
                i++;
                offset++;
            }
            return (offset + bucket) % buckets;
        }

        public void Clear()
        {
            count = 0;
            for(int i=0; i < buckets; i++)
            {
                table[i] = new Movie("EMPTY", "EMPTY", "EMPTY", 0.00, 0);
            }
        }

        public int SearchMovie(string key)
        {
            int bucket = Hashing(key);

            int i = 0;
            int offset = 0;
            //Console.WriteLine(table[(bucket + offset) % buckets].Title + "  HERE");
            while ((i < buckets) &&
                (table[(bucket + offset) % buckets].Title != key) &&
                table[(bucket + offset) % buckets].Title == "EMPTY")
            {
                i++;
                offset++;
                //Console.WriteLine("GGGGG");
            }
            if (table[(bucket + offset) % buckets].Title == key)
            {
                //Console.WriteLine("HHHHH");
                return (offset + bucket) % buckets;
            }
            else
                return -1;
        }
        public bool SearchByTitle(string title)
        {
            int key = SearchMovie(title);
            if (key == -1)
            {
                Console.WriteLine("movie not exist");
                return false;
            }
            else if (table[key].AvailableCopies == 0)
            {
                Console.WriteLine("No available copy of this movie");
                return false;
            }
            else
            {
                table[key].ToString();
                //Console.WriteLine("GGGGG");
                return true;
            }
        }

        public void AddNew(string title, string genre, string classification, double duration, int availableCopies)
        {
            
            int bucket = Find_Insertion_Bucket(title);
            table[bucket] = new Movie(title, genre,classification,duration,availableCopies);
            count++;
            
        }

        public void AddNew()
        {
            Movie aMovie = new Movie();
            Console.WriteLine("enter the title");
            string inputTitle = Convert.ToString(Console.ReadLine());
            Console.WriteLine("enter genre");
            string inputGenre = Convert.ToString(Console.ReadLine());
            Console.WriteLine("enter classification");
            string inputClassification = Convert.ToString(Console.ReadLine());
            Console.WriteLine("enter Duration of the movie");
            double inputDuration = Convert.ToDouble(Console.ReadLine());
            Console.WriteLine("enter Available Copies");
            int inputAvailableCopies = Convert.ToInt32(Console.ReadLine());
            aMovie.Title = inputTitle;
            aMovie.Genre = inputGenre;
            aMovie.Classification = inputClassification;
            aMovie.Duration = inputDuration;
            aMovie.AvailableCopies = inputAvailableCopies;
            if ((Count < table.Length) && (SearchMovie(inputTitle) == -1))
            {
                int bucket = Find_Insertion_Bucket(inputTitle);
                table[bucket] = new Movie(inputTitle, inputGenre,inputClassification,inputDuration,inputAvailableCopies);
                count++;
                Console.WriteLine("Operation Successful");
                Print();
            }
            else
                Console.WriteLine("The key has already been in the hashtable or the hashtable is full");
        }

        public void AddExist()
        {
            Console.WriteLine("enter the title");
            string inputTitle = Convert.ToString(Console.ReadLine());
            Console.WriteLine("how many copies you are adding? ");
            int inputInt = Convert.ToInt32(Console.ReadLine());
            if (SearchByTitle(inputTitle))
            {
                table[SearchMovie(inputTitle)].AvailableCopies += inputInt;
                Console.WriteLine("Operation Successful");
            }
            else Console.WriteLine("Wrong title");
        }

        public bool BorrowMovie(string title)
        {

            if (SearchByTitle(title))
            {
                table[SearchMovie(title)].AvailableCopies -= 1;
                table[SearchMovie(title)].Popularity += 1;
                return true;

            }
            else
            {
                Console.WriteLine("movie not exist");
                return false;
            }
        }
        public void Top3()
        {
            
            List<Movie> temp = new List<Movie>();
            for(int i=0; i < table.Length; i++)
            {
                if (table[i].Popularity > 0)
                {
                    temp.Add(table[i]);
                }
            }
            if (!temp.Any())
            {
                Console.WriteLine("There is no Pop movies now");
            }
            else if (temp.Count == 2)
            {
                temp = temp.OrderByDescending(o => o.Popularity).ToList();
                Console.WriteLine(temp[0].Title +" "+ temp[1].Title);
            }
            else if (temp.Count == 1)
            {
                Console.WriteLine(temp[0].Title);
            }
            else
            {
                temp = temp.OrderByDescending(o => o.Popularity).ToList();
                Console.WriteLine("The top 3 most rented movies are: {0}, {1}, {2}", temp[0].Title, temp[1].Title, temp[2].Title);
            }
            
        }
        public bool ReturnMovie(string title)
        {
            if (SearchByTitle(title))
            {
                table[SearchMovie(title)].AvailableCopies += 1;
                return true;
            }
            else
            {
                Console.WriteLine("Wrong movie title");
                return false;
            }
        }

        
        
        public void Delete()
        {
            Console.WriteLine("enter the title");
            string inputTitle = Convert.ToString(Console.ReadLine());
            int bucket = SearchMovie(inputTitle);
            if (bucket != -1)
            {
                table[bucket] = new Movie("DELETED", "DELETED", "DELETED", 0.00, 0);
                count--;
                Console.WriteLine("Operation Successful");
            }
            else
                Console.WriteLine("The given movie is not in the library");
        }

        

        public void Print()
        {
            for(int i = 0; i < buckets; i++)
            {
                if (table[i].Title=="EMPTY" || table[i].Title=="DELETED")
                    Console.WriteLine("__");
                else
                    Console.WriteLine(table[i].ToString());
            }
            Console.WriteLine();
            Console.WriteLine();
        }
        public void PrintOne()
        {
            Console.WriteLine("enter the title");
            string inputTitle = Convert.ToString(Console.ReadLine());
            if (SearchByTitle(inputTitle))
            {
                Console.WriteLine(table[SearchMovie(inputTitle)].ToString());
            }
            else
                Console.WriteLine("The given movie is not in the library");
        }
    }
}
