// See https://aka.ms/new-console-template for more information
public class Book : Product
{
    string isbn;
    int pageNumber;
    public Book(string title, int year, string isbn) : base(title, year)
    {
        this.isbn = CheckIsbn(isbn);
    }

    public string Isbn { get{ return isbn; } set { isbn = CheckIsbn(value); } }
    public int PageNumber { get; set; }


    //Funzione di verifica per l'isbn
    private string CheckIsbn(string isbn)
    {
        while(isbn.Length != 8)
        {
            Console.WriteLine("Inserire un'isbn valido");
            isbn = Console.ReadLine();

        }
        return isbn;
    }
}


