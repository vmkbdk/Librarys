using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library
{
    class Book
    {
        public string Title { get; set; }
        public string Author { get; set; }
        public bool IsAvailable { get; set; }

        public Book(string title, string author, bool isAvailable)
        {
            Title = title;
            Author = author;
            IsAvailable = isAvailable;
        }
    }

    class Library
    {
        private List<Book> books = new List<Book>();

        public void AddBook()
        {
            Console.Write("Enter book title: ");
            string title = Console.ReadLine();

            Console.Write("Enter book author: ");
            string author = Console.ReadLine();

            books.Add(new Book(title, author, true));
            Console.WriteLine("Book added successfully!");
        }
        public void SearchBooksByTitle()
        {
            Console.Write("Enter titel to search: ");
            string titel = Console.ReadLine();
            List<Book> results = new List<Book>();
            foreach (Book book in books)
            {
                if (book.Title.IndexOf(titel, StringComparison.OrdinalIgnoreCase) >= 0)
                {
                    results.Add(book);
                }
                DisplayResults(results);
            }
        }
        public void SearchBooksByAuthor()
        {
            Console.Write("Enter author to search: ");
            string author = Console.ReadLine();

            List<Book> results = new List<Book>();

            foreach (var book in books)
            {
                if (book.Author.IndexOf(author, StringComparison.OrdinalIgnoreCase) >= 0)
                {
                    results.Add(book);
                }
            }

            DisplayResults(results);
        }
        public void CheckAvailability()
        {
            Console.Write("Enter book title to check availability: ");
            string title = Console.ReadLine();

            Book book = null;

            foreach (Book b in books)
            {
                if (string.Equals(b.Title, title, StringComparison.OrdinalIgnoreCase))
                {
                    book = b;
                    break;
                }
            }

            if (book == null)
            {
                Console.WriteLine("Book not found.");
            }
            else
            {
                if (book.IsAvailable)
                {
                    Console.WriteLine("The book is available.");
                }
                else
                {
                    Console.WriteLine("The book is not available.");
                }
            }

        }

        private void DisplayResults(List<Book> results)
        {
            if (results.Count() > 0)
            {
                Console.WriteLine("\nSearch Results:");
                foreach (Book book in results)
                {
                    Console.WriteLine("Title: {0}, Author: {1}, Available: {2}", book.Title, book.Author, book.IsAvailable);
                }
            }
            else
            {
                Console.WriteLine("No books found.");
            }
        }

        internal class Program
        {
            static void Main(string[] args)
            {

                Library library = new Library();
                while (true)
                {
                    Console.WriteLine("\nLibrary Catalog:");
                    Console.WriteLine("1. Add a Book");
                    Console.WriteLine("2. Search Books by Title");
                    Console.WriteLine("3. Search Books by Author");
                    Console.WriteLine("4. Check Book Availability");
                    Console.WriteLine("5. Exit");
                    Console.Write("Choose an option: ");
                    try
                    {
                        int option = int.Parse(Console.ReadLine());
                        switch (option)
                        {
                            case 1:
                                library.AddBook();
                                break;
                            case 2:
                                library.SearchBooksByTitle();
                                break;
                            case 3:
                                library.SearchBooksByAuthor();
                                break;
                            case 4:
                                library.CheckAvailability();
                                break;
                            case 5:
                                Console.WriteLine("Exiting the program. Goodbye!");
                                return;
                            default:
                                Console.WriteLine("Invalid option. Please try again.");
                                break;
                        }
                    }
                    catch (Exception e)
                    {
                        Console.WriteLine("Please enter a valid number." + e);
                    }
                    Console.ReadKey();

                }
            }
        }
    }
}
