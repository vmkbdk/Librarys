using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library
{
    class Book
    {
        public string Titel { get; set; }
        public string Author { get; set; }
        public bool IsAvailable { get; set; }
    }
    class Library
    {
        List<Book> Books = new List<Book>();
        public void AddBook(Book Book)
        {
            try
            {
                if (string.IsNullOrEmpty(Book.Titel) || string.IsNullOrEmpty(Book.Author))
                {
                    Console.WriteLine("Book titel and author must not be empty.");
                }
                Books.Add(Book);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message + "An error occurred while adding the book.");
            }
        }
        public List<Book> SerchByTitel(string titel)
        {
            try
            {
                if (string.IsNullOrEmpty(titel))
                {
                    Console.WriteLine("You must enter the search title:");
                }
                return Books.Where(B => B.Titel.Contains(titel, stringComparison.OrdinallgnoreCase)).ToList();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message+"An error occurred while searching");
                return new List<Book>();
            }
        }
    }
    class Programe
    {
        static void Main(string[] arges)
        {

        }
    }
}
