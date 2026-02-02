using ConsoleApp1;
using System;
using System.Reflection;

class Program
{
    static void Main(string[] args)    
    {
        Book book1 = new Book("The Great Gatsby", "F. Scott Fitzgerald", 200);
        Book book2 = new Book("Hello", "Adele", 250);
        //book1.title = "The Great Gatsby";
        //book1.author = "F. Scott Fitzgerald";
        //book1.pages = 180;

        Console.WriteLine(Book.bookCount);
        Console.WriteLine(book2.author);

        Console.ReadLine();        
    }    
    
}