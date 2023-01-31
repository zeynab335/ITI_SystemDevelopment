namespace D08
{
    //User Defined Delegate Datatype
    public delegate string bookDelegate(Book b);

  
    internal class Program
    {

        static void Main(string[] args)
        {
            //User Defined Delegate 
            bookDelegate fptr = BookFunctions.GetTitle;

            //BCL Delegeates
            Func<Book,string> fptr2 = new Func<Book, string>(BookFunctions.GetAuthors);


            //Anonymous Method(GetISBN)
            Func<Book, string> fptr3 = delegate (Book b) { return b.ISBN; };


            //Lambda Expression (GetPublicationDate)
            Func<Book, string> fptr4 =  b => b.PublicationDate.ToString() ;


            List<Book> Books = new List<Book>();
            Books.Add(new Book("_Is1", "title1", new string[] { "Author1", "Author2" }, new DateTime(), 13.5m));
            Books.Add(new Book("_Is2", "title2", new string[] { "Author1", "Author2" }, new DateTime(), 13.5m));
            Books.Add(new Book("_Is3", "title3", new string[] { "Author1", "Author2" }, new DateTime(), 13.5m));

            Console.WriteLine("By using USR-Delegate \n");

            LibraryEngine.ProcessBooks(Books, fptr);
            Console.WriteLine("***************************");

            Console.WriteLine("By using BCL [Func] \n");
            LibraryEngine.ProcessBooks(Books, fptr2);
            Console.WriteLine("***************************");

            Console.WriteLine("By using Anonymous Method \n");
            LibraryEngine.ProcessBooks(Books, fptr3);
            Console.WriteLine("***************************");

            Console.WriteLine("By using Lamda\n ");
            LibraryEngine.ProcessBooks(Books, fptr4);

        }
    }
}