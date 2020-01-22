using System;
using System.Collections.Generic;
using System.IO;

namespace Labs2
{
    public class TestLibrary
    {
        public static void test()
        {
            Console.WriteLine("\nТест создания книги\n");
            LibraryBook newBook = new LibraryBook(BookType.Comedy, 23);
            newBook.PutToStack();
            newBook.GetFromStack();
            Reader newReader = new Reader("Mark", 1312);
            Console.WriteLine("\nТест создания полки\n");
            newBook.PutToStack();
            Console.WriteLine(newReader.TakeBook(newBook));
            Console.WriteLine(newReader.TakeBook(newBook));
            Console.WriteLine(newReader.ReturnBook(newBook));
            Console.WriteLine(newReader.ReturnBook(newBook));
            newReader[0] = newBook;
            newReader[0].PutToStack();
            newReader.Serialize("1.txt");
        }
    }

    public class Reader
    {
        public string name { get; }
        public int code { get; }
        protected List<LibraryBook> BookList;

        public Reader(string name, int code)
        {
            this.name = name;
            this.code = code;
            BookList = new List<LibraryBook>();
        }

        public LibraryBook this[int index]
        {
            get
            {
                if (index<0 || index>=BookList.Count)
                    throw new ArgumentOutOfRangeException();
                return BookList[index];
            }
            set
            {
                if (index>=BookList.Count || index<0)
                    BookList.Add(value);
                else
                    BookList[index] = value;
            }
        }

        public int TakeBook(LibraryBook book)
        {
            if (book.isInStack())
            {
                book.GetFromStack();
                BookList.Add(book);
                return 1;
            }
            return 0;
        }
        public int ReturnBook(LibraryBook book)
        {
            if (!book.isInStack())
            {
                book.PutToStack();
                BookList.Remove(book);
                return 1;
            }
            return 0;
        }

        public void Serialize(string path)
        {
            string data = "";
            foreach (LibraryBook book in BookList)
                data += book.type + "\n" + book.code + "\n";
            File.WriteAllText(path, data);
        }

        public void Deserialize(string path)
        {
            string[] data = File.ReadAllLines("file.txt");
            BookList.Clear();
            for (int i = 0; i < data.Length/2; i++)
            {
                BookType type = BookType.Unknown;
                int code = Int32.Parse(data[i * 2 + 1]);
                switch (data[i * 2])
                {
                    case "Horror":
                        type = BookType.Horror;
                        break;
                    case "Comedy":
                        type = BookType.Comedy;
                        break;
                    case "Drama":
                        type = BookType.Drama;
                        break;
                }
                BookList.Add(new LibraryBook(type, code));
            }
        }
    }

    public enum BookType : byte
    {
        Horror = 1,
        Comedy = 2,
        Drama = 3,
        Unknown = 255
    }
    public abstract class Book
    {
        public BookType type;
        public int code { get; set; }

        public Book(BookType type, int code)
        {
            this.type = type;
            this.code = code;
        }
        public abstract int PutToStack();

        public virtual int GetFromStack()
        {
            return 1;
        }
    }
    public class LibraryBook : Book
    {
        bool inStack;
        public LibraryBook(BookType type, int code) : base(type, code)
        {
            Console.WriteLine("Книга создана: {0}::{1}", type, code);
            inStack = false;
        }
        public override int PutToStack()
        {
            if (inStack) {
                Console.WriteLine("Книга уже на полке");
                return 0;
            }
            Console.WriteLine("Книга положена на полку");
            inStack = true;
            return 1;
        }
        public override int GetFromStack()
        {
            if (!inStack)
            {
                Console.WriteLine("Книга не на полке");
                return 0;
            }
            Console.WriteLine("Книга взята с полки");
            inStack = false;
            return 1;
        }
        public bool isInStack()
        {
            return inStack;
        }
    }
    

}