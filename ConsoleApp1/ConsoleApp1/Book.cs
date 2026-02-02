using System;
using System.Collections.Generic;
using System.Text;

namespace ConsoleApp1
{
    internal class Book
    {
        public string title;
        public string author;
        private int pages;
        public static int bookCount = 0;

        public Book(string aTitle,string aAuthor, int aPages)
        {
            //Console.WriteLine(name);
            title = aTitle;
            author = aAuthor;
            Pages = aPages;
            bookCount++;
        }

        public int Pages
        {
            get { return pages; }
            set {
                if  (value is < 3000)
                {
                    pages = value;
                }
                else {
                    pages = 0;
                }

            }
        }
        public bool HasmanyPages()
        {
            if (pages > 100)
            {
                return true;
            }
            return false;            
        }
    }
}

