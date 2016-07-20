using System;

namespace OOPbasics
{
    class Program
    {
        static void Main(string[] args)
        {
            LibraryUser user1 = new LibraryUser(), user2 = new LibraryUser("Maria", "Ivanenko", "+380447777777", 2);
            Console.WriteLine("User1 " + user1.FirstName + " " + user1.LastName);
            Console.WriteLine("User2 " + user2.FirstName + " " + user2.LastName);

            Console.WriteLine("User 1: add Harry Potter");
            user1.AddBook("Harry Potter");
            Console.WriteLine("User 2: add Sherlock Holmes");
            user2.AddBook("Sherlock Holmes");
            Console.WriteLine("user1.BooksCount = " + user1.BooksCount() + "; user2.BooksCount " + user2.BooksCount());
            Console.WriteLine("user2 :");
            Console.WriteLine("Add Kobzar");
            user2.AddBook("Kobzar");
            Console.WriteLine("user2.BooksCount " + user2.BooksCount());
            Console.WriteLine("Add Dorian Gray");
            user2.AddBook("Dorian Gray");
            Console.WriteLine("user2.BooksCount " + user2.BooksCount());
            Console.WriteLine("user2 books " + user2[0] + "\n" + user2[1] + user2[2]);
            Console.WriteLine("Remove Sherlock Holmes");
            user2.RemoveBook("Sherlock Holmes");
            Console.WriteLine("user2.BooksCount " + user2.BooksCount());
            Console.WriteLine("user2 books " + user2[0] + "\n" + user2[1] + user2[2]);
            Console.WriteLine("user2.BookInfo Kobzar " + user2.BookInfo("Kobzar"));
        }
        
    }
    // 1) declare interface ILibraryUser
    // declare method's signature for methods of class LibraryUser
    public interface iLibraryUser
    {
        
        void AddBook(string bookname);
        void RemoveBook(string bookname);
        int BookInfo(string bookname);
        int BooksCount(); 
        
    }

    // 2) declare class LibraryUser, it implements ILibraryUser
    public class LibraryUser : iLibraryUser
    {
        // 3) declare properties: FirstName (read only), LastName (read only), 
        // Id (read only), Phone (get and set), BookLimit (read only)
        public string FirstName;
        public string firstname
        { get { return FirstName; } }
        delegate int u(int i);

        public string LastName;
        public string lastname
        { get { return LastName; } }

        private int Id;
        public int id
        { get { return Id; } }

        private string Phone;
        public string phone
        {
            get
            {
                return Phone;
            }
            set
            {
                Phone = value;
            }
        }

        private int BookLimit;
        public int booklimit
        { get { return BookLimit; } }

        // 4) declare field (bookList) as a string array
        private string[] bookList = new string[5];

        // 5) declare indexer BookList for array bookList
        public string this[int bookcount]
        {
            get
            {
                return bookList[bookcount];
            }
            set
            {
                bookList[bookcount] = value;
            }
        }

        // 6) declare constructors: default and parameter
        public LibraryUser()
        {

        }

        public LibraryUser(string first, string last, string _phone, int _booklimit)
        {
            FirstName = first;
            LastName = last;
            Phone = _phone;
            BookLimit = _booklimit;

        }

        public void AddBook(string bookname)
        {
            
            for(int i = 0; i < bookList.Length; i++)
            {
                if (bookList[i] == null)
                {
                    bookList[i] = bookname;
                    break;
                }
                
            }
        }

        public void RemoveBook(string bookname)
        {
            for (int i = 0; i < bookList.Length; i++)
            {
                if (bookList[i] == bookname)
                {
                    bookList[i] = null;
                    
                }

            }
        }

        public int BookInfo(string bookname)
        {
            int index = -1;
            for(int i = 0; i < bookList.Length; i++)
            {
                if(bookList[i] == bookname)
                {
                    index = i;
                }
             }
            return index;
        }

        public int BooksCount()
        {
            
            int count = 0;
            for(int i = 0; i < bookList.Length; i++)
            {
                if(bookList[i] != null)
                {
                    count++;
                }
                
            }
            return count;
        }
    }
}